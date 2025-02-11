using System.Globalization;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    public int initialTargets = 5;

    private void Awake()
    {
        Target.onTargetHit += spawnTarget;
    }

    void Start()
    {
        for (int i = 0; i < initialTargets; i++)
            spawnTarget();
    }

    private void Onable()
    {
        Target.onTargetHit += spawnTarget;
    }

    private void OnDisable()
    {
        Target.onTargetHit -= spawnTarget;
    }

    void spawnTarget()
    {
        Vector2 newPos = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        Instantiate(target, newPos, Quaternion.identity);
    }
}
