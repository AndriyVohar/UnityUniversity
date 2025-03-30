using UnityEngine;

public class SpiralPlatform : MonoBehaviour
{
    public float radius = 5f;
    public float speed = 2f;
    public float heightSpeed = 1f;
    private float angle;

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        float y = Mathf.Sin(angle * heightSpeed);
        transform.position = new Vector3(x, y, z);
    }
}
