using UnityEngine;

namespace Main.Sounds.Core
{
    public interface IAudioSourceFactory
    {
        AudioSource Create(Transform parent);
    }
}