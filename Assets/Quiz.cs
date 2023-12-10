using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Quiz : MonoBehaviour
{
    public GameObject quizWindow;
    float timerDuration;
    float elapsedTime;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerDuration = 600.0f;
        elapsedTime = 0.0f;
        timerText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(quizWindow.activeSelf == false)
        {
        elapsedTime += Time.deltaTime;

        // Calculate minutes and seconds
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);

        // Update the UI text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Check if the timer has reached its duration
        if (elapsedTime >= timerDuration)
        {
            // Do something when the timer reaches its duration
            quizWindow.SetActive(true);
            Debug.Log("Timer expired!");
            elapsedTime = 0.0f;
            }
        }
    }
}
