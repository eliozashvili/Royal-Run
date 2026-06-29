using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class Rock : MonoBehaviour
{
    [SerializeField] private ParticleSystem collisionParticles;
    [SerializeField] private AudioSource rockBounceSound;
    [SerializeField] private float shakeModifier;
    [SerializeField] private float collisionCooldown;

    private CinemachineImpulseSource _impulseSource;
    private Camera _camera;

    private float _cooldownTimer;

    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Start()
    {
        _camera =  Camera.main;
    }

    private void Update()
    {
        _cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_cooldownTimer < collisionCooldown) return;

        FireImpulse();
        CollisionFX(collision);

        _cooldownTimer = 0f;
    }

    private void FireImpulse()
    {
        var distance = Vector3.Distance(transform.position, _camera.transform.position);
        var shakeIntensity = (1f / distance) * shakeModifier;

        shakeIntensity = Mathf.Min(shakeIntensity, 1f);

        _impulseSource.GenerateImpulse(shakeIntensity);
    }

    private void CollisionFX(Collision collision)
    {
        var contactPoint = collision.contacts[0];

        collisionParticles.transform.position = contactPoint.point;

        collisionParticles.Play();
        rockBounceSound.Play();
    }
}
