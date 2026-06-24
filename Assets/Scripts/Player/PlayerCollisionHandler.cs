using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float collisionCooldown;

    private const string HitTrigger = "Hit";

    private float _cooldownTimer;

    private void Update()
    {
        _cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_cooldownTimer < collisionCooldown) return;

        animator.SetTrigger(HitTrigger);
        _cooldownTimer = 0f;
    }
}
