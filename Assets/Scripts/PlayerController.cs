using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public GameObject projectile; 
    public float fireSpeed = 5f;

    private Vector2 direction = Vector2.zero;
    private Vector2 position = Vector2.zero;
    private Vector2 rotation = Vector2.zero;
    private float angle = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
        rb.linearVelocity = direction * moveSpeed;
    }

    void OnLook(InputValue value)
    {
        position = value.Get<Vector2>();
        position = Camera.main.ScreenToWorldPoint(position);
    }

    void OnAttack(InputValue value)
    {
        Vector2 newPos = rb.position + (Vector2)Vector3.Normalize(rotation) * 0.8f;
        GameObject p = Instantiate(projectile, newPos, Quaternion.identity);

        Rigidbody2D p_rb = p.GetComponent<Rigidbody2D>();
        p_rb.linearVelocity = Vector3.Normalize(rotation) * fireSpeed;
    }

    void Update()
    {
        rotation = position - rb.position;

        angle = Mathf.Atan(rotation.y / rotation.x) * Mathf.Rad2Deg - 90;
        if (rotation.x < 0)
            angle += 180;
        rb.rotation = angle;
    }
}
