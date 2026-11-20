using UnityEngine;
[CreateAssetMenu(fileName = "StatsTemplate", menuName = "Scriptable Objects/Stats Template")]

public class StatsTemplate : ScriptableObject
{
    [Header("Entity stats")]
    public float hp;
    public float maxSpeed;
    public float jumpHeight;
    public float scanRadius;
    public float goForAttackRadius;
    public float acceleration;
    public float deceleration;
    [Header("Weapon stats")]
    public float damage;
    public float attackRadius;
    public bool canMove;
    public float cooldown;
    [Header("Item")]
    public float heal;
    public float coins;
    public bool isWeapon;
    public string itemName;
}
