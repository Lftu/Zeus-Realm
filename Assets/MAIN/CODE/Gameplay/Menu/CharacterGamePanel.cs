using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CharacterGamePanel : MonoBehaviour
    {
        [SerializeField] private Image _characterSprite;
        [SerializeField] private TMP_Text _taskLine;
        private CharacterData _characterData;
        
        public void Init(CharacterData characterData)
        {
            _characterData = characterData;
            _characterSprite.sprite = characterData.CharacterConfig.Sprite;
            UpdateText();
            if (_characterData.CurrentTask != null)
            {
                _characterData.CurrentTask.OnTaskProgressChanged += UpdateText;
            }
        }
        private void UpdateText()
        {
            if (_characterData.CurrentTask != null)
            {
                _taskLine.text = _characterData.CurrentTask.GetGameTaskProgress();
            }
            else
            {
                _taskLine.text = _characterData.TaskComplitedText;
            }
            
        }
    }
}