using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
public class ShowVictory : MonoBehaviour
{
    public Text scoring;
    public Text badge_title;
    public Text badge_desc;
    public Button back;
    public Image badge;
    void Start()
    {
        //badge.enabled = false;
        scoring.GetComponent<Text>().text = "You get score: " + Score.score;
        badge_title.GetComponent<Text>().text = "Try more";
        badge_desc.GetComponent<Text>().text = "Play at least once";
        back.onClick.AddListener(Home);
    }
    void Update()
    {
        if (Condition.easy_count_win == 1)
        {
            //badge.enabled = true;
            badge_title.GetComponent<Text>().text = "<b>Nice Job</b>";
            badge_desc.GetComponent<Text>().text = "You have complete one time on Daily Word";
        }
        if (Condition.hard_count_win == 1)
        {
            //badge.enabled = true;
            badge_title.GetComponent<Text>().text = "<b>Try Hard</b>";
            badge_desc.GetComponent<Text>().text = "You have complete one time on Grammatical";
        }
    }
    void Home()
    {
        Application.LoadLevel(0);
        //SceneManager.LoadScene("Main Menu");
    }
}
