using UnityEngine;

namespace Audio
{
    public class BackGroundMusic : MonoBehaviour
    {
        private static bool _isPlaying;
        private void Start()
        {
            if (!_isPlaying)
            {
                DontDestroyOnLoad(gameObject);
                _isPlaying = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}