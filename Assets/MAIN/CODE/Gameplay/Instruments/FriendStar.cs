using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game
{
    public class FriendStar : MonoBehaviour
    {
        [SerializeField] private Transform _sun;
        [SerializeField] private GameObject _galochka;
        [SerializeField] private TMP_Text _revardText;
        private bool _isEnabled;

        public void ChangeText(string reward)
        {
            _revardText.text = reward;
            if (reward == "")
            {
                _galochka.SetActive(false);
            }
        }

        public void EnableSun()
        {
            if (_isEnabled) return;
            _sun.DORotate(new Vector3(0f, 0f, 1080f), 1f, RotateMode.FastBeyond360);
            _sun.DOScale(1f, 1f);
            _isEnabled = true;
            _galochka.SetActive(true);
        }

        public void Hide()
        {
            _galochka.SetActive(false);
            _sun.DORotate( Vector3.zero, 0);
            _sun.localScale = Vector3.zero;
            _isEnabled = false;
        }
        
    }
}