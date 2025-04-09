using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public int totalScore;
    public int liveCount;

    public Text scoreText;
    public Text liveText;

    public GameObject gameOverObject;
    public GameObject perdeVidabject;

    public static GameControler instance;

    void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("TotalScore"))
            totalScore = PlayerPrefs.GetInt("TotalScore");

        if (PlayerPrefs.HasKey("LiveCount"))
            liveCount = PlayerPrefs.GetInt("LiveCount");
    }

    void Start()
    {
        updateScoreText();
        updateLiveText();
    }

    public void updateScoreText()
    {
        scoreText.text = totalScore.ToString();
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.Save();
    }

    public void updateLiveText()
    {
        liveText.text = liveCount.ToString();
        PlayerPrefs.SetInt("LiveCount", liveCount);
        PlayerPrefs.Save();
    }

    public void gameOver()
    {
        liveCount--;
        updateLiveText();

        if (liveCount <= 0)
        {
            PlayerPrefs.DeleteKey("TotalScore");
            PlayerPrefs.DeleteKey("LiveCount");
            PlayerPrefs.Save();

            perdeVidabject.SetActive(false);
            gameOverObject.SetActive(true);
            return;
        }

        gameOverObject.SetActive(false);
        perdeVidabject.SetActive(true);
        
        Invoke("restart2", 3f);
    }

    public void restart2()
    {
        SceneManager.LoadScene("fase_1");
    }

    public void restart(string levelName)
    {
        Debug.Log(levelName);
        SceneManager.LoadScene(levelName);
    }
}
