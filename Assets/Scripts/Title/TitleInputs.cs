using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleInputs : Title
{
    public override void OnAsterisk()
    {
        SceneManager.LoadScene("Level1");
    }
}
