using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CharacterLevelBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private List<FriendStar> _friendStars;

        public void ShowPowerOfFriendship(int power)
        {
            _slider.DOValue((float)power / 7, 1f);

            for (int i = 0; i < power; i++)
            {
                _friendStars[i].EnableSun();
            }
        }

        public void ChangeRewardText(RewardBase[] rewardBases)
        {
            for (var i = 0; i < _friendStars.Count; i++)
            {
                var friendStar = _friendStars[i];
                friendStar.ChangeText(rewardBases[i].Text);
            }
        }

        public void ResetValues()
        {
            _slider.value = 0;
            foreach (var star in _friendStars)
            {
                star.Hide();
            }
        }
    }
}