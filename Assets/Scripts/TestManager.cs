using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    TestFromFileLoader loader;
    List<QuestionData> questionData;
    bool isLoaded = false;
    int numCurrentQuestion;

    void Awake()
    {
        isLoaded = false;
        numCurrentQuestion = 0;
        LoadData();
    }

     private void LoadData()
    {
        if (loader != null)
        {
            string json = loader.LoadQuestions();
            questionData = TestParserJson.ParseQuestions(json);
            if (questionData != null ) 
            {
                isLoaded = true;
            }
        }

    }

     public QuestionData GetNextQuestion()
    {
        if (isLoaded)
        {
            return questionData[numCurrentQuestion++];
        }
        Debug.LogError("Question Data was not loaded");
        return null;
    }


}
