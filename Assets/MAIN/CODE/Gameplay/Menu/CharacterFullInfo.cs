using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class CharacterFullInfo : MonoBehaviour
    {
        [SerializeField] private SlotMenuManager _slotMenuManager;
        [SerializeField] private CharacterSelectMenu _characterSelectMenu;
        [SerializeField] private CharacterLevelBar _friendshipBar;
        [SerializeField] private Image _characterImage;
        [SerializeField] private RectTransform _characterTransform;
        [SerializeField] private TMP_Text _taskText, _nameText, _levelText;
        [SerializeField] private GameObject _completed, _notCompleted;
        [SerializeField] private GameObject _playButton, _restartButton, _returnButton;
        private CharacterData _characterData;

        public void Open(CharacterData characterData)
        {
            _characterData = characterData;
            gameObject.Animate(true);
            
            _characterImage.sprite = _characterData.CharacterConfig.Sprite;
            _nameText.text = _characterData.CharacterConfig.Name;
            
            if (_characterData.CurrentTask != null)
            {
                _taskText.text = _characterData.CurrentTask.GetTaskInfo();
            }
            else
            {
                _taskText.text = _characterData.TaskComplitedText;
            }
            UpdateData();
        }

        private void UpdateData()
        {
            _friendshipBar.ShowPowerOfFriendship(_characterData.FriendLevel);
            _friendshipBar.ChangeRewardText(_characterData.LevelRewards);
            _levelText.text = _characterData.FriendLevel.ToString();
            _characterTransform.DOAnchorPosX(-800, 0f);
            _characterTransform.DOAnchorPosX(-200, 1f);
        }

        public void Close()
        {
            _friendshipBar.ResetValues();
            _characterSelectMenu.Open();
            gameObject.Animate(false);
        }

        public void ToSlotsMenu()
        {
            _characterData.EnableTask();
            gameObject.Animate(false);
            _slotMenuManager.Open(_characterData);
        }

        public void AfterSlotOpen()
        {
            _returnButton.SetActive(false);
            gameObject.Animate(true);
            
            if (_characterData.CurrentTask != null)
            {
                _taskText.text = _characterData.CurrentTask.GetGameTaskProgress();
                (_characterData.CurrentTask.IsCompleted ? _completed : _notCompleted).SetActive(true);
                if (_characterData.CurrentTask.IsCompleted)
                {
                    _characterData.LevelIncreased();
                }
            }
            else
            {
                _taskText.text = _characterData.TaskComplitedText;
            }
            _restartButton.SetActive(true);
            _playButton.SetActive(false);
            UpdateData();
        }

        public void Restart()
        {
            SceneManager.LoadScene(2);
        }
    }
}