using UnityEngine;
using Zenject;

namespace Core.Focus
{
    [CreateAssetMenu(fileName = "installer_focus", menuName = "Installers/Main/Focus")]
    public class ApplicationFocusHandlerInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ApplicationFocusHandlersManager>().AsSingle().NonLazy();
        }
    }
}