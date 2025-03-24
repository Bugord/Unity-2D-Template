using Core.Navigation.Systems;
using Core.Navigation.Transition.Popups;
using Cysharp.Threading.Tasks;

namespace Core.Navigation.Transition.Services
{
    public class TransitionService : ITransitionService
    {
        private readonly INavigationService navigationService;
        private TransitionPopup transitionPopup;
        public bool IsTransitionInProgress { get; private set; }

        public TransitionService(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public async UniTask FadeInTransition()
        {
            if (IsTransitionInProgress) {
                return;
            }

            IsTransitionInProgress = true;

            transitionPopup = navigationService.PushPopup<TransitionPopup>();
            await transitionPopup.FadeInTransition();
        }

        public async UniTask FadeOutTransition()
        {
            if (!IsTransitionInProgress) {
                return;
            }

            await transitionPopup.FadeOutTransition();
            navigationService.ClosePopup(transitionPopup);
            transitionPopup = null;

            IsTransitionInProgress = false;
        }
    }
}