using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //create singleton of GameMnager
    public static GameManager Instance;

    public static float text_speed = 0.01f;
    public static float sentence_delay_speed = 1.75f;
    private List<string> test_sentences = new List<string>();
    private DialogueManager dm;

    private void Awake()
    {
       if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
       else
        {
            Instance = this;
        }

        dm = (DialogueManager)FindObjectOfType(typeof(DialogueManager));
        if (dm != null)
        {
            dm.set_char_interval(text_speed);
            dm.set_sentence_interval(sentence_delay_speed);
            test_sentences.Add("This is a test sentence. Can you read this properly?");
            test_sentences.Add("This is the second sentence. Was the pause too long?");
            //dm.set_sentence_list(test_sentences);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // dm.display_dialogue_text();
    }

    public void set_text_speed(float value)
    {
        print(value);
        dm.set_char_interval(value);
        text_speed = value;
       // dm.display_dialogue_text();
    }

    public float get_text_speed()
    {
        return text_speed;
    }

    public void set_sentence_delay_speed(float value)
    {
        print(value);
        dm.set_sentence_interval(value);
        sentence_delay_speed = value;
        //dm.display_dialogue_text();
    }

    public float get_sentence_delay_speed()
    {
        return sentence_delay_speed;
    }

    public void set_dialogue_sentences()
    {
        dm.set_sentence_list(test_sentences);
    }
}
