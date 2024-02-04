using UnityEngine;
using Zenject;

namespace Game
{

    public abstract class ViewBase<T> : View where T : Presenter
    {
        [Inject] private DiContainer diContainer;
        protected T _presenter;
        
        public void Init<TB>(TB slotPresenterBase) where TB : T
        {
            _presenter = slotPresenterBase;
            diContainer.Inject(_presenter);
        }
    }

    public abstract class View : MonoBehaviour
    {
        
    }
    
 
    
   
}

