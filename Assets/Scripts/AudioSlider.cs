using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : BaseUI
{
    [SerializeField] Slider audioSlider;
    [SerializeField] string mixername;

    protected override void Awake()
    {
        base.Awake();

        audioSlider = GetComponent<Slider>();
        audioSlider.value = PlayerPrefs.GetFloat(mixername);
    }

    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f)
            GameManager.Data.gameAudio.SetFloat(mixername, -80);
        else
            GameManager.Data.gameAudio.SetFloat(mixername, sound);
    }

    public void OnValueChange(float value)
    {
        int intvalue = (int)Mathf.Round((value + 40) * 2.5f);
        PlayerPrefs.SetFloat(mixername, value);
        texts["Value"].text = intvalue.ToString();
    }
}
