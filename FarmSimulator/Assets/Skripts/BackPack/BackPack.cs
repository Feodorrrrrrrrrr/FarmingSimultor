using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackPack : MonoBehaviour
{



    public  List<VegetebalStats> vegetableForInspector = new List<VegetebalStats>(12);
    public static List<VegetebalStats> vegetable = new List<VegetebalStats>(12);
 
    public List<VegetebalStats> vegetableInFastMenu = new List<VegetebalStats>(3);

    public static List<VegetebalStats> vegetableInFastMenuForPlanting = new List<VegetebalStats>();




    [SerializeField]
    private VegetebalStats _mouseVegetable, _null;
    [SerializeField]
    private RawImage _mouseItemImage;
    [SerializeField]
    private int widh, high;
    [SerializeField]
    private GameObject _button, _buttonInfastMenu;


    [SerializeField]
    private Transform _openBackPackPosition, _closeBackPackPosition;
    [SerializeField]
    private int _speedOfOpeningBackPack = 7;
    bool isOpen = false;
    [SerializeField]


    public Transform _backPack;
    public Transform _fastMenu;




    void Awake()
    {
        vegetable = vegetableForInspector;

        vegetableInFastMenuForPlanting = vegetableInFastMenu;

        _mouseVegetable.name = _null.name;
        _mouseVegetable.Image = _null.Image;
        _mouseVegetable.ID = _null.ID;
        _mouseVegetable.price = _null.price;
        _mouseVegetable.count = _null.count;


        _backPack.position = _closeBackPackPosition.position;
        //vegetableInFastMenuForPlanting = vegetableInFastMenu;
       
        
        DrawInventary();
    }
   
    void Update()
    {
        OpeningBackPack();
        Mouse();
        if (_mouseVegetable.ID != _null.ID)      
            isOpen = true;

        if (PutPlant.rerdraw)
            ReDrawInventary();
    }
   
    void OpeningBackPack()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            isOpen = !isOpen;
        
        if (isOpen)
        {
            _backPack.transform.position = Vector3.MoveTowards(_backPack.transform.position, 
                _openBackPackPosition.position, _speedOfOpeningBackPack);
            //Cursor.lockState = CursorLockMode.Confined;
            //Cursor.visible = true;
            //Time.timeScale = 0;

        }
        else
        {
                _backPack.transform.position = Vector3.MoveTowards(_backPack.transform.position,
                   _closeBackPackPosition.position, _speedOfOpeningBackPack);
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            //Time.timeScale = 1;

        }
    }
    void DrawInventary()
    {
        for (int i = 0; i < widh * high; i++)
        {
            GameObject newSlot = Instantiate(_button);
            newSlot.transform.SetParent(_backPack.transform);
            newSlot.GetComponent<Button>().myInv = this;
            newSlot.GetComponent<Button>().myID = i;
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject newSlot = Instantiate(_buttonInfastMenu);
            newSlot.transform.SetParent(_fastMenu.transform);
            newSlot.GetComponent<Button>().myInv = this;
            newSlot.GetComponent<Button>().myID = i;
        }



        for (int i = 0; i < widh * high; i++)
        {
           
            GameObject newveget = new GameObject("VegetebalStats", typeof(VegetebalStats));
            newveget.GetComponent<VegetebalStats>().name = vegetable[i].name;
            newveget.GetComponent<VegetebalStats>().Image = vegetable[i].Image;
            newveget.GetComponent<VegetebalStats>().count = vegetable[i].count;
            newveget.GetComponent<VegetebalStats>().ID = vegetable[i].ID;
            vegetable[i] = newveget.GetComponent<VegetebalStats>();

        }
        for (int i = 0; i < 3; i++)
        {
            
            GameObject newveget = new GameObject("VegetebalStats", typeof(VegetebalStats));
            newveget.GetComponent<VegetebalStats>().name = vegetableInFastMenuForPlanting[i].name;
            newveget.GetComponent<VegetebalStats>().Image = vegetableInFastMenuForPlanting[i].Image;
            newveget.GetComponent<VegetebalStats>().count = vegetableInFastMenuForPlanting[i].count;
            newveget.GetComponent<VegetebalStats>().ID = vegetableInFastMenuForPlanting[i].ID;
            vegetableInFastMenuForPlanting[i] = newveget.GetComponent<VegetebalStats>();

        }
        ReDrawInventary();
    }
    void Mouse()
    {
        _mouseItemImage.transform.position = Input.mousePosition - new Vector3(0,100,0); 
    }

    public void SelectSlot(int ID , string from)
    {
        if (from == "inv")
        {
            if (vegetable[ID] == _null && _mouseVegetable != _null)
            {
                vegetable[ID].name = _mouseVegetable.name;
                vegetable[ID].Image = _mouseVegetable.Image;
                vegetable[ID].count = _mouseVegetable.count;
                vegetable[ID].ID = _mouseVegetable.ID;
            }
            else if (vegetable[ID] != _null && _mouseVegetable == _null)
            {
                _mouseVegetable.count = vegetable[ID].count;
                _mouseVegetable.name = vegetable[ID].name;
                _mouseVegetable.Image = vegetable[ID].Image;
                _mouseVegetable.ID = vegetable[ID].ID;

                vegetable[ID].name = _null.name;
                vegetable[ID].Image = _null.Image;
                vegetable[ID].count = _null.count;
                vegetable[ID].ID = _null.ID;
            }
            else
            {
                VegetebalStats tempVegetable = vegetable[ID];
                vegetable[ID] = _mouseVegetable;
                _mouseVegetable = tempVegetable;
            }
        }
        else
        {
            
            if (vegetableInFastMenu[ID] == _null && _mouseVegetable != _null)
            {
                vegetableInFastMenu[ID].name = _mouseVegetable.name;
                vegetableInFastMenu[ID].Image = _mouseVegetable.Image;
                vegetableInFastMenu[ID].count = _mouseVegetable.count;
                vegetableInFastMenu[ID].ID = _mouseVegetable.ID;
            }
            else if (vegetableInFastMenu[ID] != _null && vegetableInFastMenu[ID] == _null)
            {
                _mouseVegetable.count = vegetableInFastMenu[ID].count;
                _mouseVegetable.name = vegetableInFastMenu[ID].name;
                _mouseVegetable.Image = vegetableInFastMenu[ID].Image;
                _mouseVegetable.ID = vegetableInFastMenu[ID].ID;

                vegetable[ID].name = _null.name;
                vegetable[ID].Image = _null.Image;
                vegetable[ID].count = _null.count;
                vegetable[ID].ID = _null.ID;
            }
            else
            {
                VegetebalStats tempVegetable = vegetableInFastMenu[ID];
                vegetableInFastMenu[ID] = _mouseVegetable;
                _mouseVegetable = tempVegetable;
            }
        }
        ReDrawInventary();
    }


    public void ReDrawInventary()
    {
        for (int i = 0; i < widh * high; i++)
        {
            _backPack.GetChild(i).GetChild(0).GetComponent<RawImage>().texture = vegetable[i].Image;
            if (vegetable[i].count == 0)
            {
                vegetable[i].name = _null.name;
                vegetable[i].Image = _null.Image;
                vegetable[i].count = _null.count;
                vegetable[i].ID = _null.ID;
            }
            if (vegetable[i].ID == _null.ID)
            {
                _backPack.GetChild(i).GetChild(0).GetComponent<RawImage>().color = new Color(0, 0, 0, 0);
                _backPack.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = "";
            }
            else
            {
                _backPack.GetChild(i).GetChild(0).GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
                _backPack.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = vegetable[i].count.ToString();
               
            }
        }
        for (int i = 0; i < 3; i++)
        {
            _fastMenu.GetChild(i).GetChild(0).GetComponent<RawImage>().texture = vegetableInFastMenuForPlanting[i].Image;
            if (vegetableInFastMenuForPlanting[i].count == 0)
            {
                vegetableInFastMenuForPlanting[i].name = _null.name;
                vegetableInFastMenuForPlanting[i].Image = _null.Image;
                vegetableInFastMenuForPlanting[i].count = _null.count;
                vegetableInFastMenuForPlanting[i].ID = _null.ID;
            }
            if (vegetableInFastMenuForPlanting[i].ID == _null.ID)
            {
                _fastMenu.GetChild(i).GetChild(0).GetComponent<RawImage>().color = new Color(0, 0, 0, 0);
                _fastMenu.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = "";
            }
            else
            {
                _fastMenu.GetChild(i).GetChild(0).GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
                _fastMenu.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = vegetableInFastMenuForPlanting[i].count.ToString();
               
            }


        }

        if (_mouseVegetable.Image == null)
        {
            _mouseItemImage.GetComponent<RawImage>().color = new Color(0, 0, 0, 0);
            _mouseItemImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "";
        }
        else
        {
            _mouseItemImage.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
            _mouseItemImage.GetComponent<RawImage>().texture = _mouseVegetable.Image;
            _mouseItemImage.transform.GetChild(0).GetComponent<TMP_Text>().text = _mouseVegetable.count.ToString();
        }
        //vegetableInFastMenuForPlanting = vegetableInFastMenu;
    }



}
