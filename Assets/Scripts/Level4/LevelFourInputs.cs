using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelFourInputs : Inputs
{
    private WaitForSeconds timer;

    [SerializeField]
    private AudioClip bombs;

    // Code: "THE ASSAULT WAS SUCCESSFUL WE HAVE ENTERED THEIR BASES AND WILL RESCUE YOU DO NOT LOSE HOPE"

    // Start is called before the first frame update
    void Start()
    {
        Setup();

        soundManager.PlayMusic(ambientWind, true, 0.6f);

        timeBetweenInputs = 8;
        timer = new WaitForSeconds(timeBetweenInputs);

        levelCode = new List<MorseKey>();
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.C);
        levelCode.Add(MorseKey.C);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.F);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.V);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.B);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.C);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.Y);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.P);
        levelCode.Add(MorseKey.E);

        StartCoroutine(BeginLoop());
    }

    IEnumerator BeginLoop()
    {
        UnreceivedMessage();

        foreach (MorseKey key in levelCode)
        {
            switch (key)
            {
                case MorseKey.N:
                case MorseKey.T:
                case MorseKey.I:
                case MorseKey.S:
                case MorseKey.W:
                    soundManager.PlaySound(bombs, transform.position, 0.5f);
                    break;
                default:
                    break;
            }
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

            switch (key)
            {
                case MorseKey.E:
                case MorseKey.A:
                case MorseKey.O:
                case MorseKey.H:
                    soundManager.PlaySound(bombs, transform.position, 0.5f);
                    break;
                default:
                    break;
            }

            if (penalty <= penaltyThreshold) SceneManager.LoadScene("GameOver");

            UnreceivedMessage();
        }

        SceneManager.LoadScene("Level5");
    }
}
