using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text TxtScore, TxtLives;
    static public int Score;
    public int currentScore;
    static public int Lives = 10;
    public int currentLives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = Score;
        TxtScore.text = "Score: " + Score;

        currentLives = Lives;
        TxtLives.text = "Lives Left: " + Lives;

        Invoke("loadScreen", 0.005f);

    }
    private void loadScreen()
    {
        if (currentScore >= 100)
        {
            SceneManager.LoadScene("Win");
        }
        else if (currentScore <= -60 || currentLives == 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
