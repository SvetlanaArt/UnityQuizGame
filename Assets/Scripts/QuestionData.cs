using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionData 
{
     public string questionText;
     public string[] answers;
     public int[] numbersRightAnswers;

    public QuestionData() 
    {
    }
 }
