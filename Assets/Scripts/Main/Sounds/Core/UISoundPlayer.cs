using Main.Sounds.Data;

namespace Main.Sounds.Core
{
    public class UISoundPlayer : IUISoundPlayer
    {
        private readonly ISoundService soundService;
        private readonly UISoundsLibrary uiSoundsLibrary;

        public UISoundPlayer(ISoundService soundService, UISoundsLibrary uiSoundsLibrary)
        {
            this.soundService = soundService;
            this.uiSoundsLibrary = uiSoundsLibrary;
        }

        public void PlayButtonClickSound()
        {
            soundService.Play(uiSoundsLibrary.buttonClickSoundEffectData);
        }
        
        public void PlayToggleOnClickSound()
        {
            soundService.Play(uiSoundsLibrary.toggleOnClickSoundEffectData);
        }        
        
        public void PlayToggleOffClickSound()
        {
            soundService.Play(uiSoundsLibrary.toggleOffClickSoundEffectData);
        }
    }
}