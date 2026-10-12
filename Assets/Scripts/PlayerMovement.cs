using Unity.VisualScripting;
using UnityEngine;
// 1. Include the new Input System namespace
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Cache the Rigidbody component to avoid calling GetComponent in Update
    private Rigidbody rb;
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] float jumpForce = 5f;

    void Start()
    {
        // Get the Rigidbody component once when the game starts
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 2. Use the new Input System syntax for the spacebar check
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }

        if (Keyboard.current != null && Keyboard.current.wKey.isPressed)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, movementSpeed);
        }

        if (Keyboard.current != null && Keyboard.current.aKey.isPressed)
        {
            rb.linearVelocity = new Vector3(-movementSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        }

        if (Keyboard.current != null && Keyboard.current.dKey.isPressed)
        {
            rb.linearVelocity = new Vector3(movementSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        }

        if (Keyboard.current != null && Keyboard.current.sKey.isPressed)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, -movementSpeed);
        }
    }
}
