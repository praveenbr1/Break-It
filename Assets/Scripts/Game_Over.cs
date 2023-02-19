using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
  public Rigidbody2D rb;
  
 void FixedUpdate()
  {
    if(rb.position.y < -2f)
    {
        SceneManager.LoadScene("Game Over");
       FindObjectOfType<Game_Speed>().ResetGame();
    }
 }
    
  }
   

