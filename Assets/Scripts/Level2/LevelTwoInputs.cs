using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelTwoInputs : Inputs
{
    private WaitForSeconds timer;

    // Code: "WE ARE COMMUNICATING WITH NORTH KOREA TO GET SUPPLIES"

    // Start is called before the first frame update
    void Start()
    {
        Setup();

        soundManager.PlayMusic(ambientWind, true, 0.5f);

        timeBetweenInputs = 8;
        timer = new WaitForSeconds(timeBetweenInputs);

        levelCode = new List<MorseKey>();
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.C);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.M);
        levelCode.Add(MorseKey.M);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.C);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.G);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.K);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.G);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.P);
        levelCode.Add(MorseKey.P);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.S);

        StartCoroutine(BeginLoop());
    }

    IEnumerator BeginLoop()
    {
        UnreceivedMessage();

        foreach (MorseKey key in levelCode)
        {
            // Play sound, wait till sound ends too
            ComputeSound(key);
            soundManager.PlaySound(codeSoundToPlay, transform.position);
            yield return new WaitForSeconds(timeForAudio);

            yield return timer;

            if (confirmedKey != key)
            {
                Penalty();
                penalty -= 1;
            }

            ReceivedMessage();

            yield return timerAfter;

            if (penalty <= penaltyThreshold) SceneManager.LoadScene("GameOver");

            UnreceivedMessage();
        }

        SceneManager.LoadScene("Level3");
    }
}
