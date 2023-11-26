// ProjectileScript.cs
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the player
        if (other.CompareTag("Player"))
        {
            // Destroy the projectile
            Destroy(gameObject);

            // You may want to add additional logic here, such as reducing player health or triggering an event
        }
    }
}
