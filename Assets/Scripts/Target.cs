using UnityEngine;
using UnityEngine.Events;
using System;

public class Target : MonoBehaviour
{
    public delegate void OnTargetHit();
    public static event OnTargetHit onTargetHit;

    private bool firstHit = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (firstHit) {
            firstHit = false;
            onTargetHit?.Invoke();
            Destroy(gameObject);
        }
    }
}
