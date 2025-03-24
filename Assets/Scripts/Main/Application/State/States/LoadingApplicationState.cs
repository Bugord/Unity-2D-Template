using Core.Logging;
using Core.Navigation.Models;
using Core.Navigation.Systems;
using Cysharp.Threading.Tasks;
using Main.Application.State.Systems;

namespace Main.Application.State.States
{
    public class LoadingApplicationState : BaseApplicationState
    {
        private readonly ILogger<LoadingApplicationState> logger;
        private readonly ILoadingScreenService loadingScreenService;

        private LoadingScreen loadingScreen;

        public LoadingApplicationState(ApplicationStateMachine applicationStateMachine,
            ILogger<LoadingApplicationState> logger, ILoadingScreenService loadingScreenService) 
            : base(applicationStateMachine)
        {
            this.logger = logger;
            this.loadingScreenService = loadingScreenService;
        }

        public override void OnEnter()
        {
            InitApp().Forget();
        }

        private async UniTask InitApp()
        {
            await loadingScreenService.PushLoadingScreen();
            logger.Log("Loading App");
            //do loading
            await loadingScreenService.CloseLoadingScreen();

            ApplicationStateMachine.ChangeState<MainMenuApplicationState>();
        }
    }
}