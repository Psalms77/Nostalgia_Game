using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text dialogue_text;
    public GameObject can_interact_text;
    public Image image_object;
    public float transparency_rate = 0.25f;

    private float display_char_interval = 0.005f;
    private float display_sentence_interval = 1.0f;
    private bool has_image = false;
    private float image_duration = 2.0f;
    private List<string> sentence_list = new List<string>();
    private bool is_final_level = false;

    // Start is called before the first frame update
    void Start()
    {
        //set text and sentence speed from GameMnager
        display_char_interval = GameManager.Instance.get_text_speed();
        display_sentence_interval = GameManager.Instance.get_sentence_delay_speed();

        //hide dialogue at start
        dialogue_text.gameObject.SetActive(false);
        can_interact_text.SetActive(false);

        image_object.gameObject.SetActive(false);

        sentence_list.Clear();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void set_is_final_flag(bool flag)
    {
        is_final_level = flag;
    }

    public void set_char_interval(float value)
    {
        display_char_interval = value;
    }

    public void set_sentence_interval(float value)
    {
        display_sentence_interval = value;
    }

    public void display_can_interact_text()
    {
        can_interact_text.SetActive(true);
    }

    public void hide_can_interact_text()
    {
        can_interact_text.SetActive(false);
    }

    public void display_dialogue_text()
    {
        dialogue_text.gameObject.SetActive(true);
    }

    public void set_image(Sprite sprite)
    {
        has_image = true;
        image_object.sprite = sprite;
    }

    public void reset_image()
    {
        has_image = false;
        Color tmp = new Color(1, 1, 1, 0);
        image_object.color = tmp;
        image_object.sprite = null;
        image_object.gameObject.SetActive(false);

    }

    public void set_sentence_list(List<string> new_sentences)
    {
      //  print("printing sentences");
        //copy senteces from dialogue trigger onto here
        sentence_list = new List<string>();
        //sentence_list.AddRange(new_sentences);
        sentence_list = new_sentences;

        dialogue_text.text = "";

        //display sentences
        StopAllCoroutines();
        StartCoroutine(display_sentence_text());

        //display image
        if (has_image == true)
        {
            StartCoroutine(display_memory_image());
        }

    }

    IEnumerator display_sentence_text()
    {
        display_dialogue_text();


        foreach (string sentence in sentence_list)
        {
            //reset dialgoue text for each new sentence
            dialogue_text.text = "";

            for (int i = 0; i < sentence.Length; i++)
            {
                //display one char at a time
                //wait to display next text
                dialogue_text.text += sentence[i];

                if (Input.GetKeyDown(KeyCode.F))
                {
                   // print("Skip to finish");
                    i = sentence.Length;
                    dialogue_text.text = sentence;
                }

                yield return new WaitForSeconds(display_char_interval);
            }

            //wait to display next sentence
            yield return new WaitForSeconds(display_sentence_interval);
        }

        //once finished with displaying, disable text ui
        reset_image();
        dialogue_text.gameObject.SetActive(false);

        //if is final level, load last transition
        if(is_final_level == true)
        {
            instantiate_last_transition();
        }
    }

    IEnumerator display_memory_image()
    {
       // print("Printing Image");
        image_object.gameObject.SetActive(true);
        Color tmp = new Color(1, 1, 1, 0);
        image_object.color = tmp;
        float time = 0.0f;
        while (time < image_duration)
        {
            tmp.a += transparency_rate;
            image_object.color = tmp;
            yield return new WaitForSeconds(0.5f);
            time += 0.5f;
        }
    }

    public void instantiate_last_transition()
    {
        FindObjectOfType<SpawnLastTransition>().spawn_last_transition();
    }

}
