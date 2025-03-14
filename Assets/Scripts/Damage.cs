using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damageInterval = 3f; // Damage every 3 seconds
    private bool playerOnFloor = false; // Track player presence

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure Player has the "Player" tag
        {
            playerOnFloor = true;
            StartCoroutine(DamagePlayer(other.GetComponent<PlayerHealth>()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnFloor = false; // Stop damage when the player leaves
        }
    }

    private IEnumerator DamagePlayer(PlayerHealth playerHealth)
    {
        while (playerOnFloor && playerHealth != null)
        {
            Debug.Log("Player is taking damage from the floor!");
            playerHealth.TakeDamage();
            yield return new WaitForSeconds(damageInterval); // Wait 3 seconds before next hit
        }
    }
}
