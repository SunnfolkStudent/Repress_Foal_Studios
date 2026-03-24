using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Scenes/Level_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
