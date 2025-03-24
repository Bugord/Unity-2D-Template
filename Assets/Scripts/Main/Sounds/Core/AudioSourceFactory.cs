using UnityEngine;
using Zenject;

namespace Main.Sounds.Core
{
    public class AudioSourceFactory : IAudioSourceFactory
    {
        private readonly DiContainer container;
        private readonly AudioSource prefab;

        public AudioSourceFactory(DiContainer container, AudioSource prefab)
        {
            this.container = container;
            this.prefab = prefab;
        }

        public AudioSource Create(Transform parent)
        {
            return container.InstantiatePrefabForComponent<AudioSource>(prefab, parent);
        }
    }
}