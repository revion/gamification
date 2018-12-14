using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour 
{
    public Button easy;
    public Button normal;
    public Button hard;
    public Button back;
    void Start()
    {
        easy.onClick.AddListener(Easy);
        normal.onClick.AddListener(Normal);
        hard.onClick.AddListener(Hard);
        back.onClick.AddListener(Home);
    }
    void Easy()
    {
        Application.LoadLevel(2);
        //SceneManager.LoadScene("Daily Word");
    }
    void Normal()
    {
        //Application.LoadLevel();
        //SceneManager.LoadScene("Normal");
    }
    void Hard()
    {
        Application.LoadLevel(3);
        //SceneManager.LoadScene("Grammatical");
    }
    void Home()
    {
        Application.LoadLevel(0);
        //SceneManager.LoadScene("Main Menu");
    }
}
