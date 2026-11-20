using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    private List<StatsRuntime> weapons;
    private Entity player;
    [SerializeField] private StatsTemplate statsTemplate;
    private StatsRuntime statsRuntime; //healing
    [SerializeField] private InputActionReference heal;
    void Start()
    {
        player = GetComponent<Entity>();

        if (statsTemplate != null)
            statsRuntime = new(statsTemplate);
    }

    void Update()
    {
        if (statsRuntime.cooldownTimer > 0)
        {
            statsRuntime.cooldownTimer -= Time.deltaTime;
        }
    }
    private void Heal(InputAction.CallbackContext context)
    {
        if (statsRuntime == null || statsRuntime.cooldownTimer > 0) return; 

        player.TakeDamage(statsRuntime.heal);

        statsRuntime.cooldownTimer = statsRuntime.cooldown;
    }
    public void AddItem(StatsRuntime itemStats)
    {
        if (itemStats.isWeapon == true)
        {
            weapons.Add(itemStats);
        }
        else
        {
            player.TakeDamage(-itemStats.heal);
            player.AddScore(itemStats.coins);
        }
    }
    public StatsRuntime GetWeapon(int index)
    {
        if (weapons[index] != null)
            return weapons[index];
        else
            return null;
    }
    private void OnEnable()
    {
        heal.action.Enable();

        heal.action.performed += Heal;
    }
    private void OnDisable()
    {
        heal.action.Disable();

        heal.action.performed -= Heal;
    }
}
