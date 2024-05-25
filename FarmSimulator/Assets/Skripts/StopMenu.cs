using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMenu : MonoBehaviour
{

    [SerializeField]
    private Transform _openMenuPosition, _closeMenuPosition;
    [SerializeField]
    private Transform _menu;

    bool isOpen = false;


    private void Start()
    {
        _menu.position = _closeMenuPosition.position;
    }
    private void Update()
    {
        OpenStopMenu();
    }

    void OpenStopMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isOpen = !isOpen;

        if (isOpen)
        {
            _menu.transform.position = Vector3.MoveTowards(_menu.transform.position,
                _openMenuPosition.position, 5);
            //Cursor.lockState = CursorLockMode.Confined;
            //Cursor.visible = true;
            //Time.timeScale = 0;

        }
        else
        {
            _menu.transform.position = Vector3.MoveTowards(_menu.transform.position,
               _closeMenuPosition.position, 5);
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            //Time.timeScale = 1;

        }
    }



    public void ContinueButton()
    {
        _menu.transform.position = Vector3.MoveTowards(_menu.transform.position,
               _closeMenuPosition.position, 5);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void GoToMainMenuButton()
    {
        SceneManager.LoadScene(1);
    }

}
