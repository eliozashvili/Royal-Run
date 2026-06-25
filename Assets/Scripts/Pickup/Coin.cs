using UnityEngine;

public class Coin : Pickup
{
    protected override void OnPickup()
    {
        Debug.Log("You picked up a COIN");
        Destroy(gameObject);
    }
}
