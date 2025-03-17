using UnityEngine;
using System.Collections;

public class BlinkingCube : MonoBehaviour
{
    [SerializeField] private float disappearTime = 5f; // Time before disappearing
    [SerializeField] private float reappearTime = 2f;  // Time before reappearing

    private Renderer cubeRenderer; 
    private Collider cubeCollider;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>(); 
        cubeCollider = GetComponent<Collider>(); 
        StartCoroutine(DisappearAndReappear());
    }

    private IEnumerator DisappearAndReappear()
    {
        while (true) // Infinite loop to keep repeating
        {
            yield return new WaitForSeconds(disappearTime); 
            cubeRenderer.enabled = false; // Hide the cube
            cubeCollider.enabled = false; // Disable collisions

            yield return new WaitForSeconds(reappearTime); 
            cubeRenderer.enabled = true;  // Show the cube
            cubeCollider.enabled = true;  // Enable collisions
        }
    }
}
