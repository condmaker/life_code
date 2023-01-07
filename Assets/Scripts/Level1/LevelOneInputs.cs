using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelOneInputs : Inputs
{
    private WaitForSeconds timer;

    // Code: "HELLO THIS IS COMMANDER IGOR

    // Start is called before the first frame update
    void Start()
    {
        Setup();

        soundManager.PlayMusic(ambientWind, true, 0.2f);

        timeBetweenInputs = 10;
        timer = new WaitForSeconds(timeBetweenInputs);

        levelCode = new List<MorseKey>();
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.C);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.M);
        levelCode.Add(MorseKey.M);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.G);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.R);

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

        SceneManager.LoadScene("Level2");
    }
}
