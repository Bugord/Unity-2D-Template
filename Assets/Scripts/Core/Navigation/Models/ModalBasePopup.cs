using Cysharp.Threading.Tasks;

namespace Core.Navigation.Models
{
    public abstract class BaseModalPopup<T> : BasePopup
    {
        protected readonly UniTaskCompletionSource<T> Tcs = new();

        public UniTask<T> Task => Tcs.Task;

        protected void SetResult(T data)
        {
            Tcs.TrySetResult(data);
        }
    }
}