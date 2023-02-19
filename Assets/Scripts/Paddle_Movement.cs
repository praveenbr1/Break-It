using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Movement : MonoBehaviour
{
    [SerializeField] float x_Axis_Screen_Width_In_Units = 16f;
    

    [SerializeField] float minValue = 1f;

    [SerializeField] float maxValue = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosition =(Input.mousePosition.x / Screen.width * x_Axis_Screen_Width_In_Units );
        Vector2 paddlePosition = new Vector2(transform.position.x,transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePosition,minValue,maxValue);
        transform.position = paddlePosition;
    }
}
