using UnityEngine;

public class StatsRuntime
{
    public float hp { get; set; }
    public float maxhp { get; set; }
    public float jumpHeight { get; set; }
    public float scanRadius { get; set; }
    public StatsRuntime(StatsTemplate s)
    {
        hp = s.hp;
        maxhp = s.hp;
        jumpHeight = s.jumpHeight;
        scanRadius = s.scanRadius;
    }
}
