using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelOneInputs : Inputs
{
    private WaitForSeconds timer;

    // Code: "BOMB AT 23W45N

    // Start is called before the first frame update
    void Start()
    {
        Setup();

        timeBetweenInputs = 5;
        timer = new WaitForSeconds(timeBetweenInputs);

        levelCode = new List<MorseKey>();
        levelCode.Add(MorseKey.B);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.M);
        levelCode.Add(MorseKey.B);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.Two);
        levelCode.Add(MorseKey.Three);
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey.Four);
        levelCode.Add(MorseKey.Five);
        levelCode.Add(MorseKey.N);

        StartCoroutine(BeginLoop());
    }

    IEnumerator BeginLoop()
    {
        UnreceivedMessage();

        yield return timer;

        foreach (MorseKey key in levelCode)
        {
            ReceivedMessage();

            // Play sound, wait till sound ends too

            yield return timer;

            if (confirmedKey != key) penalty -= 1;
            if (penalty <= penaltyThreshold) SceneManager.LoadScene("GameOver");

            Debug.Log("Penalty");

            UnreceivedMessage();

            yield return timer;
        }

        SceneManager.LoadScene("Level2");
    }
}
