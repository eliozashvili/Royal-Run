using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float collisionCooldown;
    [SerializeField] private float chunkMovementPenaltyOnCollision;

    private LevelGenerator _levelGenerator;

    private static readonly int HitTrigger = Animator.StringToHash("Hit");

    private float _cooldownTimer;

    private void Start()
    {
        _levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }

    private void Update()
    {
        _cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("You collided with - " + collision.gameObject.name);

        if (_cooldownTimer < collisionCooldown) return;

        _levelGenerator.ChangeChunkMoveSpeed(chunkMovementPenaltyOnCollision);

        animator.SetTrigger(HitTrigger);
        _cooldownTimer = 0f;
    }
}
