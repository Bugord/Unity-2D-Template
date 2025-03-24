using Core.Prefs;
using Main.User.Data;

namespace Main.User.Core
{
    public class UserService : IUserService
    {
        private const string UserDataKey = "pack_bringer_key_user_data";

        public UserData GetUserData()
        {
            return PlayerPrefsManager.HasKey(UserDataKey)
                ? PlayerPrefsExt.Load<UserData>(UserDataKey)
                : new UserData();
        }

        public void UpdateUserData(UserData userData)
        {
            PlayerPrefsExt.Save(UserDataKey, userData);
        }

        public void ResetUserData()
        {
            var newUserData = new UserData();
            UpdateUserData(newUserData);
        }
    }
}