using System;

namespace Core.Focus
{
    public interface IApplicationFocusHandler
    {
        public void OnApplicationFocusChanged(bool isFocused);
    }
}