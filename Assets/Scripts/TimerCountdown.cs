using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerCountdown : MonoBehaviour
{
    public float timeRemaining = 10f;
    public Text timerText;
    public Image TargetImage;
    public void Awake()
    {
        timerText.text = timeRemaining.ToString();
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        TargetImage.fillAmount = timeRemaining / 10f;
        timerText.text = ((int) timeRemaining).ToString();
    }
}
