using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : Entity
{
    [SerializeField] private InputActionReference moveDir;
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference attack;
    [SerializeField] private TextMeshProUGUI scoreText;
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
    public void AddScore(int score)
    {
        statsRuntime.coins += score;

        if (scoreText != null)
        {
            scoreText.text = statsRuntime.coins.ToString("D3");
        }
    }
    private void AttackTrigger(InputAction.CallbackContext context)
    {
        base.Attack();
    }
    protected override void Die()
    {
        //temporary script that exits the game upon death
        //gamestate variable = false
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
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
