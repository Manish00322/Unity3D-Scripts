using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f; // The speed at which the player moves
    public int maxHealth = 100; // The maximum health of the player

    private int currentHealth; // The current health of the player

    private CharacterController controller; // Reference to the CharacterController component

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);
        moveDirection.Normalize();

        // Move the player
        controller.Move(moveDirection * movementSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement game over or respawn logic here
        Debug.Log("Player has died!");
    }
}
