using UnityEngine;
using UnityEngine.SceneManagement;

namespace DawnOfTheApocalypse
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        private UIController _uiController;
    
        private void ManageSingleton()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        private void Awake()
        {
            ManageSingleton();

            _uiController = FindObjectOfType<UIController>();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
            _uiController.IsDead = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    
    }
}

