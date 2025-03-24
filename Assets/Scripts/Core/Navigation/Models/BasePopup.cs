using UnityEngine;

namespace Core.Navigation.Models
{
    public abstract class BasePopup : BaseNavigationElement
    {
        [field: SerializeField]
        public int Priority { get; private set; }

        [field: SerializeField]
        public bool HasBackPanel { get; private set; }

        private PopupBackPanel popupBackPanel;

        public void SetBackPanel(PopupBackPanel popupBackPanel)
        {
            this.popupBackPanel = popupBackPanel;

            this.popupBackPanel.transform.SetParent(transform);
            this.popupBackPanel.transform.SetAsFirstSibling();
            
            this.popupBackPanel.PanelClicked += OnBackPanelClicked;
        }

        private void OnDestroy()
        {
            if (popupBackPanel != null) {
                popupBackPanel.PanelClicked -= OnBackPanelClicked;
            }
        }

        public virtual void OnBackPanelClicked()
        {
        }
    }
}