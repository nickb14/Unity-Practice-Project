using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    public int initialTargets = 5;

    void Awake()
    {
        Target.onTargetHit += spawnTarget;
    }

    //initial targets
    void Start()
    {
        for (int i = 0; i < initialTargets; i++)
            spawnTarget();
    }

    void Onable()
    {
        Target.onTargetHit += spawnTarget;
    }

    void OnDisable()
    {
        Target.onTargetHit -= spawnTarget;
    }

    //functions subsribed to onTargetHit event, spawns new target ever time one is hit
    private void spawnTarget()
    {
        Vector2 newPos = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        Instantiate(target, newPos, Quaternion.identity);
    }
}
