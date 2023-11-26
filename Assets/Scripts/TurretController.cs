using System.Collections;
using System.Collections.Generic;
// TurretController.cs
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform player;
    public float detectionDistance = 5f;
    public GameObject projectilePrefab;
    public float fireCooldown = 1f; // Adjust this value as needed
    private float lastFireTime;

    void Update()
    {
        // Check if the player is within the detection distance
        if (Vector2.Distance(transform.position, player.position) <= detectionDistance)
        {
            // Calculate the direction to the player
            Vector2 direction = player.position - transform.position;

            // Flip the turret based on the player's position
            if (direction.x < 0)
            {
                // Player is on the left, flip the turret to face left
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                // Player is on the right, flip the turret to face right
                transform.localScale = new Vector3(1, 1, 1);
            }

            // Check if enough time has passed since the last shot
            if (Time.time - lastFireTime >= fireCooldown)
            {
                // Fire projectile
                FireProjectile();

                // Update the last fire time
                lastFireTime = Time.time;
            }
        }
    }

    void FireProjectile()
    {
        // Calculate the position to instantiate the projectile (offset it slightly from the turret)
        Vector3 spawnPosition = transform.position + transform.right * 0.5f;

        // Instantiate the projectile at the calculated position
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Ignore collisions with friendlies (assuming they have a "Friendly" tag)
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        // Add force to the projectile in the direction of the player
        Vector2 direction = (player.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().AddForce(direction * 10f, ForceMode2D.Impulse);
    }
}
