using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakable_Blocks;

    LoadScene sceneLoader;

    public void Total_Breakle_Blocks_Count()
    {
        breakable_Blocks++;
    }

    public void Blocks_Braked()
    {
        breakable_Blocks--;
        if(breakable_Blocks <= 0)
        {
                 sceneLoader = FindObjectOfType<LoadScene>();
                 sceneLoader.loadScene();
        }
    }
}
