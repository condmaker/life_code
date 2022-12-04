using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneBeforeInputs : Inputs
{
    public override void OnAsterisk()
    {
        SceneManager.LoadScene("Level1-Play");
    }
}
