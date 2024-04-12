using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelTransition : MonoBehaviour
{
    public float transition_amount = 128.0f;
    public float transition_rate = 3.0f;
    public float transition_duration = 2.0f;

    private float starting_amount;
   // private float BlockCount; // Need a way to get access to pixelation to manipulate values
    private float currentTime = 0.0f;
    private bool is_transitioning = false;

    // Start is called before the first frame update
    void Start()
    {
        //insert way of getting starting amount from pixelation
        //Store BlockCount variable
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        float lerp_value = Mathf.Clamp01(currentTime / transition_duration);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            is_transitioning = true;
        }
    }
}
