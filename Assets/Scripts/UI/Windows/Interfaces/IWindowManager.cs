namespace Idler.Windows
{
    public interface IWindowManager
    {
        TType GetWindow<TType>() where TType : IWindow;
    }
}