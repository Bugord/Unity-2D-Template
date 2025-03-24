using Main.Application.Services;
using Main.Application.State.Systems;
using UnityEngine;
using Zenject;

namespace Main.Application.Installers
{
    [CreateAssetMenu(fileName = "installer_application", menuName = "Installers/Main/Application Installer")]
    public class ApplicationInstaller : ScriptableObjectInstaller
    {
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ApplicationEntryPoint>().AsSingle();
            Container.BindInitializableExecutionOrder<ApplicationEntryPoint>(20);

            Container.Bind<ApplicationStateMachine>().AsSingle();
            Container.BindInterfacesTo<ApplicationStateFactory>().AsTransient();
        }
    }
}