namespace Idler.Presenters
{
    public interface IPresenter<T>
    {
        void Present(T data);
    }
}
