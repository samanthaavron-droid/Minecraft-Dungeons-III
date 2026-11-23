using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private StatsTemplate statsTemplate;
    protected StatsRuntime statsRuntime;
    void Start()
    {
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
    private void OnCollisionStay(Collision collision)
    {
        Entity entity = collision.collider.GetComponent<Entity>();
        if (entity != null)
        {
            if (statsRuntime.cooldownTimer > 0) return;

            entity.TakeDamage(statsRuntime.damage);
            statsRuntime.cooldownTimer = statsRuntime.cooldown;
        }
    }
}
