using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class Slot : MonoBehaviour
    {
        [Inject] private PlaySymbolsSprites _playSymbolsSprites;
        [SerializeField] private Image _slotImage;
        private AudioSource _audio;
        private ParticleSystem _particle;
        [SerializeField] private RectTransform _rectTransform;
        private int _slotNumber;
        private Sequence _changeSlotIconAnim;
        private void Awake()
        {
            _audio = GetComponentInChildren<AudioSource>();
            _particle = GetComponentInChildren<ParticleSystem>();
        }

        public void ChangeSlot(int slotNum, float time = 0)
        {
            _slotNumber = slotNum;
            _changeSlotIconAnim.Complete();
            _changeSlotIconAnim = DOTween.Sequence();
            _changeSlotIconAnim.Append(_rectTransform.DOAnchorPosY(-150, time / 2));
            _changeSlotIconAnim.Append(_rectTransform.DOAnchorPosY(150, 0).SetEase(Ease.Linear).OnComplete((() =>
            {
                _slotImage.sprite = _playSymbolsSprites.Sprites[_slotNumber];
            })));
            _changeSlotIconAnim.Append(_rectTransform.DOAnchorPosY(0, time / 2).SetEase(Ease.Linear));
        }

        private void PlayParticle()
        {
            _audio.Play();
            _particle.Play();
        }


        public void Highlight()
        {
            PlayParticle();
        }

        public void ScaleUp()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(1.2f, 0.4f));
            sequence.Append(transform.DOScale(1f, 0.4f));
        }
    }
}