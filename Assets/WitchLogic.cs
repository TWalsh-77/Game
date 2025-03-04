using UnityEngine;
using System.Collections;

public class WitchLogic : MonoBehaviour
{
    public GameObject circlePrefab;   // Prefab for the circle to be shot
    public float shootForce = 10f;    // Speed of the projectile
    public Transform shootPoint;      // The point from where the circle will be shot
    public float shootInterval = 1f;  // Time interval between each shot

    private void Start()
    {
        // Start the shooting coroutine
        StartCoroutine(ShootAutomatically());
    }

    // Coroutine to shoot circles automatically at intervals
    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator ShootAutomatically()
    {
        while (true)  // Keep shooting indefinitely
        {
            ShootCircle();  // Shoot the circle
            yield return new WaitForSeconds(shootInterval);  // Wait for the next shot
        }
    }

    // Function to shoot a circle straight
    private void ShootCircle()
    {
        // Instantiate the circle prefab at the shootPoint position with no rotation
        GameObject circle = Instantiate(circlePrefab, shootPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the circle
        Rigidbody2D rb = circle.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Shoot straight in the positive X direction (right)
            rb.linearVelocity = new Vector2(-shootForce, 0f);  // Set the velocity to shoot straight to the right
        }
    }
}
