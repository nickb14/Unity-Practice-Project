using UnityEngine;

public class Projectile : MonoBehaviour
{
    //destroys itself when it hits any trigger/collider
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
