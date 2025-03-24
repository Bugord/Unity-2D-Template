using Core.Navigation.Models;
using UnityEngine;

namespace Core.Navigation.Systems
{
    public interface IPopupFactory
    {
        T Create<T>(Transform parentTransform) where T : BasePopup;
        PopupBackPanel CreatePanel(Transform parentTransform);
    }
}