using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.Input += Move;
    }

    private void OnDisable()    
    {
        EventManager.Input -= Move;
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime;
    }
}
