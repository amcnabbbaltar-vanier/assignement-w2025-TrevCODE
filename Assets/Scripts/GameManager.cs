using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score = 0;

    public static GameManager Instance {get; private set;}

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        
    }

    public void IncrementScore() {
        Score += 50;
        Debug.Log("Score :" + Score);
    }
    public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
