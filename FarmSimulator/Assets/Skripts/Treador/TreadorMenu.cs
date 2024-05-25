using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreadorMenu : MonoBehaviour
{
    [SerializeField]
    private Transform WindowOfTrade, _openTradeMenuPosition, _closeTradeMenuPosition, _camera;

    [SerializeField]
    private float _distans;

    [SerializeField]
    private GameObject _button;
  
    [SerializeField]
    private List<VegetebalStats> _vegetablesFromTreador;
    public static List<VegetebalStats> _vegetablesFromTreadorinskript;

    bool openMenu = false;




    private void Awake()
    {
        _vegetablesFromTreadorinskript = _vegetablesFromTreador;
    }

    void OpenTradeMenu()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _distans))
                if (hit.transform.CompareTag("Trader"))
                    openMenu = true;
        }
    }
    private void Start()
    {
        WindowOfTrade.transform.position = _closeTradeMenuPosition.transform.position;
        DrawTrader();

    }
    private void Update()
    {
        OpenTradeMenu();
        if (openMenu == true)
        {
            WindowOfTrade.position = Vector3.MoveTowards(WindowOfTrade.transform.position,
                _openTradeMenuPosition.position, 5);

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            WindowOfTrade.position = Vector3.MoveTowards(_closeTradeMenuPosition.transform.position,
                 _openTradeMenuPosition.position, 5);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }


    }



    void DrawTrader()
    {
        for (int i = 0; i < _vegetablesFromTreadorinskript.Count; i++)
        {
            GameObject newSlot = Instantiate(_button);
            newSlot.transform.SetParent(WindowOfTrade.transform);
            newSlot.GetComponent<ButtonForTredor>().ID = _vegetablesFromTreadorinskript[i].ID;
            newSlot.transform.GetChild(0).GetComponent<RawImage>().texture = _vegetablesFromTreadorinskript[i].Image;

        }
    }




    public void CloseTradeMenu()
    {
        openMenu = false;
    }



}
