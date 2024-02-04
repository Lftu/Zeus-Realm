using System.Collections;
using UnityEngine;

namespace Game
{
    public class SlotMenuManager : MonoBehaviour
    {
        [SerializeField] private CharacterGamePanel characterGamePanel;
        [SerializeField] private CharacterFullInfo _characterFullInfo;
        [SerializeField] private GameObject _tutorial;
        [SerializeField] private SlotView slotViewBase;
        private void Awake()
        {
            slotViewBase.Init(new SlotPresenter( new SlotModel(slotViewBase)));
        }

        public void Open(CharacterData characterData)
        {
            gameObject.Animate(true);
            characterGamePanel.Init(characterData);
        }

        public void Close()
        {
            StartCoroutine(CLose());
        }

        private IEnumerator CLose()
        {
            yield return new WaitForSeconds(3);
            gameObject.Animate(false);
            _characterFullInfo.AfterSlotOpen();
        }

        public void OpenTutorial()
        {
            _tutorial.SetActive(true);
        }
    }
}
