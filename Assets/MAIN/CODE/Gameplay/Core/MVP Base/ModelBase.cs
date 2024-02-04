namespace Game
{
    public abstract class ModelBase<T> : Model  where T : View
    {
        protected T _view;
        protected ModelBase(T view)
        {
            _view = view;
        }
    }
    public abstract class Model
    {
        public abstract void Start();
    }
}