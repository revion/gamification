using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class testPurpose : MonoBehaviour
{
    public string[] keywords = new string[] { "hello", "test" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;

    protected PhraseRecognizer recognizer;
    protected string word = "test";

    void Start()
    {
        if(keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized+=recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    void recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        print(word);
    }

    void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}