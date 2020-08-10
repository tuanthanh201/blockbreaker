using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int BreakableBlocks;
    public int count = 0;
    SceneLoader loader;

    public void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cheat") == true)
        {
            loader.LoadNextScene();
        }
    }

    public void CountBreakableBlocks()
    {
        BreakableBlocks++;
    }

    public void BlockDestroyed()
    {
        BreakableBlocks--;
        count++;

        if (BreakableBlocks <= 0)
        {
            loader.LoadNextScene();
        }
    }
}
