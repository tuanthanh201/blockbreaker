using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.5f, 10f)] [SerializeField] float GameSpeed = 1f;

    void Update()
    {
        Time.timeScale = GameSpeed;
    }
}
