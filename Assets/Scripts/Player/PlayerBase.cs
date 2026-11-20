using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : Entity
{
    [SerializeField] private InputActionReference moveDir;
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference attack;
    protected override void Update()
    {
        if (statsRuntime == null) return;

        base.Update();
    }
    protected override void FixedUpdate()
    {
        if (statsRuntime == null) return;

        base.FixedUpdate();

        Vector2 input = moveDir.action.ReadValue<Vector2>();
        Move(input);
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (statsRuntime.isGrounded == true)
        {
            rb.AddForce(Vector3.up * statsRuntime.jumpHeight, ForceMode.Impulse);
        }
    }
    private void AttackTrigger(InputAction.CallbackContext context)
    {
        base.Attack();
    }
    private void OnEnable()
    {
        moveDir.action.Enable();
        jump.action.Enable();
        attack.action.Enable();

        jump.action.performed += Jump;
        attack.action.performed += AttackTrigger;
    }
    private void OnDisable()
    {
        moveDir.action.Disable();
        jump.action.Disable();

        jump.action.canceled -= Jump;
        attack.action.canceled -= AttackTrigger;
    }
}
