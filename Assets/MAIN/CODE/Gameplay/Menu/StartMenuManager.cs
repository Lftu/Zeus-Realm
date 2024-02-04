using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class StartMenuManager : MonoBehaviour
    {
        public void Reload()
        {
            SceneManager.LoadScene(3);
        }     
    }
}