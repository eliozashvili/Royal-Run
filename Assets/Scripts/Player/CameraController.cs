using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem speedUpParticles;

    [Header("Camera Settings")]
    [SerializeField] private float minFOV;
    [SerializeField] private float maxFOV;
    [SerializeField] private float zoomDuration;
    [SerializeField] private float zoomSpeedModifier;

    private Coroutine _zoomCoroutine;


    private CinemachineCamera _camera;

    private void Awake()
    {
        _camera = GetComponent<CinemachineCamera>();
    }

    public void ChangeCameraFOV(float speedAmount)
    {
        if (_zoomCoroutine != null)
            StopCoroutine(_zoomCoroutine);

        _zoomCoroutine = StartCoroutine(CameraFOVChange(speedAmount));

        if (speedAmount > 0)
            speedUpParticles.Play();
    }

    private IEnumerator CameraFOVChange(float speedAmount)
    {
        var startFOV = _camera.Lens.FieldOfView;
        var targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeedModifier, minFOV, maxFOV);

        var elapsedTime = 0f;
        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;

            _camera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, elapsedTime / zoomDuration);

            yield return null;
        }

        _camera.Lens.FieldOfView = targetFOV;
        _zoomCoroutine = null;
    }
}
