using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PutPlant : MonoBehaviour
{
    public GameObject backPack;
    [SerializeField]
    private Transform _camera;
    [SerializeField]
    private float _distans;

    public static bool rerdraw;

    public Transform VejetableUipanel;


    private int _vegetableNumber = 0;
    //[SerializeField]
    //private List<Transform> _vegetebalUi = new List<Transform>();
    [SerializeField]
    private List<GameObject> _vegetebalPreab = new List<GameObject>();

    [SerializeField]
    private List<Transform> ObjectInFastMenu = new List<Transform>();

    

    void ChoceVegetable()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _vegetableNumber = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _vegetableNumber = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            _vegetableNumber = 2;

        foreach (var item in ObjectInFastMenu)
        {
            item.transform.localScale = new Vector3(1, 1, 1);
        }

        ObjectInFastMenu[_vegetableNumber].transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
    }

    private void Start()
    {
        for (int i = 0; i < VejetableUipanel.childCount; i++)
        {
            ObjectInFastMenu[i] = VejetableUipanel.GetChild(i);
        }
        ChoceVegetable();
    }
    void PlantVegetables()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _distans))
            {
                if (hit.transform.CompareTag("Mud") && BackPack.vegetableInFastMenuForPlanting[_vegetableNumber].count
                    > 0 && hit.transform.GetComponent<Mud>()._seatCount > 0)
                {
                    for (int i = 0; i < hit.transform.GetComponent<Mud>()._seatCount; i++)
                    {
                        if (hit.transform.GetChild(i).childCount == 0)
                        {


                            GameObject newPlant = Instantiate(_vegetebalPreab[BackPack.vegetableInFastMenuForPlanting[_vegetableNumber].ID]);
                            newPlant.transform.SetParent(hit.transform.GetChild(i));
                            newPlant.transform.localPosition = Vector3.zero;
                            BackPack.vegetableInFastMenuForPlanting[_vegetableNumber].count--;
                            Debug.Log("посадил");
                            backPack.GetComponent<BackPack>().ReDrawInventary();
                         

                            break;

                        }
                    }
                }
            }
        }
    }
    void GetPlunt()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit hit;
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _distans))
            {

                if (hit.transform.CompareTag("Mud") && hit.transform.GetComponent<Mud>()._seatCount > 0)
                {
                    Debug.Log("a");
                    for (int i = 0; i < hit.transform.GetComponent<Mud>()._seatCount; i++)
                    {

                        if (hit.transform.GetChild(i).childCount != 0)
                        {
                            if (hit.transform.GetChild(i).GetChild(0).gameObject.transform.GetComponent<Vegetebal>()._canBeGet)
                            {
                                Debug.Log("b");
                                Destroy(hit.transform.GetChild(i).GetChild(0).gameObject);



                                break;
                            }
                        }

                    }
                }
            }
        }
    }


    private void Update()
    {
       
            ChoceVegetable();


        PlantVegetables();
        GetPlunt();
    }
}
