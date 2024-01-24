using System;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionMeneger : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI questionText;
    [SerializeField]
    Toggle[] answerButtons;
    [SerializeField]
    int AnswersCount = 4;
 
    QuestionData questionData;
    TestManager testManager;
    bool[] answerIsChecked;
    void Start()
    {
        testManager = FindObjectOfType<TestManager>();
        SetQuestion();
        answerIsChecked = new bool[AnswersCount];
        Array.ForEach(answerIsChecked, element => element = false);

    }


    void SetQuestion()
    {
        if (testManager != null)
        {
            questionData = testManager.GetNextQuestion();
            if (questionData != null && questionData.answers.Length >= AnswersCount)
            {
                questionText.text = questionData.questionText;
                for (int i = 0; i < AnswersCount; i++)
                {
                    Text answer = answerButtons[i].GetComponentInChildren<Text>();
                    answer.text = questionData.answers[i];
                }

            }
        }
    }

    public void OnAnswerPressed(int numAnswer)
    {
        answerIsChecked[numAnswer] = !answerIsChecked[numAnswer];
    }

    public void CheckAnswers()
    {
 
    }
}
