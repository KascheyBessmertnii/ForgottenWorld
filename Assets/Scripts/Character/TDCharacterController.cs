using UnityEngine;

public class TDCharacterController : TDCharacterMovement
{
    [Header("Mouse button action")]
    [SerializeField] private MouseButtons moveButton = MouseButtons.Left;
    [SerializeField] private MouseButtons interractButton = MouseButtons.Right;
    [Header("Character settings")]
    [SerializeField] private float speed = 2f;
    [Header("Interactive layers")]
    [SerializeField] private LayerMask movableLayer;
    [SerializeField] private LayerMask interractLayer;

    private Camera mCamera;

    private void Awake()
    {
        mCamera = Camera.main;
    }

    private void Update()
    {
        CheckClick();
    }

    private void CheckClick()
    {
        Move();
        Interract();
    }

    private void Interract()
    {
        if (Input.GetMouseButtonDown((int)interractButton))
        {
            GetClickPoint(interractLayer, out RaycastHit hit);
            if (hit.transform != null)
            {
                hit.transform.GetComponent<IInterractable>().Get(); //Temporary action
            }
        }
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown((int)moveButton))
        {
            GetClickPoint(movableLayer, out RaycastHit hit);

            MoveTo(hit.point, speed);
        }
    }

    private void GetClickPoint(LayerMask layer, out RaycastHit hit)
    {
        hit = default;
        Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitPoint, 100f, layer))
        {
            hit = hitPoint;
        }
    }
}
