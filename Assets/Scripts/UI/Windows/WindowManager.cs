using System;
using System.Collections.Generic;
using UnityEngine;

namespace Idler.Windows
{
    public class WindowManager : MonoBehaviour, IWindowManager
    {
        private Dictionary<Type, IWindow> _windows;

        public void Init()
        {
            _windows = new Dictionary<Type, IWindow>();
            IWindow[] windows = GetComponentsInChildren<IWindow>(true);
            foreach (var window in windows) _windows.Add(window.GetType(), window);
        }
        
        TType IWindowManager.GetWindow<TType>()
        {
            return (TType)_windows[typeof(TType)];
        }
    }
}
