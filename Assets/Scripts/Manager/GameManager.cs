using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maxPlayerDistance;
    [SerializeField] private float minCameraZoom;
    [SerializeField] private float maxCameraZoom;

    private bool getInput = true;
    
    public Camera MainCamera { get => mainCamera; }
    public bool GetInput { get => getInput; }
    
    private Vector2 GetPlayerCenterPos(Transform a, Transform b)
    {
        float x = (a.position.x + b.position.x) / 2;
        float y = (a.position.y + b.position.y) / 2;
        return new Vector2(x, y);
    }

    private float GetPlayerDistance(Transform a, Transform b)
    {
        return Vector2.Distance(a.transform.position, b.transform.position);
    }

    public void CameraMovement(Transform a, Transform b)
    {
        float playerDistance = GetPlayerDistance(a,b);
        Vector3 playerCenter = GetPlayerCenterPos(a,b);

        Vector3 targetPos = new Vector3(playerCenter.x, playerCenter.y, mainCamera.transform.position.z);

        float lerpIndex = Mathf.InverseLerp(0f, maxPlayerDistance, playerDistance);
        float targetZoom = Mathf.Lerp(minCameraZoom, maxCameraZoom,lerpIndex);

        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPos, zoomSpeed * Time.deltaTime);
    }
}
