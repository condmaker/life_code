using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFiveBeforeInputs : Inputs
{
    public void Start()
    {
        Setup();
    }
    public override void OnAsterisk()
    {
        SceneManager.LoadScene("Level5-Play");
    }
}
