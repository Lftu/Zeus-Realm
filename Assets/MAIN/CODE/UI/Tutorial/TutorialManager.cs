using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game {
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private bool _changeScene;
        [SerializeField] private List<GameObject> fddhrg;
        private int _page;
        private bool _isSend;

        public void OnEnable()
        {
            gameObject.Animate(true);
            _isSend = false;
            OpenNewPage();
        }
        
        public void SwitchPage()
        {
            if (_isSend) return;
            
            ClosePage();
            
            _page++;
            
            if (_page < fddhrg.Count)
            {
                OpenNewPage();
            }
            else
            {
                if(_changeScene)
                    SceneManager.LoadScene(2);
                gameObject.Animate(false);
                _isSend = true;
                _page = 0;
            }
                
        }

        private void OpenNewPage()
        {
            MenuAnimation.Animate(fddhrg[_page], true);
        }

        private void ClosePage()
        {
            MenuAnimation.Animate(fddhrg[_page], false);
        }

        private void OnDestroy()
        {
            DOTween.KillAll();
        }
    }
    
   
}


