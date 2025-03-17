using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;

    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (pauseMenuPanel == null) {
            pauseMenuPanel = GameObject.Find("PauseMenuPanel")?.GetComponent<GameObject>();
        } 
        else 
        {
            pauseMenuPanel.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused) {
                pauseMenuPanel.SetActive(true);
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }
    }
       public void PauseGame()  {
        pauseMenuPanel.SetActive(true);

        Time.timeScale = 0f;

        isPaused = true;
       } 

       public void ResumeGame() {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
       }
       public void RestartLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }
       public void QuitGame() {
        Application.Quit();
       }
}

