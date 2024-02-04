using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game
{
    public class TutorialPanel : MonoBehaviour
    {
        private Transform _textTransform;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _textTransform = GetComponentInChildren<TMP_Text>().transform;
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Start()
        {
            _textTransform.localScale = new Vector3(0.8f, 1, 1);
            _textTransform.DOScale(Vector3.one, 0.5f);
        }
    }
}