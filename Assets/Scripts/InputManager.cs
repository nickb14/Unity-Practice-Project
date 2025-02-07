using UnityEngine;

public class InputManager : MonoBehaviour
{
    // private Vector2 _direction;

    private void Update()
    {
        EventManager.OnInput(new Vector3(0f, 0f, 0f));
        if (Input.GetKey("w"))
        {
            EventManager.OnInput(new Vector3(0f, 1f, 0f));
        }
        if (Input.GetKey("a"))
        {
            EventManager.OnInput(new Vector3(-1f, 0f, 0f));
        }
        if (Input.GetKey("s"))
        {
            EventManager.OnInput(new Vector3(0f, -1f, 0f));
        }
        if (Input.GetKey("d"))
        {
            EventManager.OnInput(new Vector3(1f, 0f, 0f));
        }
    }
}
