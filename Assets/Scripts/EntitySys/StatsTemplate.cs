using UnityEngine;
[CreateAssetMenu(fileName = "StatsTemplate", menuName = "Scriptable Objects/Stats Template")]

public class StatsTemplate : ScriptableObject
{
    [Header("Entity stats")]
    public float hp;
    public float speed;
    public float jumpHeight;
    public float scanRadius;

    [Header("Weapon stats")]
    public float damage;
    public float attackRadius;
    public bool canMove;
    public float cooldown;
}
