using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseCollider : MonoBehaviour
{
    Ball ball;
    Level count;
    [SerializeField] int Lives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] int blockDestroyed;

    private void Start()
    {
        livesText.text = Lives.ToString();
        count = FindObjectOfType<Level>();
    }

    public void Update()
    {
        livesText.text = Lives.ToString();
        blockDestroyed = count.count;
        
        if(count.count == 12)
        {
            count.count = 0;
            Lives++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = FindObjectOfType<Ball>();
        Lives--;

        if (Lives == 0)
        {
            SceneManager.LoadScene("Game over");
        }

        else
        {
            ball.hasStarted = false;
            ball.Update();
        }
    }
}
