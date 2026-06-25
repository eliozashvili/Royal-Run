using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    // TODO: Bounce PICKUPS on collision
    private void OnTriggerEnter(Collider other)
    {
        const string playerTag = "Player";

        if (other.CompareTag(playerTag))
        {
            OnPickup();
        }
    }

    protected abstract void OnPickup();
}
