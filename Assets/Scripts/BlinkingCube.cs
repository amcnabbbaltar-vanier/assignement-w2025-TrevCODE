using UnityEngine;
using System.Collections;

public class BlinkingCube : MonoBehaviour
{
    [SerializeField] private float disappearTime = 5f; // Time before disappearing
    [SerializeField] private float reappearTime = 2f;  // Time before reappearing

    private Renderer cubeRenderer; // Reference to the cube's Renderer
    private Collider cubeCollider; // Reference to the cube's Collider

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>(); // Get the Renderer component
        cubeCollider = GetComponent<Collider>(); // Get the Collider component
        StartCoroutine(DisappearAndReappear());
    }

    private IEnumerator DisappearAndReappear()
    {
        while (true) // Infinite loop to keep repeating
        {
            yield return new WaitForSeconds(disappearTime); // Wait before disappearing
            cubeRenderer.enabled = false; // Hide the cube
            cubeCollider.enabled = false; // Disable collisions

            yield return new WaitForSeconds(reappearTime); // Wait before reappearing
            cubeRenderer.enabled = true;  // Show the cube
            cubeCollider.enabled = true;  // Enable collisions
        }
    }
}
