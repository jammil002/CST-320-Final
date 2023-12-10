using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Welocome_Script : MonoBehaviour
{
    Transform parentTransform;
    public string targetText;
    public Vector3 nPosition;
    GameObject[] texts;
    GameObject guide, quiz, welcome, timer;
    int textNum;
    int CC;
    // Start is called before the first frame update
    void Start()
    {
        guide = GameObject.Find("GuideMenu");
        welcome = GameObject.Find("Hud");
        timer = GameObject.Find("Timer");
        quiz = GameObject.Find("Quiz");
        
        texts = GameObject.FindGameObjectsWithTag("Welcome");
        parentTransform = transform.parent;
        CC = 0;
        for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i].name == targetText)
            {
                textNum = i;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        if (texts[textNum].name == "CONTINUE" && CC == 0)
        {
            CC++;
            GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().text = "The left buttom on the bottom, middle of the screen.\n Will show a screan hud and some questions,\n" +
                "these questions, if clicked on, will show you their answers.\n This is to help you understand what is going on.\n(Press continue.)";
            GameObject.Find("CONTINUE").GetComponent<TextMeshProUGUI>().text = "Continue";
            GameObject.Find("Arrow").SetActive(true);
        }
        else if (texts[textNum].name == "CONTINUE" && CC == 1)
        {
            CC++;
            GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().text = "The right buttom on the bottom, middle of the screen.\n Will start a quiz that you will go through,\n" +
                "don't worry about it now that is for the end.\n This is to help you figure out if you understand what is going on.\n (Press continue.)";
            nPosition = new Vector3(parentTransform.position.x + 319, parentTransform.position.y, parentTransform.position.z);
            GameObject.Find("Arrow").transform.position = nPosition;
        }
        else if (texts[textNum].name == "CONTINUE" && CC == 2)
        {
            CC++;
            GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().text = "As soon as you hit the continue again. These prompts will go\n You will be free to go explore and interact,\n" +
                "if you have questions, click the guide, and it will show some questions with answers.\n And if you ready press the quiz button and test yourself.\n(Press continue.)";
            GameObject.Find("Arrow").SetActive(false);
        }
        else if (texts[textNum].name == "CONTINUE" && CC == 3)
        {
            CC++;
            GameObject.Find("Welcome").SetActive(false);
            GameObject.Find("CONTINUE").SetActive(false);
        }
        else if (texts[textNum].name == "Guide_B" && !guide.activeInHierarchy)
        {
            guide.SetActive(true);
        }
        else if (texts[textNum].name == "Guide_B" && guide.activeInHierarchy)
        {
            guide.SetActive(false);
        }
        else if (texts[textNum].name == "Quiz_B")
        {
            guide.SetActive(false);
            welcome.SetActive(false);
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
        
        if (texts[textNum].name == "CONTINUE" && CC == 0)
        {
            CC++;
            GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().text = "The left buttom on the bottom, middle of the screen.\n Will show a screan hud and some questions,\n" +
                "these questions, if clicked on, will show you their answers.\n This is to help you understand what is going on.\n(Press continue.)";
            GameObject.Find("CONTINUE").GetComponent<TextMeshProUGUI>().text = "Continue";
            GameObject.Find("Arrow").SetActive(true);
        } else if (texts[textNum].name == "CONTINUE" && CC == 1)
        {
            CC++;
            GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().text = "The right buttom on the bottom, middle of the screen.\n Will start a quiz that you will go through,\n" +
                "don't worry about it now that is for the end.\n This is to help you figure out if you understand what is going on.\n (Press continue.)";
            nPosition = new Vector3(parentTransform.position.x + 319, parentTransform.position.y, parentTransform.position.z);
            GameObject.Find("Arrow").transform.position = nPosition;
        } else if (texts[textNum].name == "CONTINUE" && CC == 2)
        {
            CC++;
            GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().text = "As soon as you hit the continue again. These prompts will go\n You will be free to go explore and interact,\n" +
                "if you have questions, click the guide, and it will show some questions with answers.\n And if you ready press the quiz button and test yourself.\n(Press continue.)";
            GameObject.Find("Arrow").SetActive(false);
        } else if (texts[textNum].name == "CONTINUE" && CC == 3)
        {  
            CC++;
            GameObject.Find("Welcome").SetActive(false);
            GameObject.Find("CONTINUE").SetActive(false);
        } else if(texts[textNum].name == "Guide" && !guide.activeInHierarchy)
        {
            guide.SetActive(true);
        } else if (texts[textNum].name == "Guide" && guide.activeInHierarchy)
        {
            guide.SetActive(false);
        } else if (texts[textNum].name == "Quiz")
        {
            guide.SetActive(false);
            welcome.SetActive(false);
            quiz.SetActive(true);
            timer.SetActive(true);
        } else
        {
            Debug.Log("Something happened, button triggers failed.");
        }
    }
}
