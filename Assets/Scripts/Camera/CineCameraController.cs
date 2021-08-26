using UnityEngine;
using Cinemachine;

public class CineCameraController : MonoBehaviour
{
    [Header("Camera settings")]
    [SerializeField, Tooltip("Reference Free Look camera")] private CinemachineFreeLook flCamera = default;
    [SerializeField] private MouseButtons cameraRotateButton = MouseButtons.Middle;
    [SerializeField, Tooltip("Camera zoom speed"), Range(0,60f)] private float zoomSpeed = 5f;

    private void LateUpdate()
    {
        CameraZoom();
        CameraRotate();
    }

    private void CameraZoom()
    {
        float offset = Input.GetAxis("Mouse ScrollWheel");

        if(offset!=0)
            flCamera.m_YAxis.Value += offset * Time.deltaTime * zoomSpeed;
    }

    private void CameraRotate()
    {
        float offset = Input.GetAxis("Mouse X");

        if(Input.GetMouseButton((int)cameraRotateButton) && offset != 0) //if mouse middle button pressed and mouse moving
            flCamera.m_XAxis.m_InputAxisValue = offset;
        else
            flCamera.m_XAxis.m_InputAxisValue = 0;
    }
}
