using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Config Params
    [SerializeField] float yPosition = 0.25f;
    [SerializeField] float xPosition = 11.5f;
    [SerializeField] float xChange = 0.25f;
    Vector2 paddlePos;

    // Start is called before the first frame update
    void Start()
    {
        paddlePos = new Vector2(xPosition, yPosition);
        transform.position = paddlePos;
    }

    // Update is called once per frame
    void Update()
    {
        // If autoplay is enabled
        if(FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
        {
            paddlePos = new Vector2(Mathf.Clamp(GetXPos(), 1, 20.34f), yPosition);
        }

        // If autoplay is not enabled
        else
        {
            if(Input.GetKey(KeyCode.A))
                paddlePos = new Vector2(Mathf.Clamp(transform.position.x-xChange, 1, 20.34f), yPosition);

            else if(Input.GetKey(KeyCode.D))
                paddlePos = new Vector2(Mathf.Clamp(transform.position.x+xChange, 1, 20.34f), yPosition);
        }

        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        return FindObjectOfType<Ball>().transform.position.x;
    }
}
