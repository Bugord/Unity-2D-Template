using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Navigation.Models
{
    public class PopupBackPanel : BaseNavigationElement, IPointerClickHandler
    {
        [SerializeField]
        private Image image;
        
        public event Action PanelClicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Popup Black Panel OnPointerClick");
            PanelClicked?.Invoke();
        }

        public void SetTransparent()
        {
            image.color = Color.clear;
        }
    }
}