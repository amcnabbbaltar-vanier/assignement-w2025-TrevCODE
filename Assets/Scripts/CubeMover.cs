using UnityEngine;
using System.Collections;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private float moveHeight = 2f; // How high the cube moves up
    [SerializeField] private float moveDuration = 4f; // How long before it changes direction

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingUp = true;

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveHeight;
        StartCoroutine(MoveCube());
    }

    private IEnumerator MoveCube()
    {
        while (true)
        {
            float elapsedTime = 0f;
            Vector3 start = transform.position;
            Vector3 end = movingUp ? targetPos : startPos;

            while (elapsedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(start, end, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = end;
            movingUp = !movingUp; // Toggle movement direction
        }
    }
}
