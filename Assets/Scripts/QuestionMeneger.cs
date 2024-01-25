using System;
using System.Linq;
using System.Reflection.Emit;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionMeneger : MonoBehaviour
{
    [SerializeField]
    int rightAnswerScore = 100;
    [SerializeField]
    TextMeshProUGUI questionText;
    [SerializeField]
    Toggle[] answerButtons;
    [SerializeField]
    int answersCount = 4;
    [SerializeField]
    Sprite spriteRightAnswer;
    [SerializeField]
    Sprite spriteWrongAnswer;
 
    QuestionData questionData;
    TestManager testManager;
    bool[] answerIsChecked;
    void Start()
    {
        testManager = FindObjectOfType<TestManager>();
        answerIsChecked = new bool[answersCount];
        SetQuestion();
    }


    void SetQuestion()
    {
        Text answer;
        Array.ForEach(answerIsChecked, isChecked => isChecked = false);
        if (testManager != null)
        {
            questionData = testManager.GetNextQuestion();
            if (questionData != null && questionData.answers.Length >= answersCount)
            {
                questionText.text = questionData.questionText;
                for (int i = 0; i < answersCount; i++)
                {
                    answer = answerButtons[i].GetComponentInChildren<Text>();
                    answer.text = questionData.answers[i];
                    answerButtons[i].enabled = true;
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
        bool expectedAnswer;
        Image imageButton;
        for (int i = 0; i < answerIsChecked.Length; i++)
        {
            answerButtons[i].enabled = false;
            expectedAnswer = questionData.numbersRightAnswers.Contains<int>(i);
            if (expectedAnswer)
            {
                imageButton = answerButtons[i].GetComponentInChildren<Image>();
                imageButton.sprite = spriteRightAnswer;
            }
            if (answerIsChecked[i] != expectedAnswer)
            {
                rightAnswerScore -= rightAnswerScore / answersCount;
                if (answerIsChecked[i])
                {
                    imageButton = answerButtons[i].GetComponentInChildren<Image>();
                    imageButton.sprite = spriteWrongAnswer;
                }
            }
        }
    }
}
