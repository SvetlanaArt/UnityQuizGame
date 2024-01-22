using UnityEngine;
using System.IO;
using System;

public class TestFromFileLoader : MonoBehaviour, TestLoader
{ 
    [SerializeField]
    string fileName = "test0.json";
    [SerializeField]
    string folder = "Tests";

    public string LoadQuestions()
    {
        string path = Path.Combine(Application.dataPath, folder, fileName);
        string json = "";
        try
        {
           json = File.ReadAllText(path);
        }
        catch (Exception ex)
        {
            Debug.Log("Try Read File Error:" + ex.Message);
        }
        return json;
    }
}
