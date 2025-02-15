using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public GameObject projectile; 
    public float fireSpeed = 5f;

    private Vector2 _moveDirection = Vector2.zero;
    private Vector2 _cursorLocation = Vector2.zero;
    private Vector2 _facingDirection = Vector2.zero;
    private float _facingAngle = 0f;

    public delegate void OnPlayerDeath();
    public static event OnPlayerDeath onPlayerDeath;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //all wasd movement here
    void OnMove(InputValue value)
    {
        _moveDirection = value.Get<Vector2>();
        rb.linearVelocity = _moveDirection * moveSpeed;
    }

    //just updates cursor location
    void OnLook(InputValue value)
    {
        _cursorLocation = value.Get<Vector2>();
        _cursorLocation = Camera.main.ScreenToWorldPoint(_cursorLocation);
    }

    //spawns new projectile on attack
    void OnAttack(InputValue value)
    {
        Vector2 newPos = rb.position + (Vector2)Vector3.Normalize(_facingDirection) * 0.8f;
        GameObject p = Instantiate(projectile, newPos, Quaternion.identity);

        Rigidbody2D p_rb = p.GetComponent<Rigidbody2D>();
        p_rb.linearVelocity = Vector3.Normalize(_facingDirection) * fireSpeed;
    }

    //rotation movement here, based on cursor direction
    void Update()
    {
        _facingDirection = _cursorLocation - rb.position;

        _facingAngle = Mathf.Atan(_facingDirection.y / _facingDirection.x) * Mathf.Rad2Deg - 90;
        if (_facingDirection.x < 0)
            _facingAngle += 180;
        rb.rotation = _facingAngle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            onPlayerDeath?.Invoke();
            Debug.Log("player death");
            ////////////////////////////////// do something with player death
        }
    }
}
