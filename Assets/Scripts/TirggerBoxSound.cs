using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirggerBoxSound : MonoBehaviour
{

    public int stn = 1;
    [SerializeField] AudioSource backmusic;
    // Start is called before the first frame update



    public void OnTriggerEnter(Collider other)
    {
        backmusic.Play();
    }

    public void OnTriggerExit(Collider other)
    {
        backmusic.Pause();
    }



}
