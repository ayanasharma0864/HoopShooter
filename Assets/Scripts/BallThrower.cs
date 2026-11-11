using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float xLimit = 5f;
    public float minPower = 8f;
    public float maxPower = 14f;
    public float chargeSpeed = 4f;
    public float upward = 1.2f;
    public float respawnDelay = 3f;
    public AudioClip bounceClip;

    Rigidbody rb;
    AudioSource audioSource;
    float power;
    bool thrown;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
        transform.position = new Vector3(0f, 1.2f, 0f);
        transform.rotation = Quaternion.identity;
        thrown = false;
        power = minPower;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (bounceClip != null && audioSource != null && collision.relativeVelocity.magnitude > 1f)
            audioSource.PlayOneShot(bounceClip);
    }
}