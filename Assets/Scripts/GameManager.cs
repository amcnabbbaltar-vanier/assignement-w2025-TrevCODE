using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int Score = 0;
    public TextMeshProUGUI scoreText;
     public TextMeshProUGUI timerText;

    private float timer = 0f;
    private bool isTimerRunning = true;

    public static GameManager Instance {get; private set;}

    private void Start()
    {
        FindScoreText(); // Find the score UI at the start
        FindTimerText();
        UpdateScoreUI();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "EndScreen") 
        {
            timer += Time.deltaTime;  
        }

         
        UpdateTimerUI();  
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindScoreText(); 
        UpdateScoreUI();
        UpdateTimerUI();
        FindTimerText();
        FindUIElements();
    }
        private void FindUIElements()
    {
        GameObject scoreObj = GameObject.Find("ScoreText");  // Find the ScoreText GameObject
        GameObject timerObj = GameObject.Find("TimerText");  // Find the TimerText GameObject

        if (scoreObj != null)
            scoreText = scoreObj.GetComponent<TextMeshProUGUI>();

        if (timerObj != null)
            timerText = timerObj.GetComponent<TextMeshProUGUI>();
    }

    private void FindScoreText()
    {
        GameObject textObj = GameObject.Find("ScoreText"); // Find the ScoreText in the scene
        if (textObj != null)
        {
            scoreText = textObj.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("ScoreText not found in the new scene.");
        }
    }
        private void FindTimerText()
    {
        GameObject textObj = GameObject.Find("TimerText"); 
        if (textObj != null)
        {
            timerText = textObj.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("TimerText not found in the new scene.");
        }
    }
private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameManager Loaded: " + gameObject.name);
    }
    else
    {
        Debug.Log("Duplicate GameManager Destroyed");
        Destroy(gameObject);
    }
}

    public void IncrementScore() {
        Score += 50;
        Debug.Log("Score :" + Score);
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + Score.ToString(); // Update text with current score
    }
    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            // Calculate hours, minutes, and seconds
            int hours = Mathf.FloorToInt(timer / 3600);  
            int minutes = Mathf.FloorToInt((timer % 3600) / 60);  
            int seconds = Mathf.FloorToInt(timer % 60);  

           
            timerText.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }

    }
    public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindUIAfterSceneLoad();
        if (SceneManager.GetActiveScene().Equals("EndScreen") ) 
        {
            isTimerRunning = false;
        }
    }
    private void FindUIAfterSceneLoad()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>(); // Find new ScoreText in the new scene
        UpdateScoreUI(); 
    }
}
