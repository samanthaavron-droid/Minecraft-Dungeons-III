using UnityEngine;
using UnityEngine.InputSystem;

public class Entity : MonoBehaviour
{
    [SerializeField] private StatsTemplate statsTemplate;
    protected StatsRuntime statsRuntime;
    public StatsRuntime GetStats { get { return statsRuntime; } }
    void Start()
    {
        if (statsTemplate != null)
            statsRuntime = new(statsTemplate);
    }

    protected virtual void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        statsRuntime.hp -= damage;
        if (statsRuntime.hp <= 0)
        {
            Die();
        }
    }
    protected virtual void Move() { }
    protected virtual void Roll() { }
    protected virtual void Attack() { }
    protected virtual void Die() { }
}
