using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace Main.Sounds.Data
{ 
    public class SoundEffectData : ScriptableObject
    {
        public AudioResource resource;
        public AudioMixerGroup group;
        public bool loop;
        public float fadeDuration;

#if UNITY_EDITOR
        [MenuItem("Assets/Create/SoundEffectData", true)]
        private static bool CanCreateSoundEffectData()
        {
            return Selection.objects.FirstOrDefault() is AudioResource;
        }
        
        [MenuItem("Assets/Create/SoundEffectData")]
        private static void CreateSoundEffectData()
        {
            var resource = (AudioResource)Selection.objects[0];
            var path = AssetDatabase.GetAssetPath(resource);
            path = path.Replace(path.Split('/')[^1], "");

            var asset = CreateInstance<SoundEffectData>();
            asset.name = $"{resource.name.ToLower()}_sound_effect";
            asset.resource = resource;
            
            AssetDatabase.CreateAsset(asset, $"{path}{asset.name}.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
#endif
    }
}