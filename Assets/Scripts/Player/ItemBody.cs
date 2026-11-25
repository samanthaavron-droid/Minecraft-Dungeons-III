using UnityEngine;

public class ItemBody : MonoBehaviour
{
    [SerializeField] private StatsTemplate statsTemplate;
    private StatsRuntime statsRuntime;
    public StatsRuntime GetStats { get { return statsRuntime; } }
    private Rigidbody rb;
    private bool attract;
    private GameObject player;
    [SerializeField] private float attractStrength;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (statsTemplate != null)
            statsRuntime = new(statsTemplate);
    }
    void Update()
    {
        if (attract)
            AttractToPlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb.useGravity = false;
            player = other.gameObject;
            attract = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Inventory>().AddItem(statsRuntime);

            Destroy(gameObject);
        }
    }
    private void AttractToPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * attractStrength, ForceMode.Force);
    }
}
