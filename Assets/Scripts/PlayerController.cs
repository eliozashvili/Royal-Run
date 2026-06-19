using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;

    private Rigidbody _rigidbody;
    private Vector2 _movement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveAndClampMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    private void MoveAndClampMovement()
    {
        // Find step of movement
        var movementStep = new Vector3(_movement.x, 0, _movement.y) * (Time.fixedDeltaTime * moveSpeed);
        // Apply step to RigidBody position
        var targetStep = _rigidbody.position + movementStep;
        // Clamp step so Player won't walk-off screen
        targetStep.x = Mathf.Clamp(targetStep.x, -xRange, xRange);
        targetStep.z = Mathf.Clamp(targetStep.z, -zRange, zRange);

        _rigidbody.MovePosition(targetStep);
    }
}
