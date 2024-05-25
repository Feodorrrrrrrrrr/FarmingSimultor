using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTress : MonoBehaviour
{
    [SerializeField]
    private AudioSource _birdSound;

    private void Start()
    {
        _birdSound.Play();
    }

}
