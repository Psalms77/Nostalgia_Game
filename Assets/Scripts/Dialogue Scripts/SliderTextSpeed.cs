using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderTextSpeed : MonoBehaviour
{
    public TextMeshProUGUI text_speed_slider_text = null;
    public TextMeshProUGUI sentence_delay_slider_text = null;

    public Slider text_speed_slider;
    public Slider sentence_delay_slider;

    public float min_text_speed_slider_amount = 0.0001f;
    public float max_text_speed_slider_amount = 0.99f;

    public float min_sentence_delay_slider_amount = 1.0f;
    public float max_sentence_delay_slider_amount = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        text_speed_slider.minValue = min_text_speed_slider_amount;
        text_speed_slider.maxValue = max_text_speed_slider_amount;
        sentence_delay_slider.minValue = min_sentence_delay_slider_amount;
        sentence_delay_slider.maxValue = max_sentence_delay_slider_amount;

        //set to the game manager at the start
        TextSpeedSliderChange(min_text_speed_slider_amount);
        SentenceDelaySliderChange(min_sentence_delay_slider_amount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TextSpeedSliderChange(float value)
    {
        float localValue = value;
        GameManager.Instance.set_text_speed(localValue);
        GameManager.Instance.set_dialogue_sentences();
        text_speed_slider_text.text = localValue.ToString("0.0000");
    }

    public void SentenceDelaySliderChange(float value)
    {
        float localValue = value;
        GameManager.Instance.set_sentence_delay_speed(localValue);
        GameManager.Instance.set_dialogue_sentences();
        sentence_delay_slider_text.text = localValue.ToString("0.00") + " seconds";
    }
}
