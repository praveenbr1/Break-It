using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]  Paddle_Movement paddle;
    Rigidbody2D myRigidbody2D;
    
    Vector2 padlle_To_Ball_Vector;

    bool has_Started = false;

    [SerializeField] float x_Axis_Launch_Distance_Of_Ball = 2f;

    [SerializeField] float y_Axis_Launch_Distance_Of_Ball = 10f;

    [SerializeField] AudioClip ball_Hitting_Sounds;

    

     AudioSource audioClip;
     //[SerializeField] float randomFactor = 0.3f;

     [SerializeField] float amplitude = 2f;
float minVelocity;
float maxVelocity; 
    
   
   void Start() 
   {
      
      padlle_To_Ball_Vector = transform.position - paddle.transform.position;
      myRigidbody2D = GetComponent<Rigidbody2D>();
      audioClip = GetComponent<AudioSource>();
       
   }
    void Update()
    {    
         // Debug.Log(!has_Started);
         
         // The ! operator works differntly inside if() statemet and differently in Debug Statement
         // To check it uncommnet the above and below debug statement
         // Basically inside if(!somevariable) means it is not start or false.
         // but in debug statement Debug.Log(!somevariable) means reverse of assigned value(i.e true in case of false and vice versa).
        
         if(!has_Started)
         {
           //Debug.Log(has_Started);
           Launch_the_Ball();
           Paddle_Position();
           minVelocity = myRigidbody2D.velocity.y - amplitude;
          maxVelocity = myRigidbody2D.velocity.y + amplitude;
         }
        
          
     }

    private void Launch_the_Ball()
    {
        if(Input.GetMouseButton(0))
        {
            myRigidbody2D.velocity = new Vector2(x_Axis_Launch_Distance_Of_Ball,
                                                               y_Axis_Launch_Distance_Of_Ball);
            has_Started = true;   
                                                         
        }
    }

    private void Paddle_Position()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + padlle_To_Ball_Vector;
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {  
       
                
        if(has_Started)
      {  
        //AudioClip clips = ball_Hitting_Sounds[UnityEngine.Random.Range(0,ball_Hitting_Sounds.Length)];
        audioClip.PlayOneShot(ball_Hitting_Sounds);
         
      }  
    }

private void OnCollisionExit2D(Collision2D collision)
{
    CorrectXVelocity();
    CorrectYVelocity();
}

private void CorrectXVelocity()
{
    int xSign = Math.Sign(myRigidbody2D.velocity.x);
    float absXVelocity = Math.Abs(myRigidbody2D.velocity.x);

    if (absXVelocity < minVelocity)
    {
        myRigidbody2D.velocity += new Vector2((minVelocity - absXVelocity) * xSign, 0f);
    }

    if (absXVelocity > maxVelocity)
    {
        myRigidbody2D.velocity -= new Vector2((absXVelocity - maxVelocity) * xSign, 0f);
    }
}

private void CorrectYVelocity()
{
    int ySign = Math.Sign(myRigidbody2D.velocity.y);
    float absYVelocity = Math.Abs(myRigidbody2D.velocity.y);

    if (absYVelocity < minVelocity)
    {
        myRigidbody2D.velocity += new Vector2(0f, (minVelocity - absYVelocity) * ySign);
    }

    if (absYVelocity > maxVelocity)
    {
        myRigidbody2D.velocity -= new Vector2(0f, (absYVelocity - maxVelocity) * ySign);
    }
}
    
}  
    
    
 
    
