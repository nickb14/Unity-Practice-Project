using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public delegate void InputAction(Vector3 direction);

    public static event InputAction Input;

    public static void OnInput(Vector3 direction)
    {
        Input?.Invoke(direction);
    }
}
