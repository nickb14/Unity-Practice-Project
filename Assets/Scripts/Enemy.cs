using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void OnEnemyHit();
    public static event OnEnemyHit onEnemyHit;

    private bool _firstHit = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_firstHit && collision.gameObject.tag == "Projectile") {
            _firstHit = false;
            onEnemyHit?.Invoke();
            Destroy(gameObject);
        }
    }
}
