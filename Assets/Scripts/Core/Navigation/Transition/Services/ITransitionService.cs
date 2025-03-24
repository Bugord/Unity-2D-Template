using Cysharp.Threading.Tasks;

namespace Core.Navigation.Transition.Services
{
    public interface ITransitionService
    {
        UniTask FadeInTransition();
        UniTask FadeOutTransition();
        bool IsTransitionInProgress { get; }
    }
}