using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class SlotPresenter : SlotPresenterBase
    {
        public SlotPresenter(SlotModelBase model) : base(model)
        {
            
        }

        protected override void Start()
        {
            GenerateStartValues();
        }

        public override void Spin(int betNum)
        {
            if (!_model.IsAllowedSpin) return;

            SpinRoutine();
            _model.SpinningStarted(betNum);
        }

        private void GenerateStartValues()
        {
            for (int i = 0; i < SlotModelBase.BoardSize; i++)
            {
                for (int j = 0; j < SlotModelBase.BoardSize; j++)
                {
                    _model.SlotValues[i, j] = Random.Range(0, _model._slotsNum);
                }
            }

            _model.ValuesChanged();
        }

        private async void SpinRoutine()
        {
            for (int i = 0; i < 5; i++)
            {
                ChangeSlots();
                await Task.Delay(400);
            }

            CalculatePrize();
        }

        private void ChangeSlots()
        {
            int[,] slots = _model.SlotValues;
            for (int i = SlotModelBase.BoardSize - 1; i > 0; i--)
            {
                for (int j = 0; j < SlotModelBase.BoardSize; j++)
                {
                    slots[i, j] = slots[i - 1, j];
                }
            }

            for (int j = 0; j < SlotModelBase.BoardSize; j++)
            {
                slots[0, j] = Random.Range(0, _model._slotsNum);
            }

            _model.ValuesChanged(0.4f);
        }

        private void CalculatePrize()
        {
            List<List<int>> winningCombinations = GetWinningCombinations();
            CalculateCofient(winningCombinations);
            
        }

        private List<List<int>> GetWinningCombinations()
        {
            List<List<int>> winningCombinations = new List<List<int>>();

            // Check horizontal combinations
            for (int i = 0; i < SlotModelBase.BoardSize; i++)
            {
                List<int> combination = CheckCombinationInRow(i);
                if (combination.Count >= 3)
                {
                    winningCombinations.Add(combination);
                }
            }

            // Check vertical combinations
            for (int j = 0; j < SlotModelBase.BoardSize; j++)
            {
                List<int> combination = CheckCombinationInColumn(j);
                if (combination.Count >= 3)
                {
                    winningCombinations.Add(combination);
                }
            }

            return winningCombinations;
        }

        private List<int> CheckCombinationInRow(int row)
        {
            List<int> combination = new List<int>();
            int[,] slots = _model.SlotValues;
            int count = 1;
            int searchingElement = slots[row, 0];

            for (int j = 1; j < SlotModelBase.BoardSize; j++)
            {
                if (searchingElement != slots[row, j] || slots[row, j] == 0)
                {
                    searchingElement = slots[row, j];
                    count = 1;
                }
                else
                {
                    
                    count++;
                }

                if (count == 3)
                {
                    combination.Add((row * SlotModelBase.BoardSize) + j - 2); 
                    combination.Add((row * SlotModelBase.BoardSize) + j - 1); 
                    combination.Add((row * SlotModelBase.BoardSize) + j);
                }
                else if(count > 3)
                {
                    combination.Add((row * SlotModelBase.BoardSize) + j);
                }
            }

            return combination;
        }

        private List<int> CheckCombinationInColumn(int column)
        {
            List<int> combination = new List<int>();
            int[,] slots = _model.SlotValues;
            int count = 1;
            int searchingElement = slots[0, column];

            for (int i = 1; i < SlotModelBase.BoardSize; i++)
            {
                if (searchingElement != slots[i, column] || slots[i, column] == 0)
                {
                    searchingElement = slots[i, column];
                    count = 1;
                }
                else
                {
                    count++;
                }

                if (count == 3)
                {
                    combination.Add(((i - 2) * SlotModelBase.BoardSize) + column); 
                    combination.Add(((i - 1) * SlotModelBase.BoardSize) + column); 
                    combination.Add((i * SlotModelBase.BoardSize) + column); 
                }
                else if(count > 3)
                {
                    combination.Add((i * SlotModelBase.BoardSize) + column); 
                }
            }

            return combination;
        }
        

        private async void CalculateCofient(List<List<int>> combinations)
        {
            float coefficient = _model.AddCoefficient;
            foreach (var combination in combinations)
            {
                await Task.Delay(500);
                coefficient += combination.Count - 2;
                _model.DisplayCoefficient(coefficient);
                _model.HighlightCombo(combination);
                _model.ComboAppeared(combination.Count);
            }

            int betAmount = _model.betNum;
            int prize = (int)(coefficient * betAmount);
            
            if (combinations.Count == 0)
            {
                _model.SetWinResult(0);
            }
            else
            {
                _model.SetWinResult(prize);
            }
            
        }
    }
}