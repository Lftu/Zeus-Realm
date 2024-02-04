using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Game
{
    public class GameLoading : MonoBehaviour
    {
        private const string tutorialKey = "Tutorial";
        private void Start()
        {
            StartCoroutine(Load());
        }

        private IEnumerator Load()
        {
            yield return new WaitForSeconds(3);
            if (PlayerPrefs.GetInt(tutorialKey) == 0)
            {
                PlayerPrefs.SetInt(tutorialKey, Random.Range(2, 12948));
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(2);
            }

        }
    }
}