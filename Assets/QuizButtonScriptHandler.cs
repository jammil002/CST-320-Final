using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class QuizButtonClickHandler : MonoBehaviour
{
    public GameObject window;
    int currQuestion;
    int currAnswer;
    int quizEnd;
    public TextMeshProUGUI Question;
    public TextMeshProUGUI Answer1;
    public TextMeshProUGUI Answer2;
    public TextMeshProUGUI Answer3;
    List<List<string>> Questions = new List<List<string>>();
    List<Image> imageList = new List<Image>();
    public Button Answer1Bttn;
    public Button Answer2Bttn;
    public Button Answer3Bttn;
    public Button NextBttn;
    Image buttonImage;
    Color Selected;
    Color Unselected;
    string finalStatement;
    public int[] AnswerKey;
    public int[] userAnswers;

    void Start()
    {
        // Initialize current question index
        currQuestion = 0;
        currAnswer = -1;
        quizEnd = 0;
        AnswerKey = new int[] {1, 2, 0, 2, 1, 0};
        userAnswers = new int[6];
        finalStatement = "";
        NextBttn.gameObject.SetActive(false);
        List<string> list1 = new List<string> { "What property influences an object's buoyancy in a fluid?", "Mass", "Density", "Volume" };
        List<string> list2 = new List<string> { "Which principle is linked to the buoyant force on a submerged object?", "Pascal", "Bernoulli", "Archimedes" };
        List<string> list3 = new List<string> { "How can an object achieve neutral buoyancy?", "Adjust density", "Increase volume", "Decrease pressure" };
        List<string> list4 = new List<string> { "What effect does gravity have on buoyancy?", "Counterforce", "Enhancer", "Inhibitor" };
        List<string> list5 = new List<string> { "Which factor impacts the buoyancy of an object in water?", "Shape", "Size", "Color" };
        List<string> list6 = new List<string> { "In submarine design, why is buoyancy important?", "Stability", "Speed", "Camouflage" };
        Questions.Add(list1);
        Questions.Add(list2);
        Questions.Add(list3);
        Questions.Add(list4);
        Questions.Add(list5);
        Questions.Add(list6);
        Selected = new Color(1f, 0.5f, 0.2f, 1f);
        Unselected = new Color(1f, 0.5f, 0.2f, 0.6f);
        imageList.Add(Answer1Bttn.GetComponent<Image>());
        imageList.Add(Answer2Bttn.GetComponent<Image>());
        imageList.Add(Answer3Bttn.GetComponent<Image>());

        if (currQuestion >= 0 && currQuestion < Questions.Count)
        {
            updateWindow(currQuestion, currAnswer, imageList);
        }
    }

    public void OnButtonClick(string buttonName)
    {
        if (buttonName == "Next")
        {
            if(quizEnd == 1)
            {
                Reset();
                window.SetActive(false);
            }
            else if (currQuestion < Questions.Count)
            {
                NextBttn.gameObject.SetActive(false);
                userAnswers[currQuestion] = currAnswer;
                currAnswer = -1;
                currQuestion++;
                 if(currQuestion >= 6)
                {
                    Answer1Bttn.gameObject.SetActive(false);
                    Answer2Bttn.gameObject.SetActive(false);
                    Answer3Bttn.gameObject.SetActive(false);
                    finalStatement = gradeQuiz(AnswerKey, userAnswers, finalStatement);
                    Question.text = finalStatement;
                    quizEnd = 1;
                    NextBttn.gameObject.SetActive(true);
                    return;
                }
                updateWindow(currQuestion, currAnswer, imageList);
                
            }

        }
        else if (buttonName == "Answer1")
        {
            currAnswer = 0;
            NextBttn.gameObject.SetActive(true);
            updateSelected(currAnswer, imageList);
        }

         else if (buttonName == "Answer2")
        {
            NextBttn.gameObject.SetActive(true);
            currAnswer = 1;
            updateSelected(currAnswer, imageList);
        }

         else if (buttonName == "Answer3")
        {
            NextBttn.gameObject.SetActive(true);
            currAnswer = 2;
            updateSelected(currAnswer, imageList);
        }
    }

    void updateWindow(int currQuestion, int currAnswer, List<Image> imageList)
    {
        if(currQuestion >= 6)
        {
            return;
        }
        Question.text = Questions[currQuestion][0];
        Answer1.text = Questions[currQuestion][1];
        Answer2.text = Questions[currQuestion][2];
        Answer3.text = Questions[currQuestion][3];
        updateSelected(currAnswer, imageList);

    }

    void updateSelected(int currAnswer, List<Image> imageList)
    {
        for(int i = 0; i <= 2; i++)
        {
            if (i == currAnswer)
            {
                imageList[i].color = Selected;
            }
            else
            {
                imageList[i].color = Unselected;
            }
    
        }
    }

    string gradeQuiz(int[] AnswerKey, int[] userAnswers, string finalStatement)
    {
        int score = 0;
        for (int i = 0; i < 6; i++)
        {
            if(AnswerKey[i] == userAnswers[i])
            {
                score++;
            }
        }
        if(score <= 2)
        {
            finalStatement = "Thank you for your efforts, it seems your understanding of buoyancy could use some help. We hope our simulation helps, please enjoy.";
        }
        else if(score > 2 && score <= 4)
        {
            finalStatement = "Thank you for your efforts, it seems you have a good understanding of buoyancy. We hope our simulation further strengthens your understanding, please enjoy.";
        }

        else
        {
            finalStatement = "Thank you for your efforts, it seems you have an excellent understanding of buoyancy, We hope our simulation aid in solidifying your understanding, please enjoy.";
        }
        return finalStatement;
    }

    void Reset()
    {
        currQuestion = 0;
        currAnswer = -1;
        quizEnd = 0;
        userAnswers = new int[6];
        Answer1Bttn.gameObject.SetActive(true);
        Answer2Bttn.gameObject.SetActive(true);
        Answer3Bttn.gameObject.SetActive(true);
        updateWindow(currQuestion, currAnswer, imageList);
    }
}
