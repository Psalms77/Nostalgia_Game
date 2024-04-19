using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Pixelation.Example.Scripts;

public class PixelTransition : MonoBehaviour
{
    //BlockCount Amount
    public float starting_amount = 512.0f;
    public float transition_amount = 128.0f;
    public float transition_duration = 1.75f;
    private float current_amount;

    // private float BlockCount; // Need a way to get access to pixelation to manipulate values
    private float currentTime = 0.0f;
    private bool is_transitioning = false;

    private Pixelation pixelation;

    private void Start()
    {
        current_amount = starting_amount;
        Camera cam = Camera.main;
        pixelation = cam.gameObject.GetComponent<Pixelation>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (is_transitioning == true)
        {
            print("reached");
            if (current_amount > transition_amount)
            {
                print("mana mana");
                float lerp_value = Mathf.Clamp01(currentTime / transition_duration);
                current_amount = Mathf.Lerp(current_amount, transition_amount, lerp_value);
                pixelation.BlockCount = current_amount;
                print("pixel count: " + pixelation.BlockCount);
            }
            else
            {
                is_transitioning = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("fellas, we got him");
            is_transitioning = true;
        }
    }
}
