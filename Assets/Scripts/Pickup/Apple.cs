using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] private float powerUpBonusSpeed;

    private LevelGenerator _levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        _levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        _levelGenerator.ChangeChunkMoveSpeed(powerUpBonusSpeed);
    }
}
