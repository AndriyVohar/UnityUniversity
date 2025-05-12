using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = true;
    public float boostSpeed = 10f;
    public float boostDuration = 0.1f;
    
    private bool isBoosting = false;
    private float boostEndTime;

    void Update()
    {
        float currentSpeed = isBoosting ? boostSpeed : moveSpeed;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isBoosting)
        {
            StartBoost();
        }

        if (isBoosting && Time.time > boostEndTime)
        {
            StopBoost();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("Box"))
        {
            GlobalStorage.Instance.data.lives--;
            Debug.Log("Player hit! Lives remaining: " + GlobalStorage.Instance.data.lives);

            if (Lives.lives <= 0)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }

        if (collision.gameObject.CompareTag("Money"))
        {
            GlobalStorage.Instance.data.lives++;
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void StartBoost()
    {
        isBoosting = true;
        boostEndTime = Time.time + boostDuration;
    }

    private void StopBoost()
    {
        isBoosting = false;
    }
}
