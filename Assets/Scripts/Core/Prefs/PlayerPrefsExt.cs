using UnityEngine;

namespace Core.Prefs
{
    public static class PlayerPrefsExt
    {
        public static T Load<T>(string key)
        {
            var json = PlayerPrefsManager.GetString(key);
            return JsonUtility.FromJson<T>(json);
        }

        public static void Save<T>(string key, T value)
        {
            var json = JsonUtility.ToJson(value);
            PlayerPrefsManager.SetString(key, json);
        }

        public static void Delete(string key)
        {
            PlayerPrefsManager.DeleteKey(key);
        }

        public static void DeleteAll()
        {
            PlayerPrefsManager.DeleteAll();
        }
    }
}