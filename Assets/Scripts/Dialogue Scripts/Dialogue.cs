using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum interaction_type { onTrigger, onInteract }

public class Dialogue : MonoBehaviour
{
    public interaction_type dialogue_type;
    bool in_interact_range = false;
    bool has_interacted = false;

    [TextArea(8, 20)]
    public List<string> sentences = new List<string>();

    private DialogueManager dm;


    // Start is called before the first frame update
    void Start()
    {
        dm = (DialogueManager)FindObjectOfType(typeof(DialogueManager));
        print(dm.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (in_interact_range == true && has_interacted == false)
        {
            process_dialogue_action();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            in_interact_range = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            in_interact_range = false;
            dm.hide_can_interact_text();
        }
    }

    void process_dialogue_action()
    {
        switch (dialogue_type)
        {
            case interaction_type.onTrigger:
                dm.set_sentence_list(sentences);
                has_interacted = true;
                this.gameObject.SetActive(false);
                break;
            case interaction_type.onInteract:
                dm.display_can_interact_text();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dm.hide_can_interact_text();
                    dm.set_sentence_list(sentences);
                    has_interacted = true;
                    this.gameObject.SetActive(false);
                }
                break;
            default:
                print("No dialigue type set");
                break;
        }
    }


}
