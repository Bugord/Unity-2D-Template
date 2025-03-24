using UnityEngine;

namespace Core.Navigation.Models
{
    public class CanvasWrapper : MonoBehaviour
    {
        [field: SerializeField]
        public Canvas Canvas { get; set; }

        [field: SerializeField]
        public Transform ScreensContainer { get; set; }

        [field: SerializeField]
        public Transform PopupsContainer { get; set; }
    }
}