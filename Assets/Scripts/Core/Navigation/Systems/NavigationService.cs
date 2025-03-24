using System.Collections.Generic;
using System.Linq;
using Core.Logging;
using Core.Navigation.Models;

namespace Core.Navigation.Systems
{
    public class NavigationService : INavigationService
    {
        private readonly ILogger<NavigationService> logger;
        private readonly IScreenFactory screenFactory;
        private readonly IPopupFactory popupFactory;
        private readonly UIProvider uiProvider;

        private readonly LinkedList<BaseScreen> screensLinkedList;
        private readonly LinkedList<BasePopup> popupsLinkedList;
        
        public NavigationService(ILogger<NavigationService> logger, IScreenFactory screenFactory, IPopupFactory popupFactory, UIProvider uiProvider)
        {
            this.logger = logger;
            this.screenFactory = screenFactory;
            this.popupFactory = popupFactory;
            this.uiProvider = uiProvider;

            screensLinkedList = new LinkedList<BaseScreen>();
            popupsLinkedList = new LinkedList<BasePopup>();
        }

        public void PopLastScreen()
        {
            var lastScreen = screensLinkedList.Last();

            lastScreen.Destroy();
            screensLinkedList.Remove(lastScreen);

            if (screensLinkedList.Count != 0) {
                screensLinkedList.Last().SetActive();
            }
            
            logger.Log($"Closed last screen {lastScreen.GetType().Name}");
        }

        public void PopScreensToRoot()
        {
            while (screensLinkedList.Count > 1) {
                PopLastScreen();
            }
            
            logger.Log("Popped screens to root");
        }

        public T PushScreen<T>() where T : BaseScreen
        {
            var screen = screenFactory.Create<T>(uiProvider.ScreensContainer);
            if (screen == null) {
                return null;
            }

            if (screensLinkedList.Count != 0) {
                screensLinkedList.Last().SetInactive();
            }

            screensLinkedList.AddLast(screen);
            
            logger.Log($"Pushed screen {screen.GetType().Name}");
            return screen;
        }

        public T ReplaceScreen<T>() where T : BaseScreen
        {
            PopLastScreen();
            return PushScreen<T>();
        }

        public void PopScreen(BaseScreen screen)
        {
            if (screen == null) {
                return;
            }
            
            var isLast = screensLinkedList.Last() == screen;

            screensLinkedList.Remove(screen);
            screen.Destroy();

            if (isLast && screensLinkedList.Count != 0) {
                screensLinkedList.Last().SetActive();
            }
            
            logger.Log($"Popped screen {screen.GetType().Name}");
        }

        public T GetScreen<T>() where T : BaseScreen
        {
            foreach (var screen in screensLinkedList) {
                if (screen is T typedScreen) {
                    return typedScreen;
                }
            }

            return null;
        }

        public T PushPopup<T>() where T : BasePopup
        {
            var newPopup = popupFactory.Create<T>(uiProvider.PopupsContainer);
            if (newPopup == null) {
                return null;
            }

            if (newPopup.HasBackPanel) {
                AddPopupBackPanel(newPopup);
            }

            var newPopupPriority = newPopup.Priority;

            if (popupsLinkedList.Count != 0) {
                var firstHigherPriorityPopup = popupsLinkedList.FirstOrDefault(popup => popup.Priority >= newPopupPriority);
                if (firstHigherPriorityPopup != null) {
                    var higherPopupPriorityPopupNode = popupsLinkedList.Find(firstHigherPriorityPopup);
                    
                    popupsLinkedList.AddBefore(higherPopupPriorityPopupNode, newPopup);
                    var previousPopupChildPosition = higherPopupPriorityPopupNode.Value.transform.GetSiblingIndex();
                    newPopup.transform.SetSiblingIndex(previousPopupChildPosition);
                }
                else {
                    popupsLinkedList.AddLast(newPopup);
                }
            }
            else {
                popupsLinkedList.AddLast(newPopup);
            }

            logger.Log($"Pushed popup {newPopup.GetType().Name}");

            return newPopup;
        }

        public void ClosePopup(BasePopup popup)
        {
            var isLast = popupsLinkedList.Last() == popup;

            popupsLinkedList.Remove(popup);
            popup.Destroy();

            if (isLast && popupsLinkedList.Count != 0) {
                popupsLinkedList.Last().SetActive();
            }

            logger.Log($"Closed popup {popup.GetType().Name}");
        }

        public void CloseAllPopups()
        {
            foreach (var popup in popupsLinkedList) {
                popup.Destroy();
            }

            popupsLinkedList.Clear();
            
            logger.Log($"Closed all popups");
        }

        public T GetPopup<T>() where T : BasePopup
        {
            foreach (var popup in popupsLinkedList) {
                if (popup is T searchedPopup) {
                    return searchedPopup;
                }
            }

            return null;
        }

        private void AddPopupBackPanel(BasePopup popup)
        {
            var panel = popupFactory.CreatePanel(uiProvider.PopupsContainer);
            popup.SetBackPanel(panel);
        }
    }
}