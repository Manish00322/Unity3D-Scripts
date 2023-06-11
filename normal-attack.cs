using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    public Transform player; // The player object
    public float movementSpeed = 3f; // The speed at which the enemy moves towards the player
    public int attackDamage = 10; // The amount of damage the enemy inflicts on the player per attack

    private int playerHealth = 100; // Initial health of the player

    private void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player is not assigned to the enemy!");
            return;
        }

        // Move towards the player
        Vector3 playerDirection = player.position - transform.position;
        transform.Translate(playerDirection.normalized * movementSpeed * Time.deltaTime, Space.World);

        // Rotate towards the player
        Quaternion playerRotation = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, Time.deltaTime);

        // Attack the player
        if (playerDirection.magnitude <= 1f) // Adjust the attack range as needed
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        // Inflict damage on the player
        playerHealth -= attackDamage;

        Debug.Log("Enemy attacked the player. Player health: " + playerHealth);

        // Check if player health is zero or below
        if (playerHealth <= 0)
        {
            // Player defeated, implement your game over logic here
            Debug.Log("Player has been defeated!");
        }
    }
}
