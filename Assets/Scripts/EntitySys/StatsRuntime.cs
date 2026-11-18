using UnityEngine;

public class StatsRuntime
{
    public float hp { get; set; }
    public float maxhp { get; set; }
    public float jumpHeight { get; set; }
    public float scanRadius { get; set; }
    public float damage { get; set; }
    public float attackRadius { get; set; }
    public bool canMove { get; set; }
    public float cooldown { get; set;  }
    public StatsRuntime(StatsTemplate s)
    {
        hp = s.hp;
        maxhp = s.hp;
        jumpHeight = s.jumpHeight;
        scanRadius = s.scanRadius;
        damage = s.damage;
        attackRadius = s.attackRadius;
        canMove = s.canMove;
        cooldown = s.cooldown;
    }
}
