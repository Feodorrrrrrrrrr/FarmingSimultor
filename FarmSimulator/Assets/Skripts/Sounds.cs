using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] sounds;

    private AudioSource _audioSourse => GetComponent<AudioSource>();


    public void PlaySound(AudioClip clip, float volume = 1, bool destroyed = false, float p1 = 0.9f, float p2 = 1.1f)
    {
        _audioSourse.pitch = Random.Range(p1,p2);
        _audioSourse.PlayOneShot(clip, volume);
    }



    private void Start()
    {

    }
}
