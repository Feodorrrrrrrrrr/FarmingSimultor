using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private float InVertical;
    private float InHorizontal;

  
    public AudioSource _stepsSours;

    void Update()
    {

        InVertical = Input.GetAxisRaw("Vertical");
        InHorizontal = Input.GetAxisRaw("Horizontal");

        if (InHorizontal != 0 || InVertical != 0)
        {
            _stepsSours.UnPause();
            Debug.Log("I am plaing");
        }

        else
            _stepsSours.Pause();
    }




}
