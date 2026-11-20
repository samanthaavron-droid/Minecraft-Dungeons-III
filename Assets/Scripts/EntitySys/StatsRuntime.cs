using UnityEngine;

public class StatsRuntime
{
    public float hp { get; set; }
    public float maxhp { get; set; }
    public float jumpHeight { get; set; }
    public float maxSpeed { get; set; }
    public float currentSpeed { get; set; }
    public float accerelation { get; set; }
    public float deceleration { get; set; }
    public Vector3 movementDir { get; set; }
    public bool canMove { get; set; }
    public bool isGrounded { get; set; }
    public float distanceToGround { get; set; }

    public float scanRadius { get; set; }
    public float goForAttackRadius { get; set; }
    public Vector3 target {  get; set; }


    public float damage { get; set; }
    public float attackRadius { get; set; }
    public float cooldown { get; set;  }
    public float cooldownTimer { get; set; }

    public float heal { get; set; }
    public float coins {  get; set; }
    public bool isWeapon { get; set; }
    public string itemName {  get; set; }
    public StatsRuntime(StatsTemplate s) //creates the active stats from template
    {
        hp = s.hp;
        maxhp = s.hp;
        jumpHeight = s.jumpHeight;
        scanRadius = s.scanRadius;
        maxSpeed = s.maxSpeed;
        damage = s.damage;
        attackRadius = s.attackRadius;
        canMove = s.canMove;
        cooldown = s.cooldown;
        cooldownTimer = s.cooldown;
        accerelation = s.acceleration;
        deceleration = s.deceleration;
        goForAttackRadius = s.goForAttackRadius;
        heal = s.heal;
        coins = s.coins;
        isWeapon = s.isWeapon;
        itemName = s.itemName;
    }
}
