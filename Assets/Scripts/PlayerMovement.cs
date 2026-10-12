using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float acceleration = 30f;   // how fast you reach full speed
    [SerializeField] float deceleration = 15f;   // lower = longer slide
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        float x = 0f;
        float z = 0f;
        if (kb.dKey.isPressed) x += 1f;
        if (kb.aKey.isPressed) x -= 1f;
        if (kb.wKey.isPressed) z += 1f;
        if (kb.sKey.isPressed) z -= 1f;

        Vector3 input = new Vector3(x, 0f, z).normalized;
        Vector3 targetVelocity = input * movementSpeed;

        // Use acceleration when a key is held, deceleration when not
        float rate = input.sqrMagnitude > 0f ? acceleration : deceleration;

        Vector3 horizontal = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        horizontal = Vector3.MoveTowards(horizontal, targetVelocity, rate * Time.deltaTime);

        rb.linearVelocity = new Vector3(horizontal.x, rb.linearVelocity.y, horizontal.z);

        if (kb.spaceKey.wasPressedThisFrame && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}