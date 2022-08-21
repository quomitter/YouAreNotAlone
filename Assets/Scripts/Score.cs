using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    public int playerScore;
    private int playerStartScore;
    private Scene activeScene;

    public TMP_Text scoreText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        
        activeScene = SceneManager.GetActiveScene();
        if (activeScene == SceneManager.GetSceneByBuildIndex(2))
        {
            PlayerPrefs.SetInt("playerScore", playerStartScore);
            PlayerPrefs.Save(); 
            playerStartScore = 0;
            scoreText.text = "Score: " + playerStartScore;
        }
        else
        {
            playerScore = PlayerPrefs.GetInt("playerScore");
            scoreText.text = "Score: " + playerScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerScore;
    }

    public void AddHundoPeice()
    {
        playerScore += 100;
        PlayerPrefs.SetInt("playerScore", playerScore);
        PlayerPrefs.Save();
    }
    public void AddPie()
    {
        playerScore += 1000;
        PlayerPrefs.SetInt("playerScore", playerScore);
        PlayerPrefs.Save();
    }
}
