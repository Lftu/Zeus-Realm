using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game
{
    public abstract class SlotViewBase : ViewBase<SlotPresenterBase>
    {
        [SerializeField] protected TMP_Text _spinsText, _winCoinsText;
        public abstract void DisplaySpinResult(int[,] slotStates, float time = 0);
        public abstract void DisplayWinCoins(int coinsWon);
        public abstract void DisplayCoefficientWithAnim(float coefficient);
        public abstract void ChangeCoefficientText(float coefficient);
        public abstract void HighlightComboSlots(List<int> slots);
        public abstract void End();

        public void DisplaySpinsNum(int spinsNum)
        {
            _spinsText.text = spinsNum.ToString();
        }
    }
}