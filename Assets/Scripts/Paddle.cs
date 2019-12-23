using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float WidthInUnits = 16f;
    [SerializeField] float maxUnitsX = 15f, minUnitsX = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Getting the mouse position according to the current screen size
        float mousePositionX = Input.mousePosition.x / Screen.width * WidthInUnits;
        Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);

        PaddlePos.x = Mathf.Clamp(mousePositionX, minUnitsX, maxUnitsX);
        
        transform.position = PaddlePos;
    }
}
