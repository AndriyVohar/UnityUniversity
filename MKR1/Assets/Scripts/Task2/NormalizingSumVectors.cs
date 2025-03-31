using UnityEngine;

/**
 * Дано вектори (1,8,-7) та (2,0,-6). Нормалізувати їх суму.
 */
public class NormalizingSumVectors : MonoBehaviour
{    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 vector1 = new Vector3(1, 8, -7);
        Vector3 vector2 = new Vector3(2, 0, -6);
        Vector3 sum = vector1 + vector2;
        Vector3 normalizedSum = sum.normalized;

        Debug.Log("Normalized sum: " + normalizedSum); // Normalized sum: (0.19, 0.51, -0.84)
    }
}
