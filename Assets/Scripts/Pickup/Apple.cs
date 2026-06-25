using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] private float powerUpBonusSpeed;

    private LevelGenerator _levelGenerator;

    private void Start()
    {
        _levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        _levelGenerator.ChangeChunkMoveSpeed(powerUpBonusSpeed);

        Destroy(gameObject);
    }
}
