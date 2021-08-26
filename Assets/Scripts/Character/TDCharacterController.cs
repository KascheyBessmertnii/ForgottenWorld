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
        Utilits.mainCamera = mCamera = Camera.main;
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
            Utilits.GetSceneClickPoint(interractLayer, 100f).transform?.GetComponent<IInterractable>().Interract();
        }
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown((int)moveButton) && !GameStates.inventoryOpen)
        {
            MoveTo(Utilits.GetSceneClickPoint(movableLayer, 100f).point, speed);
        }
    }
}
