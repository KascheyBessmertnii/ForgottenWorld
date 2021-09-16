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
    private bool crouch = false;

    private void Awake()
    {
        Utilits.mainCamera = mCamera = Camera.main;
    }

    private void Update()
    {
        Move();
        MouseAction.Interract((int)interractButton, interractLayer);
        Crouch();
        BattleMode();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown((int)moveButton) && !GameStates.InventoryOpen)
        {
            MoveTo(MouseAction.Move(movableLayer), speed);
        }
    }

    private void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            animator.Crouching(crouch = !crouch);
        }       
    }

    private void BattleMode()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            animator.ToBattleMode(!GameStates.BattleMode);
            GameStates.BattleMode = !GameStates.BattleMode;
        }
    }
}
