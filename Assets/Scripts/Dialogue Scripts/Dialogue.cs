using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum interaction_type { onTrigger, onInteract }

public class Dialogue : MonoBehaviour
{
    public interaction_type dialogue_type;
    bool in_interact_range = false;

    public string[] sentences;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            in_interact_range = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            in_interact_range = false;
    }

}
