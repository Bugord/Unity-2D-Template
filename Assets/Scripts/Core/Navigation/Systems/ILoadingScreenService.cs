using Cysharp.Threading.Tasks;

namespace Core.Navigation.Systems
{
    public interface ILoadingScreenService
    {
        UniTask PushLoadingScreen();
        UniTask CloseLoadingScreen();
    }
}