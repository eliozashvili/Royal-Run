using UnityEngine;

public class Oscillation : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private float _rotationY;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _movementFactor;

    private void Start()
    {
        _startPosition = transform.localPosition;
        _endPosition = transform.localPosition + movementVector;
    }

    private void Update()
    {
        _movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.localPosition = Vector3.Lerp(_startPosition, _endPosition, _movementFactor);

        _rotationY += Time.deltaTime * rotationSpeed;
        transform.localRotation = Quaternion.Euler(0f, _rotationY, 0f);
    }
}
