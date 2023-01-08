using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelThreeInputs : Inputs
{
    private WaitForSeconds timer;

    [SerializeField]
    private AudioClip bombs;

    // Code: "WE ASK ALL OUR SOLDIERS TO HOLD ON TIGHT WE WILL START THE NEW ASSAULT SHORTLY"

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
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.K);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.R);
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
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.D);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.G);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey.I);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.N);
        levelCode.Add(MorseKey.E);
        levelCode.Add(MorseKey.W);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.A);
        levelCode.Add(MorseKey.U);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey._);
        levelCode.Add(MorseKey.S);
        levelCode.Add(MorseKey.H);
        levelCode.Add(MorseKey.O);
        levelCode.Add(MorseKey.R);
        levelCode.Add(MorseKey.T);
        levelCode.Add(MorseKey.L);
        levelCode.Add(MorseKey.Y);

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
                    soundManager.PlaySound(bombs, transform.position, 0.2f);
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
                    soundManager.PlaySound(bombs, transform.position, 0.2f);
                    break;
                default:
                    break;
            }

            if (penalty <= penaltyThreshold) SceneManager.LoadScene("GameOver");

            UnreceivedMessage();
        }

        SceneManager.LoadScene("Level4");
    }
}
