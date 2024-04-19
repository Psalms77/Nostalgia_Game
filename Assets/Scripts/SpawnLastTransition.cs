using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLastTransition : MonoBehaviour
{
    public GameObject last_transition;

    // Start is called before the first frame update
    void Start()
    {
        last_transition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn_last_transition()
    {
        last_transition.SetActive(true);
    }
}
