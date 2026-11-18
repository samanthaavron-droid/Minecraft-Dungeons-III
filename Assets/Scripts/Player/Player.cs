using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    private Vector2 movementDir;
    [SerializeField] private InputActionReference moveDir;
    [SerializeField] private InputActionReference moveForward;
    [SerializeField] private float sensitivity;
    protected override void Update()
    {
        movementDir = moveDir.action.ReadValue<Vector2>();

        if (movementDir.magnitude > 0.1f)
            Rotate();
    }
    private void MovePlayer(InputAction.CallbackContext context)
    {
        
    }
    private void Rotate()
    {
        //do it later
        Vector2 input = moveDir.action.ReadValue<Vector2>();

        transform.forward = input;       
        
    }
    private void OnEnable()
    {
        moveForward.action.Enable();
        moveDir.action.Enable();

        moveForward.action.performed += MovePlayer;
    }
    private void OnDisable()
    {
        moveForward.action.Disable();
        moveForward.action.Disable();

        moveForward.action.performed -= MovePlayer;
    }
}
