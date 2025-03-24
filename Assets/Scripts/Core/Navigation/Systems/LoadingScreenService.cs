using Core.Navigation.Models;
using Cysharp.Threading.Tasks;

namespace Core.Navigation.Systems
{
    public class LoadingScreenService : ILoadingScreenService
    {
        private readonly INavigationService navigationService;

        private LoadingScreen loadingScreen;

        public LoadingScreenService(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public UniTask PushLoadingScreen()
        {
            loadingScreen = navigationService.PushScreen<LoadingScreen>();
            return UniTask.CompletedTask;
        }

        public UniTask CloseLoadingScreen()
        {
            if (loadingScreen == null) {
                return UniTask.CompletedTask;
            }

            navigationService.PopScreen(loadingScreen);
            return UniTask.CompletedTask;
        }
    }
}