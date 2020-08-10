using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX= 2f;
    [SerializeField] float maxX = 15f - 1.52f;

    void Start()
    {
        transform.position = new Vector2(8f, 0.5f);
    }

    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePositionInUnits, minX, maxX);
        transform.position = paddlePos;
    }
}
