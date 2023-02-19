using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Speed : MonoBehaviour
{
   [Range(0,2f)] [SerializeField] float gameSpeed = 1f;
   [SerializeField] TextMeshProUGUI scoreText;
   int score = 0;

   private void Awake()
   {
       int numberOfThings = FindObjectsOfType<Game_Speed>().Length;
       if(numberOfThings > 1)
       {
          gameObject.SetActive(false);
          Destroy(gameObject);
       }
       else{DontDestroyOnLoad(gameObject);}
   }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
