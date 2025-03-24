using System;
using System.Collections.Generic;
using Core.Focus;
using Core.Logging;
using Core.ObjectPool;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Main.Sounds.Data;
using UnityEngine;
using UnityEngine.Audio;

namespace Main.Sounds.Core
{
    public class SoundService : ISoundService, IDisposable, IApplicationFocusHandler
    {
        private readonly IObjectPool<AudioSource> audioSourceObjectPool;
        private readonly ILogger<SoundService> logger;
        private readonly AudioMixer mixer;
        private readonly Dictionary<AudioSource, SoundEffectData> activeAudioSources;

        private int pauseCounter = 0;
        
        private bool IsPaused => pauseCounter > 0;

        public SoundService(IObjectPool<AudioSource> audioSourceObjectPool, ILogger<SoundService> logger)
        {
            this.audioSourceObjectPool = audioSourceObjectPool;
            this.logger = logger;
            activeAudioSources = new Dictionary<AudioSource, SoundEffectData>();
        }

        public void Dispose()
        {
            foreach (var audioSource in activeAudioSources.Keys)
            {
                if (audioSource != null)
                {
                    audioSource.Stop();
                }
            }
        }

        public async UniTask Play(SoundEffectData data, float fadeDuration = 0f)
        {
            var source = audioSourceObjectPool.Get();
            source.DOKill(true);

            source.resource = data.resource;
            source.loop = data.loop;
            source.outputAudioMixerGroup = data.group;

            activeAudioSources.Add(source, data);
            
            source.Play();
            await source.DOFade(1, fadeDuration).From(0);

            if (data.loop)
            {
                return;
            }
            
            await UniTask.WaitWhile(() => source !=null && source.isPlaying && source.time <= source.clip.length);
            
            if (source == null)
            {
                return;
            }

            audioSourceObjectPool.Return(source);
            activeAudioSources.Remove(source);
        }

        public void PauseAll(float fadeDuration = 0)
        {
            pauseCounter++;
            logger.Log($"Pause All ({pauseCounter})");
            UpdateAudioSourcePause(fadeDuration);
        }

        public void ResumeAll(float fadeDuration = 0)
        {
            if (pauseCounter > 0)
            {
                pauseCounter--;
            }

            logger.Log($"Resume All ({pauseCounter})");
            UpdateAudioSourcePause(fadeDuration);
        }

        private void UpdateAudioSourcePause(float fadeDuration = 0)
        {
            foreach (var activeAudioSource in activeAudioSources)
            {
                activeAudioSource.Key
                    .DOFade(IsPaused ? 0 : 1, fadeDuration)
                    .From(activeAudioSource.Key.volume);
            }
        }

        public void StopAll(float fadeDuration = 0)
        {
            foreach (var activeAudioSource in activeAudioSources) {
                activeAudioSource.Key
                    .DOFade(0, fadeDuration)
                    .From(activeAudioSource.Key.volume)
                    .OnComplete(() => StopAudioSource(activeAudioSource.Key));
            }
        }

        private void StopAudioSource(AudioSource audioSource)
        {
            audioSource.Stop();
            audioSourceObjectPool.Return(audioSource);
            activeAudioSources.Remove(audioSource);
        }

        public void OnApplicationFocusChanged(bool isFocused)
        {
            if (isFocused)
            {
                ResumeAll();
            }
            else
            {
                PauseAll();
            }
        }
    }
}