using UnityEngine;
using System.Collections;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private float bounceHeight;
    [SerializeField] private float bounceDuration;

    private const string PlayerTag = "Player";
    private bool _isCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(PlayerTag) || _isCollected) return;

        _isCollected = true;

        FindAnyObjectByType<Collider>().enabled = false;
        StartCoroutine(BounceCoinOnPickUp());
        OnPickup();
    }

    private IEnumerator BounceCoinOnPickUp()
    {
        var startPos = transform.position;
        var targetPos = startPos + Vector3.up * bounceHeight;

        var elapsedTime = 0f;
        while (elapsedTime  < bounceDuration)
        {
            elapsedTime += Time.deltaTime;

            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / bounceDuration);

            yield return null;
        }

        Destroy(gameObject);
    }

    protected abstract void OnPickup();
}
