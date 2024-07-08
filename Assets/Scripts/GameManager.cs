using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //UI
    public TextMeshProUGUI timerText;
    public bool timeIsRunning;
    public float timeRemaining = 0f;
    private float minutes;
    private float seconds;
    //Lose Scene
    [SerializeField] TextMeshProUGUI loseText;
    [SerializeField] GameObject loseScreen;
    void Start()
    {
        Time.timeScale = 1f;
        Instance = this;
        timeIsRunning = true;
        loseScreen.SetActive(false);
    }
    void Update()
    {
        if (timeIsRunning)
        {
            timeRemaining += Time.deltaTime;
            DisplayTime(timeRemaining);
        }
    }
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public IEnumerator Lose()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
        if (minutes > 0)
        {
            loseText.text = "Congratulations! You survived for " + minutes + ":" + seconds.ToString("00") + " seconds.";
        }
        else
        {
            loseText.text = "Congratulations! You survived for " + seconds + " seconds.";
        }
    }
    public void RestratLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
