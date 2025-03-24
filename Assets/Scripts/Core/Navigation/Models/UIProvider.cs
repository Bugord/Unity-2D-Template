using Core.Navigation.Configs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Navigation.Models
{
    public class UIProvider
    {
        private readonly CanvasWrapper canvasWrapper;
        public readonly EventSystem EventSystem;

        public Canvas Canvas => canvasWrapper.Canvas;
        public Transform ScreensContainer => canvasWrapper.ScreensContainer;
        public Transform PopupsContainer => canvasWrapper.PopupsContainer;
        
        public UIProvider(UIProviderConfig uiProviderConfig)
        {
            canvasWrapper = Object.Instantiate(uiProviderConfig.CanvasWrapperPrefab);
            EventSystem = Object.Instantiate(uiProviderConfig.EventSystemPrefab);
            
            Object.DontDestroyOnLoad(canvasWrapper);
            Object.DontDestroyOnLoad(EventSystem);
        }
    }
}