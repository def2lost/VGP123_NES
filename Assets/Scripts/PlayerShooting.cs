using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;

    private GameObject currentBullet;

    public void ShootFromAnimationEvent() => Shoot();

    void Shoot()
    {
        currentBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        float direction = transform.localScale.x < 0 ? -1f : 1f;
        rb.AddForce(Vector2.right * direction * bulletForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(currentBullet);
        }
    }
}