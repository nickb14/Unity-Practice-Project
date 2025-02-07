using System;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    private Vector2 direction = Vector2.zero;
    private Vector2 position = Vector2.zero;
    private Vector2 playerPos = Vector2.zero;

    // public InputSystem_Actions playerInput;
    // public InputAction move;

    // void Awake()
    // {
    //     playerInput  = new InputSystem_Actions();
    // }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // void OnEnable()
    // {
    //     // _playerControls.Enable();
    //     // move = playerInput.Player.Move;
    //     move.Enable();
    //     // move.performed += Move;
    //     // EventManager.Input += Move;
    // }

    // void OnDisable()    
    // {
    //     // _playerControls.Disable();
    //     // move.performed -= Move;
    //     move.Disable();
    //     // EventManager.Input -= Move;
    // }

    // void Update()
    // {
    //     direction = move.ReadValue<Vector2>();  
    // }

    // void FixedUpdate()
    // {
    //     rb.linearVelocity = direction * moveSpeed;
    // }



    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>(); // move these declarations otu of the functios?
        rb.linearVelocity = direction * moveSpeed;
    }

    void OnLook(InputValue value)
    {
        position = value.Get<Vector2>();
        position = Camera.main.ScreenToWorldPoint(position);
    }

    void Update()
    {
        playerPos  = position - rb.position;

        float angle = Mathf.Atan(playerPos.y / playerPos.x) * Mathf.Rad2Deg - 90;
        if (playerPos.x < 0)
            angle += 180;
        rb.rotation = angle;
    }

    // private void Move(InputAction.CallbackContext value)
    // {
    //     Vector2 direction = value.ReadValue<Vector2>();
    //     _rb.linearVelocity = direction * moveSpeed;
    // }
}
