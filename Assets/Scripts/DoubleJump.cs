using UnityEngine;
using System.Collections;

public class DoubleJump : MonoBehaviour
{
    public float powerUpDuration = 60f; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            CharacterMovement player = other.GetComponent<CharacterMovement>();

            if (player != null)
            {
                StartCoroutine(ActivateDoubleJump(player));
            }

            gameObject.SetActive(false); 
        }
    }

    private IEnumerator ActivateDoubleJump(CharacterMovement player)
    {
        player.EnableDoubleJump(true); // Enable double jump
        Renderer playerRenderer = player.GetComponent<Renderer>();


        yield return new WaitForSeconds(powerUpDuration); // Wait 60 seconds

        player.EnableDoubleJump(false); // Disable double jump after time is up
    }
}
