using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    [SerializeField] double x = 7.5;
    [SerializeField] double y = 0.3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            x = x-0.1;

        else if(Input.GetKeyDown(KeyCode.RightArrow))
            x = x+0.1;    
    }
}
