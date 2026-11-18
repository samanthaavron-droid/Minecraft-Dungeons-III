using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private StatsTemplate statsTemplate;
    private StatsRuntime statsRuntime;
    public StatsRuntime GetStats { get { return statsRuntime; } }
    void Start()
    {
        if (statsTemplate != null)
            statsRuntime = new(statsTemplate);
    }

    void Update()
    {
        
    }
    void TakeDamage()
    {

    }
}
