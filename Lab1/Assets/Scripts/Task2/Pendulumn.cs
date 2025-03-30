using UnityEngine;

public class Pendulumn : MonoBehaviour
{
    public float swingAngle = 45f;
    public float speed = 2f;
    private float initialZ;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialZ = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * swingAngle;
        transform.rotation = Quaternion.Euler(0, 0, initialZ + angle);
    }
}
