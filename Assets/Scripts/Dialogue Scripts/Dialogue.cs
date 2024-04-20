using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum interaction_type { onTrigger, onInteract }

public class Dialogue : MonoBehaviour
{
    public bool is_last = false;
    public interaction_type dialogue_type;
    public Sprite memory_sprite;
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
        print(other.tag);
        if (other.tag == "Player")
            in_interact_range = true;
    }

    private void OnTriggerExit(Collider other)
    {
        print(other.tag);
        if (other.tag == "Player")
        {
            in_interact_range = false;
            dm.hide_can_interact_text();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag == "Player")
        {
            in_interact_range = true;
            dm.hide_can_interact_text();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag == "Player")
        {
            in_interact_range = false;
            dm.hide_can_interact_text();
        }
    }

    void process_dialogue_action()
    {
        if (is_last == true)
        {
            dm.set_is_final_flag(is_last);
        }
        switch (dialogue_type)
        {
            case interaction_type.onTrigger:
                if (memory_sprite != null)
                {
                  //  print("setting image");
                    dm.set_image(memory_sprite);
                }
                dm.set_sentence_list(sentences);
                has_interacted = true;
                this.gameObject.SetActive(false);
                break;
            case interaction_type.onInteract:
                dm.display_can_interact_text();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (memory_sprite != null)
                    {
                       // print("setting image");
                        dm.set_image(memory_sprite);
                    }
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
