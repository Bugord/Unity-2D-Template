using Core.Navigation.Models;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Navigation.Configs
{
    [CreateAssetMenu(fileName = "config_ui_provider", menuName = "Config/UI Provider")]
    public class UIProviderConfig : ScriptableObject
    {
        [field: SerializeField]
        public CanvasWrapper CanvasWrapperPrefab { get; private set; }      
        
        [field: SerializeField]
        public EventSystem EventSystemPrefab { get; private set; }
    }
}