using Zenject;

namespace Game
{
    public abstract class PresenterBase<T> : Presenter where T : Model
    {
        protected T _model;
        protected PresenterBase(T model)
        {
            _model = model;
        }

        [Inject]
        public void Inject(DiContainer _diContainer)
        {
            _diContainer.Inject(_model);
            _model.Start();
            Start();
        }
    }
    public abstract class Presenter 
    {
        protected abstract void Start();
    }
}