using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text dialogue_text;
    public GameObject can_interact_text;

    public float display_char_interval = 0.005f;
    public float display_sentence_interval = 1.0f;
    private List<string> sentence_list = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //hide dialogue at start
        dialogue_text.gameObject.SetActive(false);
        can_interact_text.SetActive(false);

        sentence_list.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void display_can_interact_text()
    {
        can_interact_text.SetActive(true);
    }

    public void hide_can_interact_text()
    {
        can_interact_text.SetActive(false);
    }

    public void set_sentence_list(List<string> new_sentences)
    {
        //copy senteces from dialogue trigger onto here
        sentence_list = new List<string>();
        sentence_list.Clear();
        sentence_list.AddRange(new_sentences);

        dialogue_text.text = "";

        StopAllCoroutines();
        StartCoroutine(display_sentence_text());
    }

    IEnumerator display_sentence_text()
    {
        dialogue_text.gameObject.SetActive(true);


        foreach (string sentence in sentence_list)
        {
            //reset dialgoue text for each new sentence
            dialogue_text.text = "";

            for (int i=0; i < sentence.Length; i++)
            {
                //display one char at a time
                //wait to display next text
                dialogue_text.text += sentence[i];
                yield return new WaitForSeconds(display_char_interval);
            }

            //wait to display next sentence
            yield return new WaitForSeconds(display_sentence_interval);
        }

        //once finished with displaying, disable text ui
        dialogue_text.gameObject.SetActive(false);
    }

}
