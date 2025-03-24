﻿using UnityEngine;

namespace Core.Navigation.Models
{
    public class BaseNavigationElement : MonoBehaviour
    {
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }

        public virtual void SetInactive()
        {
            gameObject.SetActive(false);
        }

        public virtual void SetActive()
        {
            gameObject.SetActive(true);
        }
    }
}