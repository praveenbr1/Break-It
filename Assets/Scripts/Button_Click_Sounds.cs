using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Click_Sounds : MonoBehaviour
{   

    public AudioSource buttonSounds;
    
    public void ButtonClickSounds()
    {
        buttonSounds.Play();
    }
 
}
