using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverInputs : Inputs
{
    public void Start()
    {
        Setup();
    }

    public override void OnAsterisk()
    {
        Debug.Log("close");
        Application.Quit();
    }
}
