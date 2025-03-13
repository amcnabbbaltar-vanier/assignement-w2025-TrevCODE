using UnityEngine;

public class ScorePickupController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
         {
            GameManager.Instance.IncrementScore(); 
            Destroy(gameObject); 
        }
    }
}

