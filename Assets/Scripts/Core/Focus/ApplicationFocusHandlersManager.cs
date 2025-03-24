using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Application = UnityEngine.Device.Application;

namespace Core.Focus
{
    public class ApplicationFocusHandlersManager : IInitializable, IDisposable
    {
        private List<IApplicationFocusHandler> applicationFocusHandlers;

        [Inject]
        private void Construct(
            [Inject(Optional = true, Source = InjectSources.Local)]
            List<IApplicationFocusHandler> applicationFocusHandlers)
        {
            this.applicationFocusHandlers = new List<IApplicationFocusHandler>(applicationFocusHandlers);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (applicationFocusHandlers != null) {
                foreach (var applicationFocusHandler in applicationFocusHandlers) {
                    applicationFocusHandler.OnApplicationFocusChanged(hasFocus);
                }
            }
        }

        public void Initialize()
        {
            Application.focusChanged += OnApplicationFocus;
        }

        public void Dispose()
        {
            Application.focusChanged -= OnApplicationFocus;
        }
    }
}