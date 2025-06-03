using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Text livesText;

    void Start()
    {
        if (GlobalStorage.Instance != null)
        {
            // Ініціалізація життів
            if (GlobalStorage.Instance.data.lives <= 0)
                GlobalStorage.Instance.data.lives = 3;

            livesText.text = "Lives: " + GlobalStorage.Instance.data.lives;
        }
    }

    void Update()
    {
        livesText.text = "Lives: " + GlobalStorage.Instance.data.lives;
    }
}