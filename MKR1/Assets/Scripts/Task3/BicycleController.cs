using UnityEngine;

public class CicleController : MonoBehaviour
{
    public float speed = 10f;       // Швидкість руху вперед
    public float turnSpeed = 50f;   // Швидкість повороту
    public float brakeForce = 5f;   // Сила гальмування

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Забороняємо перевертання
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity = transform.forward * -speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = transform.forward * speed / 2;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.fixedDeltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.fixedDeltaTime);
        }
    }
}
