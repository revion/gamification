using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Stage_Load : MonoBehaviour
{
    public Button start_game;
    public Button end_game;
    void Start()
    {
        start_game.onClick.AddListener(startGame);
        end_game.onClick.AddListener(endGame);
    }
    void startGame()
    {
        Application.LoadLevel(1);
        //SceneManager.LoadScene("Stage List");
    }
    void endGame()
    {
        Application.Quit();
    }
}
