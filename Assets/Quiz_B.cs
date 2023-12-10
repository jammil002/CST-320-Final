using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quiz_B : MonoBehaviour
{
    public GameObject welcome, guide, text, quiz, timer, button;

    // Start is called before the first frame update
    void Start()
    {
        quiz.SetActive(false);
        quiz.SetActive(timer);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        if (!text.activeInHierarchy)
        {
            welcome.SetActive(false);
            guide.SetActive(false);
            quiz.SetActive(true);
            timer.SetActive(true);
        }
        else
        {
            Debug.Log("Something happened, button triggers failed.");
        }
    }

    public void OnSelect()
    {

        if (!text.activeInHierarchy)
        {
            welcome.SetActive(false);
            guide.SetActive(false);
            quiz.SetActive(true);
            timer.SetActive(true);
        }
        else
        {
            Debug.Log("Something happened, button triggers failed.");
        }
    }
}
