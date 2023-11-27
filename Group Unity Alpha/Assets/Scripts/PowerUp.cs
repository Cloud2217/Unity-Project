using UnityEngine;

public class SpeedUpPowerUp : MonoBehaviour
{
    public float speedMultiplier = 2f; // Adjust this value based on how much you want to increase the speed
    public float powerUpDuration = 5f; // Adjust this value based on how long the power-up should last

    private float originalSpeed;
    private bool isPowerUpActive = false;

    private void Start()
    {
        // Store the original speed of the object
        originalSpeed = GetComponent<Rigidbody>().velocity.magnitude;
    }

    private void Update()
    {
        if (isPowerUpActive)
        {
            // Decrease the power-up duration over time
            powerUpDuration -= Time.deltaTime;

            if (powerUpDuration <= 0f)
            {
                // Power-up duration has expired, reset speed
                ResetSpeed();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            // Power-up collected
            ActivatePowerUp();
            Destroy(other.gameObject); // Assuming the power-up is a GameObject with a collider
        }
    }

    private void ActivatePowerUp()
    {
        Debug.Log("Power-up activated!");

        // Increase the speed
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity *= speedMultiplier;
        isPowerUpActive = true;

        // You can add visual/audio effects here if needed
    }

    private void ResetSpeed()
    {
        // Reset the speed to the original speed
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = rb.velocity.normalized * originalSpeed;
        isPowerUpActive = false;
        Debug.Log("Power-up deactivated!");
    }
}
