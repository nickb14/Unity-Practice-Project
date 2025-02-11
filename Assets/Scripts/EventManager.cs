using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void InputAction(Vector2 direction);
    public static event InputAction Input;

    public static void OnInput(Vector2 direction)
    {
        Input?.Invoke(direction);
    }
}
