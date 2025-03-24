using System.Collections.Generic;
using Core.ObjectPool;
using UnityEngine;
using Zenject;

namespace Main.Sounds.Core
{
    public class AudioSourceObjectPool : IObjectPool<AudioSource>, IInitializable
    {
        private readonly IAudioSourceFactory audioSourceFactory;
        private readonly int initialSize;
        private readonly Transform parent;
        private readonly Queue<AudioSource> queue;

        public AudioSourceObjectPool(IAudioSourceFactory audioSourceFactory, int initialSize, Transform parent)
        {
            this.audioSourceFactory = audioSourceFactory;
            this.initialSize = initialSize;
            this.parent = parent;
            queue = new Queue<AudioSource>();
        }

        public void Initialize()
        {
            for (var i = 0; i < initialSize; i++) {
                Return(audioSourceFactory.Create(parent));
            }
        }

        public AudioSource Get()
        {
            if (queue.TryDequeue(out var source)) {
                source.gameObject.SetActive(true);
                return source;
            }

            return audioSourceFactory.Create(parent);
        }

        public void Return(AudioSource laserRayComponent)
        {
            laserRayComponent.gameObject.SetActive(false);
            queue.Enqueue(laserRayComponent);
        }
    }
}