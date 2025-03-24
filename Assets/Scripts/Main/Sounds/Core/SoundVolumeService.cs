using UnityEngine.Audio;
using Zenject;

namespace Main.Sounds.Core
{
    public class SoundVolumeService : IInitializable, ISoundVolumeService
    {
        private readonly AudioMixer mixer;
        private const string SfxActiveKey = "sfx_active";
        private const string MusicActiveKey = "music_active";
        
        private const string SfxVolumeVariableName = "SfxVolume";
        private const string MusicVolumeVariableName = "MusicVolume";
        
        private bool isMusicActive;
        private bool isSfxActive;

        public bool IsMusicActive
        {
            get => isMusicActive;
            set
            {
                PlayerPrefsManager.SetBool(MusicActiveKey, value);
                SetMusicActive(value);
            }
        }

        public bool IsSfxActive
        {
            get => isSfxActive;
            set
            {
                PlayerPrefsManager.SetBool(SfxActiveKey, value);
                SetSfxActive(value);
            }
        }

        public void Initialize()
        {
            isMusicActive = PlayerPrefsManager.GetBool(MusicActiveKey, true);
            isSfxActive = PlayerPrefsManager.GetBool(SfxActiveKey, true);
            
            SetMusicActive(isMusicActive);
            SetSfxActive(isSfxActive); 
        }

        public SoundVolumeService(AudioMixer mixer)
        {
            this.mixer = mixer;
        }

        private void SetMusicActive(bool value)
        {
            isMusicActive = value;
            mixer.SetFloat(MusicVolumeVariableName, IsMusicActive ? 0 : -80f);
        }

        private void SetSfxActive(bool isActive)
        {
            isSfxActive = isActive;
            mixer.SetFloat(SfxVolumeVariableName, IsSfxActive ? 0 : -80f);
        }
    }
}