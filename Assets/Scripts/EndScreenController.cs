using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
   

    void Start()
    {
      
        if(GameManager.Instance) {
            scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

 
    void Update()
    {
        
    }
}
