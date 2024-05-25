using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Treador : MonoBehaviour
{
    public Transform WindowOfTrade;

    [SerializeField]
    private Transform _openTradeMenuPosition, _closeTradeMenuPosition;

    bool openMenu = false;

    [SerializeField]
    private Transform _camera;
    [SerializeField]
    private float _distans;


    [SerializeField]
    private GameObject _button;
    [SerializeField]
    private Transform _treadorWindow;



    [SerializeField]
    private List<VegetebalStats> _vegetablesFromTreador;







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
       
    }
    private void Update()
    {
        OpenTradeMenu();
        if (openMenu == true)
        {
            WindowOfTrade.position = Vector3.MoveTowards(WindowOfTrade.transform.position,
                _openTradeMenuPosition.position, 5);

            OpenCursor._openCursorOnTrade = true;
        }
        else
        {
            WindowOfTrade.position = Vector3.MoveTowards(_closeTradeMenuPosition.transform.position,
                 _openTradeMenuPosition.position, 5);
            OpenCursor._openCursorOnTrade = false;
        }


    }
   


    void DrawTrader()
    {
        for (int i = 0; i < _vegetablesFromTreador.Count; i++)
        {
            GameObject newSlot = Instantiate(_button);
            newSlot.transform.SetParent(_treadorWindow.transform);
            newSlot.GetComponent<ButtonForTredor>().ID = _vegetablesFromTreador[i].ID;
           




            newSlot.GetComponent<Button>().myID = i;
        }
    }



    public void CloseTradeMenu()
    {
        openMenu = false;
    }
   
   

}
