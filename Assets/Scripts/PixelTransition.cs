using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Pixelation.Example.Scripts;

public class PixelTransition : ImageEffectBase
{
    //BlockCount Amount
    public float starting_amount = 512.0f;
    public float transition_amount = 128.0f;
    public float transition_duration = 1.75f;
    private float current_amount;

    // private float BlockCount; // Need a way to get access to pixelation to manipulate values
    private float currentTime = 0.0f;
    private bool is_transitioning = false;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (is_transitioning == true)
        {
            if (current_amount > transition_amount)
            {
                float lerp_value = Mathf.Clamp01(currentTime / transition_duration);
                current_amount = Mathf.Lerp(current_amount, transition_amount, lerp_value);
            }
            else
            {
                is_transitioning = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            is_transitioning = true;
        }
    }


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        float k = Camera.main.aspect;
        Vector2 count = new Vector2(current_amount, current_amount / k);
        Vector2 size = new Vector2(1.0f / count.x, 1.0f / count.y);
        //
        material.SetVector("BlockCount", count);
        material.SetVector("BlockSize", size);
        Graphics.Blit(source, destination, material);
    }
}
