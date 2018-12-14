using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
public class ButtonBehaviour_Easy : MonoBehaviour
{
    public string[] keywords = new string[] { "" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    protected PhraseRecognizer recognizer;
    protected string compare = "";
    public string[] question;

    public Button back;
    public Button next;
    public Text challenge,victory;
    Color textColor;
    string text;
    int index;
    float time;
	void Start ()
    {
        index = 0;
        time = 60.0f;
        text = "";

        back.onClick.AddListener(Home);
        next.onClick.AddListener(Next);

        challenge.GetComponent<Text>().text = question[index];
        textColor = victory.GetComponent<Text>().color;
        victory.GetComponent<Text>().text = text;

        next.GetComponent<Button>().gameObject.SetActive(false);
        victory.GetComponent<Text>().gameObject.SetActive(false);
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized+=recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
	}
    void Update()
    {
        time -= Time.deltaTime;
        if ((int)time == 0)
        {
            text = "Time's up!";
            textColor = Color.white;
            challenge.GetComponent<Text>().gameObject.SetActive(false);
            victory.GetComponent<Text>().gameObject.SetActive(true);
            next.GetComponent<Button>().gameObject.SetActive(false);
        }
    }
    void recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        compare = args.text;
        if (compare == challenge.GetComponent<Text>().text.ToLower())
        {
            Score.score++;
            text = "You said it!";
            textColor = Color.green;
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
        if (index < keywords.Length)
        {
            index++;
        }
        else
        {
            Condition.has_win = true;
            Condition.easy_count_win++;
            //SceneManager.LoadScene("Victory");
            Application.LoadLevel(4);
        }
        challenge.GetComponent<Text>().text = question[index];
        victory.GetComponent<Text>().gameObject.SetActive(false);
        next.GetComponent<Button>().gameObject.SetActive(false);
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