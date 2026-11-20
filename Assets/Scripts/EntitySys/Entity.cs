using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Entity : MonoBehaviour
{
    [SerializeField] private StatsTemplate statsTemplate;
    protected StatsRuntime statsRuntime;
    public StatsRuntime GetStats { get { return statsRuntime; } }
    protected Rigidbody rb;
    protected Inventory inventory;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inventory = GetComponent<Inventory>();

        if (statsTemplate != null)
            statsRuntime = new(statsTemplate);
    }

    protected virtual void Update()
    {
        if (statsRuntime == null) return;
    }
    protected virtual void FixedUpdate()
    {
        if (statsRuntime == null) return;

        if (Physics.Raycast(transform.position, -Vector3.up, statsRuntime.distanceToGround))
        {
            statsRuntime.isGrounded = true;
        } else
        {
            statsRuntime.isGrounded = false;
        }
    }
    public void TakeDamage(float damage)
    {
        statsRuntime.hp -= damage;
        if (statsRuntime.hp <= 0)
        {
            Die();
        }
    }
    public void AddScore(float score)
    {
        statsRuntime.coins += score;
    }
    protected virtual void Move(Vector2 input)
    {
        if (statsRuntime == null) return;

        bool moving = input.sqrMagnitude > 0.01f;

        if (moving)
        {
            statsRuntime.movementDir = input.normalized;
            float rotation = Mathf.Atan2(statsRuntime.movementDir.x, statsRuntime.movementDir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        }

        float rate = moving ? statsRuntime.accerelation : statsRuntime.deceleration;
        float target = moving ? statsRuntime.maxSpeed : 0f;

        statsRuntime.currentSpeed = Mathf.MoveTowards(statsRuntime.currentSpeed, target, rate * Time.deltaTime);

        rb.linearVelocity = new Vector3(statsRuntime.movementDir.x * statsRuntime.currentSpeed, rb.linearVelocity.y, statsRuntime.movementDir.y * statsRuntime.currentSpeed);
    }
    protected virtual void Roll() { }
    protected virtual void Attack()
    {
        Debug.Log("I attacked");
    }
    protected virtual void Die() { }
    private void OnCollisionEnter(Collision collision) //determines the distance from center of the object to the floor for jumps
    {
        if (statsRuntime == null) return;

        if (statsRuntime.distanceToGround == 0)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, -Vector3.up, out hit, 10f);

            statsRuntime.distanceToGround = hit.distance + 0.01f;
        }
    }
}
