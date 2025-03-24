using Core.Navigation.Models;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Core.Navigation.Transition.Popups
{
    public class TransitionPopup : BasePopup
    {
        [SerializeField]
        private RectTransform curtainTransform;

        [SerializeField]
        private float fadeInDuration = 1f;

        [SerializeField]
        private float fadeOutDuration = 1f;

        public UniTask FadeInTransition()
        {
            var startHeight = -1f * curtainTransform.rect.height;
            curtainTransform.anchoredPosition = new Vector2(0, startHeight);

            return curtainTransform
                .DOAnchorPosY(0, fadeInDuration)
                .SetUpdate(true)
                .ToUniTask(TweenCancelBehaviour.Kill, destroyCancellationToken);
        }

        public UniTask FadeOutTransition()
        {
            var endHeight = curtainTransform.rect.height;
            curtainTransform.anchoredPosition = Vector2.zero;

            return curtainTransform
                .DOAnchorPosY(endHeight, fadeOutDuration)
                .SetEase(Ease.InCirc)
                .SetUpdate(true)
                .ToUniTask(TweenCancelBehaviour.Kill, destroyCancellationToken);
        }
    }
}