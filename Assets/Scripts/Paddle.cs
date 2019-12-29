using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
            rb.velocity = new Vector2(-5f, 0);

        else if(Input.GetKey(KeyCode.D))
            rb.velocity = new Vector2(5f, 0);
    }
}
