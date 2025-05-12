using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public static int lives = 1; // Lives count
    public Text livesText; // UI Text to display lives
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
    	if (GlobalStorage.Instance != null)
    	{
        	GlobalStorage.Instance.data.lives = lives;
        	// Initialize the lives text
        	livesText.text = "Lives: " + GlobalStorage.Instance.data.lives;
    	}
    	else
    	{
        	Debug.LogError("GlobalStorage.Instance is null. Ensure it is initialized before accessing it.");
	    }
	}

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + GlobalStorage.Instance.data.lives;
    }
}
