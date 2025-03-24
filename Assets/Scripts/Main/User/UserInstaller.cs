using Main.User.Core;
using UnityEngine;
using Zenject;

namespace Main.User
{
    [CreateAssetMenu(fileName = "installer_user_service", menuName = "Installers/Main/User Service")]
    public class UserInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UserService>().AsTransient();
        }
    }
}