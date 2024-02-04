using UnityEngine;
using System.Collections.Generic;
using Zenject;

namespace Game
{
    public class CharacterSelectMenu : MonoBehaviour
    {
        [Inject] private AllCharacters _allCharacters;
        [SerializeField] private BonusMenuManager _bonusMenuManager;
        [SerializeField] private List<CharacterPanel> _characterWindows;
        [SerializeField] private CharacterFullInfo _slotMenuManager;
        
        private void Start()
        {
            _bonusMenuManager.Open();
            for (var i = 0; i < _characterWindows.Count; i++)
            {
                var characterWindow = _characterWindows[i];
                characterWindow.Init(_allCharacters.CharacterData[i], this);
            }
        }

        public void OpenFullCharacterInfo(CharacterData characterData)
        {
            gameObject.Animate(false);
            _slotMenuManager.Open(characterData);
        }

        public void Open()
        {
            gameObject.Animate(true);
        }
    }
}