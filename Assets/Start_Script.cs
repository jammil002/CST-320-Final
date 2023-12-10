using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Start_Script : MonoBehaviour
{
    public GameObject Start_UI, Timer_UI, Quiz_UI;
    GameObject text, button;
    int CC;
    // Start is called before the first frame update
    void Start()
    {   
        CC = 0;
        Start_UI.SetActive(true);
        Timer_UI.SetActive(false);
        Quiz_UI.SetActive(false);
        text = GameObject.Find("Home_Screen");
        button = GameObject.Find("Home_B");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (CC == 0)
        {
            text.GetComponent<TextMeshProUGUI>().text = "The point of this progam is to help you understand and experience the bouyance.\n\n(Press Continue)";
            button.GetComponent<TextMeshProUGUI>().text = "Continue";
        } else if (CC == 1)
        {
            text.GetComponent<TextMeshProUGUI>().text = "If you look to your right there is a ball. If you aimed at the ball and press the side trigger, a guide menu will pop up.\n\n(Press Continue)";
        } else if (CC == 2)
        {
            text.GetComponent<TextMeshProUGUI>().text = "This Guide menu will tell you information of the environemnt around you and the answers for the quiz.\n\n(Press Continue)";
        } else if (CC == 3)
        {
            text.GetComponent<TextMeshProUGUI>().text = "Once you exit this menu a quiz menu, will start.\n\n(Press Continue)";
        } else if (CC == 4)
        {
            text.GetComponent<TextMeshProUGUI>().text = "The quiz is to get your base understanding on this topic, once done you may explore and learn all you want, but the quiz will pop up again to test you what you learn.\n\n(Press Continue)";
        } else if (CC == 5)
        {
            text.GetComponent<TextMeshProUGUI>().text = "I hope you have fun in this program!\n\n(Press Exit)";
            button.GetComponent<TextMeshProUGUI>().text = "Exit";
        } else if(CC == 6)
        {
            Start_UI.SetActive(false);
            Timer_UI.SetActive(true);
            Quiz_UI.SetActive(true);
        }
        CC++;
    }
}
