using Main.Sounds.Core;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Main.Sounds.Installers
{
    [CreateAssetMenu(fileName = "installer_sound_service", menuName = "Installers/Main/Sounds")]
    public class SoundsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private AudioSource audioSourcePrefab;
        
        [SerializeField]
        private AudioMixer audioMixer;

        [SerializeField]
        private int initialPoolSize = 10;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SoundService>().AsSingle();
            Container.BindInterfacesTo<SoundVolumeService>().AsSingle().WithArguments(audioMixer).NonLazy();
            
            Container.BindInterfacesTo<AudioSourceFactory>().AsTransient().WithArguments(audioSourcePrefab);
            Container.BindInterfacesTo<AudioSourceObjectPool>().AsSingle().WithArguments(initialPoolSize, new GameObject("SoundPoolRoot").transform);
        }
    }
}