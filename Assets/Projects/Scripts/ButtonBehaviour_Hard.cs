using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
public class ButtonBehaviour_Hard : MonoBehaviour
{
    public string[] keywords = new string[] { "" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    protected PhraseRecognizer recognizer;
    protected string compare = "";

    public Button back;
    public Button next;
    public Text challenge, victory;
    public string[] question;
    int index;
    void Start()
    {
        index = 0;
        back.onClick.AddListener(Home);
        next.onClick.AddListener(Next);
        next.GetComponent<Button>().gameObject.SetActive(false);
        victory.GetComponent<Text>().gameObject.SetActive(false);
        challenge.GetComponent<Text>().text=question[index];
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }
    void recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        compare = args.text;
        if (compare == challenge.GetComponent<Text>().text.ToLower())
        {
            Score.score++;
            next.GetComponent<Button>().gameObject.SetActive(true);
            victory.GetComponent<Text>().gameObject.SetActive(true);
        }
    }
    void Home()
    {
        Application.LoadLevel(1);
        //SceneManager.LoadScene("Stage List");
    }
    void Next()
    {
        victory.GetComponent<Text>().gameObject.SetActive(false);
        next.GetComponent<Button>().gameObject.SetActive(false);
        if (index < 10)
        {
            index++;
        }
        else
        {
            Application.LoadLevel(4);
            Condition.has_win = true;
            Condition.hard_count_win++;
            //SceneManager.LoadScene("Victory");
        }
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