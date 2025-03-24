using System.Collections.Generic;
using Core.Navigation.Models;
using UnityEngine;

namespace Core.Navigation.Configs
{
    [CreateAssetMenu(fileName = "config_navigation", menuName = "Config/Navigation")]
    public class NavigationConfig : ScriptableObject
    {
        public PopupBackPanel popupBackPanelPrefab;
        public List<BaseScreen> screenPrefabs;
        public List<BasePopup> popupPrefabs;
    }
}