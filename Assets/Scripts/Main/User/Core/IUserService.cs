using System;
using Main.User.Data;

namespace Main.User.Core
{
    public interface IUserService
    {
        UserData GetUserData();
        void UpdateUserData(UserData userData);
        void ResetUserData();
    }
}