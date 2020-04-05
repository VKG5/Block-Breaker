using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
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
        if(Input.GetKey(KeyCode.A))
            paddlePos = new Vector2(Mathf.Clamp(transform.position.x-xChange, 1, 20.34f), yPosition);

        else if(Input.GetKey(KeyCode.D))
            paddlePos = new Vector2(Mathf.Clamp(transform.position.x+xChange, 1, 20.34f), yPosition);

        transform.position = paddlePos;
    }
}
