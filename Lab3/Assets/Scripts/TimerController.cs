using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float levelTime = 30f;
    private float remainingTime;
    public Text timerText;

    private bool isGameOver = false;

    void Start()
    {
        remainingTime = levelTime;
    }

    void Update()
    {
        if (isGameOver) return;

        remainingTime -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(remainingTime).ToString();
        }

        if (remainingTime <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Час вичерпано! Програш.");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}