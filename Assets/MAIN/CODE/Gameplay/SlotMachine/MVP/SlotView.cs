using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SlotView : SlotViewBase
    {
        [SerializeField] private RewardMenu rewardMenu;
        [SerializeField] private List<Raw> _raws;
        [SerializeField] private Button _spinButton;
        [SerializeField] private Bet _bet;
        [SerializeField] private TMP_Text _coeficientText;
        [SerializeField] private SlotMenuManager _slotMenuManager;
        private Sequence _coeficientAnimationSequence;
        private void Start()
        {
            _spinButton.onClick.AddListener((() =>
            {
                _presenter.Spin(_bet.BetNum);
            }));
        }
        public override void DisplaySpinResult(int[,] slotStates, float time = 0)
        {
            for (int i = 0; i < SlotModelBase.BoardSize; i++)
            {
                for (int j = 0; j < SlotModelBase.BoardSize; j++)
                {
                    _raws[i].Slots[j].ChangeSlot(slotStates[i, j], time);
                }
            }
        }
        
        /*
        public override void DisplayWinCoins(int coinsWon)
        {
            if (coinsWon > 0)
            {
                _winCoinsText.text = "+" + coinsWon.ToString();
                _winCoinsText.transform.DOScale(0, 0);
                _winCoinsText.transform.DOScale(2f, 1f);
                Sequence sequence = DOTween.Sequence();
                sequence.Append(_winCoinsText.rectTransform.DOAnchorPosY(0, 1f).OnComplete((() =>
                {
                    sequence.Append(_winCoinsText.transform.DOScale(1f, 1f));
                })));
                sequence.Append(_winCoinsText.rectTransform.DOAnchorPosY(774, 1f));
            }
        }
        */
        public override void DisplayWinCoins(int coinsWon)
        {
            if (coinsWon > 0)
            {
                rewardMenu.Open(coinsWon);
            }
        }


        public override void ChangeCoefficientText(float coefficient)
        {
            _coeficientText.text = coefficient.ToString("0.0")+ "X";
        }

        public override void HighlightComboSlots(List<int> slots)
        {
            foreach (var s in slots)
            {
                _raws[s / SlotModelBase.BoardSize].Slots[s % SlotModelBase.BoardSize].ScaleUp();
            }
        }

        public override void End()
        {
            _slotMenuManager.Close();
        }

        public override void DisplayCoefficientWithAnim(float coefficient)
        {
            ChangeCoefficientText(coefficient);
            TextAnimation(_coeficientText.transform);
        }
        private void TextAnimation(Transform textTransform)
        {
            _coeficientAnimationSequence.Complete();
            _coeficientAnimationSequence = DOTween.Sequence();
            _coeficientAnimationSequence.Append(textTransform.DOScale(1.2f, 0.5f));
            _coeficientAnimationSequence.Append(textTransform.DOScale(1f, 0.5f));
        }
    }
}