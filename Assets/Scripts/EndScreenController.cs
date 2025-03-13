using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        if(GameManager.Instance) {
            scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
