using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
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


// Original Code
    // [SerializeField] float WidthInUnits = 16f;
    // [SerializeField] float maxUnitsX = 15f, minUnitsX = 1f;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // Getting the mouse position according to the current screen size
    //     float mousePositionX = Input.mousePosition.x / Screen.width * WidthInUnits;
    //     Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);

    //     PaddlePos.x = Mathf.Clamp(mousePositionX, minUnitsX, maxUnitsX);
        
    //     transform.position = PaddlePos;
    // }