using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{  
   [SerializeField] AudioSource buttonSounds;

   void Start() 
    {
      //Here GetComponent can be used only when the script sits on the AudioSource of the object where the sound is played
      //So this is not the case in the game Starting level where create sepearte gameobject where we have our audiosource and we add it in the script where we serialized it..
     // buttonSounds = GetComponent<AudioSource>();
    }
      public void loadScene()
      {   
          buttonSounds.Play();
          StartCoroutine(Wait());
      }

      public void FirstScne()
      {
        
        buttonSounds.Play();
        StartCoroutine(GameOver());
      }
      
      public void QuitGame()
      { 
        buttonSounds.Play();
        Application.Quit();
      }
     
      IEnumerator Wait()
      {
          yield return new WaitForSecondsRealtime(0.5f);
          int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
          SceneManager.LoadScene(currentSceneIndex + 1);     
      }

      IEnumerator GameOver()
      {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(4);
      }
}
