using UnityEngine;

namespace Idler.Windows
{
    public abstract class Window<TData> : MonoBehaviour, IWindow where TData : IWindowData
    {
        public abstract void Open(TData data);
        public abstract void Close();
    }
}
