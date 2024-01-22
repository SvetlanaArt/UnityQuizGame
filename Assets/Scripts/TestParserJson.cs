using System;
using System.Collections.Generic;
using UnityEngine;

public class TestParserJson
{
    [Serializable]
    public class ListQuestionData
    {
        public List<QuestionData> questions;

        public ListQuestionData()
        {
            questions = new List<QuestionData>();
        }
    }

    public static List<QuestionData> ParseQuestions(string json)
    {
        try
        {
            ListQuestionData data = JsonUtility.FromJson<ListQuestionData>(json);
            return data.questions;

        }
        catch (Exception ex) 
        {
            Debug.Log("Parse Json Error: " + ex.Message);
            return null;
        }
    }
}
