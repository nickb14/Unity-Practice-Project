using UnityEngine;

public class Target : MonoBehaviour
{
    public delegate void OnTargetHit();
    public static event OnTargetHit onTargetHit;

    private bool _firstHit = true;

    //brodcasts event onTargetHit, and destroys itself (any trigger)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (_firstHit) {
            _firstHit = false;
            onTargetHit?.Invoke();
            Destroy(gameObject);
        }
    }
}
