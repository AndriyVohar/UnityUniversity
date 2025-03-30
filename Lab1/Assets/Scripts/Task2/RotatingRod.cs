using UnityEngine;

public class RotatingRod : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public Vector3 pivotOffset = new Vector3(0f, 0f, 0f);

    void Update()
    {
        transform.RotateAround(transform.position + pivotOffset, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
