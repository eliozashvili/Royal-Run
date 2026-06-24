using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        const string playerTag = "Player";

        if (other.CompareTag(playerTag))
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
