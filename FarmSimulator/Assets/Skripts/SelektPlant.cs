//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SelektPlant : MonoBehaviour
//{
//    [SerializeField]
//    private Camera _camera;
//    [SerializeField]
//    private int _distance;
//    GameObject newObj1;
   
//    void SelektObj()
//    {
//        RaycastHit hit;
//        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _distance))
//        {

//            if (hit.transform.CompareTag("Plant") )
//            {
//                newObj1 = hit.transform.gameObject;
//                newObj1.transform.GetComponent<Plant>().seen = true;
//                Plant.UseLightOut = false;
//                Debug.Log(hit.transform.tag);
//            }
//            else
//            {
//                //Debug.Log(hit.transform.tag);
//                Plant.UseLightOut = true;
//            }


//        }
//    }
//    void FixedUpdate()
//    {
//        SelektObj();
//    }
//}
