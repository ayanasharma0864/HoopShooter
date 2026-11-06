using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float xLimit = 5f;
    public float minPower = 8f;
    public float maxPower = 20f;
    public float chargeSpeed = 10f;
    public float upward = 0.6f;
    public float respawnDelay = 3f;

    Rigidbody rb;
    Vector3 startPos;
    float power;
    bool thrown;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        ResetBall();
    }

    void Update()
    {
        if (thrown) return;

        float h = Input.GetAxis("Horizontal");
        Vector3 p = transform.position + Vector3.right * h * moveSpeed * Time.deltaTime;
        p.x = Mathf.Clamp(p.x, -xLimit, xLimit);
        transform.position = p;

        if (Input.GetKeyDown(KeyCode.Space)) power = minPower;
        if (Input.GetKey(KeyCode.Space))
            power = Mathf.Min(power + chargeSpeed * Time.deltaTime, maxPower);
        if (Input.GetKeyUp(KeyCode.Space)) Throw();
    }

    void Throw()
    {
        thrown = true;
        rb.isKinematic = false;
        Vector3 dir = (Vector3.forward + Vector3.up * upward).normalized;
        rb.AddForce(dir * power, ForceMode.VelocityChange);
        Invoke(nameof(ResetBall), respawnDelay);
    }

    public void ResetBall()
    {
        CancelInvoke();
        if (!rb.isKinematic)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        rb.isKinematic = true;
        transform.position = new Vector3(transform.position.x, startPos.y, startPos.z);
        thrown = false;
        power = minPower;
    }
}