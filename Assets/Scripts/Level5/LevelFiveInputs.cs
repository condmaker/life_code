using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelFiveInputs : Inputs
{
    private WaitForSeconds timer;

    [SerializeField]
    private AudioClip bombs;

    // Code: "WE HAVE SECURED ALL OF THE HIDING BASES INJURED SOLDIERS PLEASE COME SEEK MEDICAL TREATMENT AT 34W 21N"

    // Start is called before the first frame update
    void Start()
    {
        Setup();

        soundManager.PlayMusic(ambientWind, true, 0.8f);

        timeBetweenInputs = 7;
        timer = new WaitForSeconds(timeBetweenInputs);

        levelCode = new List<MorseKey>();
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.V);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.C);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.F);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.G);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.B);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.J);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.P);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.C);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.M);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.K);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.M);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.C);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.Three);
        levelCode.Add(MorseKey.Four);
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.Two);
        levelCode.Add(MorseKey.One);
        levelCode.Add(MorseKey.N);

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
                case MorseKey.Three:
                case MorseKey.Four:
                    soundManager.PlaySound(bombs, transform.position, 0.6f);
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
                case MorseKey.B:
                case MorseKey.C:
                case MorseKey.G:
                case MorseKey.One:
                case MorseKey.Two:
                    soundManager.PlaySound(bombs, transform.position, 0.9f);
                    break;
                default:
                    break;
            }

            if (penalty <= penaltyThreshold) SceneManager.LoadScene("GameOver");

            UnreceivedMessage();
        }

        SceneManager.LoadScene("End");
    }
}
