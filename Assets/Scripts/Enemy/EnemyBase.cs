using UnityEngine;

public class EnemyBase : Entity
{
    protected override void Update()
    {
        if (statsRuntime == null) return;
    }
    protected override void FixedUpdate()
    {
        if (statsRuntime == null) return;

        base.FixedUpdate();

        ScanForTarget();
    }
    private void ScanForTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, statsRuntime.scanRadius, LayerMask.GetMask("Player"));
        Vector3 target = Vector3.zero;

        if (hits.Length > 0)
        {
            float distance = Vector3.Distance(transform.position, hits[0].transform.position);
            if (distance > statsRuntime.goForAttackRadius)
            {
                Vector2 randomDir = Directions[Random.Range(0, Directions.Length)] * statsRuntime.goForAttackRadius;
                target = hits[0].transform.position + new Vector3(randomDir.x, 0, randomDir.y);
            } else if (distance <= statsRuntime.goForAttackRadius + 0.5f)
            {
                target = hits[0].transform.position;
            }
            //passing target to pathfinding
        }
    }
    private static readonly Vector2[] Directions =
    {
        Vector2.right, Vector2.left, Vector2.up, Vector2.down
    };
}
