using UnityEngine;
using UnityEngine.UI;


namespace Game {
    public class AudioSwitcher : MonoBehaviour
    {    
        private static bool _soundOn;
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(Change);
            Sunc();
        }
        
        private void Change()
        {
            _soundOn = !_soundOn;          
            Sunc();
        }

        private void Sunc()
        {
            AudioListener.volume = _soundOn ? 1 : 0;           
        }        
    }
}
