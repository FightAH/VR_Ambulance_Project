using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WatchTime : MonoBehaviour
{

    public float timeLeft = 50.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 
    int Stop = 1;


    void Update()
    {
        if (Stop == 1)
        {
            timeLeft -= Time.deltaTime;
            int min = Mathf.FloorToInt(timeLeft / 60);
            int sec = Mathf.FloorToInt(timeLeft % 60);
            startText.GetComponent<UnityEngine.UI.Text>().text = min.ToString("00") + ":" + sec.ToString("00");
            if (timeLeft < 0)
            {
                Stop = 0;
                Debug.Log("Time up");
            }
        }
    }
}