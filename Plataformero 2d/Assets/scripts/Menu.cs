using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] GameObject menu;
    public void StartGame()
    {
        PlayerPrefs.SetInt("lives", 5);
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
