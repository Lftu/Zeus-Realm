using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CharacterPanel : MonoBehaviour
    {
        [SerializeField] private Image _characterSprite;
        [SerializeField] private TMP_Text _taskLine;
        private CharacterData _characterData;
        private CharacterSelectMenu _characterSelectMenu;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OpenFullCharacterInfo);
        }

        public void Init(CharacterData characterData, CharacterSelectMenu characterSelectMenu)
        {
            _characterSelectMenu = characterSelectMenu;
            _characterData = characterData;
            _characterSprite.sprite = characterData.CharacterConfig.Sprite;
            
            if (characterData.CurrentTask != null)
            {
                _taskLine.text = characterData.CurrentTask.GetTaskInfo();
            }
            else
            {
                _taskLine.text = _characterData.TaskComplitedText;
            }
        }

        private void OpenFullCharacterInfo()
        {
            _characterSelectMenu.OpenFullCharacterInfo(_characterData);
        }
    }
}