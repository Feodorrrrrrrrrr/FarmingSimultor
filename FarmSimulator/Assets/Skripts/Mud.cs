using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
    public int _seatCount; 
    private void Awake()
    {       
        _seatCount = transform.childCount;   
    }
}
