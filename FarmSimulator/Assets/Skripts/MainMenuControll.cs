using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControll : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene(0);
    } 

    public void QuiteGameButton()
    {
        Application.Quit();
    }
}
