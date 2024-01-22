using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionMeneger : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI questionText;
    [SerializeField]
    Button[] answerButtons;

    QuestionData questionData;
    TestManager testManager;
    void Start()
    {
        testManager = FindObjectOfType<TestManager>();
        SetQuestion();
    }


    void SetQuestion()
    {
        if (testManager != null)
        {
            questionData = testManager.GetNextQuestion();
            if (questionData != null)
            {
                questionText.text = questionData.questionText;
                int n = Mathf.Min(questionData.answers.Length, answerButtons.Length);
                for (int i = 0; i < n; i++)
                {
                    TextMeshProUGUI answer = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                    answer.text = questionData.answers[i];
                }

            }
        }
    }
}
