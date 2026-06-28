using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private float shakeModifier;

    private CinemachineImpulseSource _impulseSource;
    private Camera _camera;

    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Start()
    {
        _camera =  Camera.main;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var distance = Vector3.Distance(transform.position, _camera.transform.position);
        var shakeIntensity = (1f / distance) * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);

        _impulseSource.GenerateImpulse(shakeIntensity);
    }
}
