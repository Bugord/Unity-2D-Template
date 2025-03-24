namespace Core.ObjectPool
{
    public interface IObjectPool<T>
    {
        public T Get();
        public void Return(T laserRayComponent);
    }
}