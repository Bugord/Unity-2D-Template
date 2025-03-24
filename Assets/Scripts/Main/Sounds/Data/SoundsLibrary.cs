using UnityEngine;

namespace Main.Sounds.Data
{
    [CreateAssetMenu(fileName = "library_ui_editor", menuName = "Data/UI Sounds Library")]
    public class UISoundsLibrary : ScriptableObject
    {
        public SoundEffectData buttonClickSoundEffectData;
        public SoundEffectData toggleOnClickSoundEffectData;
        public SoundEffectData toggleOffClickSoundEffectData;
    }
}