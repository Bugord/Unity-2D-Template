using Core.Navigation.Configs;
using Core.Navigation.Models;
using Core.Navigation.Systems;
using Core.Navigation.Transition.Services;
using UnityEngine;
using Zenject;

namespace Core.Navigation.Installers
{
    [CreateAssetMenu(fileName = "installer_navigation", menuName = "Installers/Main/Navigation")]
    public class NavigationInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private UIProviderConfig uiProviderConfig;

        [SerializeField]
        private NavigationConfig navigationConfig;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<NavigationService>().AsSingle();
            Container.BindInterfacesTo<TransitionService>().AsSingle();
            Container.BindInterfacesTo<LoadingScreenService>().AsSingle();
            Container.BindInterfacesTo<ScreenFactory>().AsTransient();
            Container.BindInterfacesTo<PopupFactory>().AsTransient();

            Container.Bind<UIProvider>().AsSingle();
            Container.Bind<UIProviderConfig>().FromInstance(uiProviderConfig);
            Container.Bind<NavigationConfig>().FromInstance(navigationConfig);
        }
    }
}