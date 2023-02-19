using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destroy_Block : MonoBehaviour
{
    
    [SerializeField] AudioClip Clips;
    [SerializeField] Sprite[] damageSprites;
    [SerializeField] ParticleSystem breakEffectParticles;
    int damagelevel= -1;
    int index;
    
    AudioSource audioSource;
    
    
    Level level;
    
    void Start()
    {
     CountBreakableBlocks();
      
       
    }
      private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Brick")
        {
            level.Total_Breakle_Blocks_Count();
        }
    }

     
    
       
    
        void OnCollisionEnter2D(Collision2D other)
    {    damagelevel++;
            
      
       // You cam use for loop also  instead of foreach loop here...
        
        
        
        for(index = 0; index < damageSprites.Length; index++)
        { 
              
              if(damagelevel == index)
              {
                GetComponent<SpriteRenderer>().sprite = damageSprites[index];
                
              }
             
              else if(damagelevel >= damageSprites.Length)
              {
                Destroy_Blocks();
              }
        }
        
    //    int index = 0;
    //      foreach (Sprite currentSprite in damageSprites) {
    //     if (damagelevel == index) {
    //         GetComponent<SpriteRenderer>().sprite = currentSprite;
    //         //break;
    //     }
    //     index++;
    // }
    // if(damagelevel >= damageSprites.Length){
    //     Destroy_Blocks();
    }
        

        
        
    

    private void Destroy_Blocks()
    {
        ParticleSystem particles = Instantiate(breakEffectParticles,transform.position,transform.rotation);
       FindObjectOfType<Game_Speed>().AddScore();
    
      
       AudioSource.PlayClipAtPoint(Clips, Camera.main.transform.position); 
        Destroy(gameObject);
        level.Blocks_Braked();
        Destroy(particles,0.5f);
    }




    


}

