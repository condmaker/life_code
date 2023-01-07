using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Inputs : MonoBehaviour
{
    protected enum InputKey
    {
        Nine,
        Eight,
        Seven,
        Six,
        Five,
        Four,
        Three,
        Two,
        One,
        Zero,
        Asterisk,
        NumbSign,
        None
    }

    protected enum MorseKey
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        _,
        Nine,
        Eight,
        Seven,
        Six,
        Five,
        Four,
        Three,
        Two,
        One,
        Zero,
        None
    }

    [SerializeField]
    SerialInputsManager inputManager;

    [SerializeField]
    protected SoundMng soundManager;

    [SerializeField]
    protected AudioClip soundA;
    [SerializeField]
    protected AudioClip soundB;
    [SerializeField]
    protected AudioClip soundC;
    [SerializeField]
    protected AudioClip soundD;
    [SerializeField]
    protected AudioClip soundE;
    [SerializeField]
    protected AudioClip soundF;
    [SerializeField]
    protected AudioClip soundG;
    [SerializeField]
    protected AudioClip soundH;
    [SerializeField]
    protected AudioClip soundI;
    [SerializeField]
    protected AudioClip soundJ;
    [SerializeField]
    protected AudioClip soundK;
    [SerializeField]
    protected AudioClip soundL;
    [SerializeField]
    protected AudioClip soundM;
    [SerializeField]
    protected AudioClip soundN;
    [SerializeField]
    protected AudioClip soundO;
    [SerializeField]
    protected AudioClip soundP;
    [SerializeField]
    protected AudioClip soundQ;
    [SerializeField]
    protected AudioClip soundR;
    [SerializeField]
    protected AudioClip soundS;
    [SerializeField]
    protected AudioClip soundT;
    [SerializeField]
    protected AudioClip soundU;
    [SerializeField]
    protected AudioClip soundV;
    [SerializeField]
    protected AudioClip soundW;
    [SerializeField]
    protected AudioClip soundX;
    [SerializeField]
    protected AudioClip soundY;
    [SerializeField]
    protected AudioClip soundZ;
    [SerializeField]
    protected AudioClip sound0;
    [SerializeField]
    protected AudioClip sound1;
    [SerializeField]
    protected AudioClip sound2;
    [SerializeField]
    protected AudioClip sound3;
    [SerializeField]
    protected AudioClip sound4;
    [SerializeField]
    protected AudioClip sound5;
    [SerializeField]
    protected AudioClip sound6;
    [SerializeField]
    protected AudioClip sound7;
    [SerializeField]
    protected AudioClip sound8;
    [SerializeField]
    protected AudioClip sound9;

    [SerializeField]
    private AudioClip click;
    [SerializeField]
    private AudioClip confirm;

    [SerializeField]
    protected AudioClip ambientWind;

    private AudioClip soundToPlay;
    protected AudioClip codeSoundToPlay;

    private int timeAfterInputs = 3;
    protected float timeForAudio = 0;
    protected WaitForSeconds timerAfter;

    private InputKey prevInput;
    private MorseKey currentKey;

    private int iter;

    protected List<MorseKey> levelCode;
    protected MorseKey confirmedKey;

    protected int timeBetweenInputs;
    protected int penalty = 0;
    protected const int penaltyThreshold = -3; 

    protected void Setup()
    {
        timerAfter = new WaitForSeconds(timeAfterInputs);
        iter = 0;
        prevInput = InputKey.None;

        inputManager.onMessage += MessageDecoder;
    }

    private void MessageDecoder(string s)
    {
        soundToPlay = null;
        switch (s)
        {
            case "KM_KEYDOWN (9)":
                OnNine();
                break;
            case "KM_KEYDOWN (8)":
                OnEight();
                break;
            case "KM_KEYDOWN (7)":
                OnSeven();
                break;
            case "KM_KEYDOWN (6)":
                OnSix();
                break;
            case "KM_KEYDOWN (5)":
                OnFive();
                break;
            case "KM_KEYDOWN (4)":
                OnFour();
                break;
            case "KM_KEYDOWN (3)":
                OnThree();
                break;
            case "KM_KEYDOWN (2)":
                OnTwo();
                break;
            case "KM_KEYDOWN (1)":
                OnOne();
                break;
            case "KM_KEYDOWN (0)":
                OnZero();
                break;
            case "KM_KEYDOWN (*)":
                OnAsterisk();
                break;
            case "KM_KEYDOWN (#)":
                OnNumbSign();
                break;
        }

        if (soundToPlay) soundManager?.PlaySound(soundToPlay, transform.position);
        onCurrentInput?.Invoke(currentKey.ToString());
    }

    public virtual void OnNine()
    {
        soundToPlay = click;

        if (prevInput == InputKey.Nine)
            iter += 1;
        else
            iter = 0;

        prevInput = InputKey.Nine;

        switch (iter)
        {
            case 0:
                currentKey = MorseKey.Nine;
                break;
            case 1:
                currentKey = MorseKey.A;
                break;
            case 2:
                currentKey = MorseKey.B;
                break;
            case 3:
                prevInput = InputKey.NumbSign;
                currentKey = MorseKey.C;
                break;
            default:
                iter = 0;
                break;
        }
    }
    public virtual void OnEight()
    {
        soundToPlay = click;

        if (prevInput == InputKey.Eight)
            iter += 1;
        else
            iter = 0;

        prevInput = InputKey.Eight;

        switch (iter)
        {
            case 0:
                currentKey = MorseKey.Eight;
                break;
            case 1:
                currentKey = MorseKey.D;
                break;
            case 2:
                currentKey = MorseKey.E;
                break;
            case 3:
                prevInput = InputKey.NumbSign;
                currentKey = MorseKey.F;
                break;
            default:
                iter = 0;
                break;
        }
    }
    public virtual void OnSeven()
    {
        soundToPlay = click;

        if (prevInput == InputKey.Seven)
            iter += 1;
        else
            iter = 0;

        prevInput = InputKey.Seven;

        switch (iter)
        {
            case 0:
                currentKey = MorseKey.Seven;
                break;
            case 1:
                currentKey = MorseKey.G;
                break;
            case 2:
                currentKey = MorseKey.H;
                break;
            case 3:
                prevInput = InputKey.NumbSign;
                currentKey = MorseKey.I;
                break;
            default:
                iter = 0;
                break;
        }
    }
    public virtual void OnSix()
    {
        soundToPlay = click;

        if (prevInput == InputKey.Six)
            iter += 1;
        else
            iter = 0;

        prevInput = InputKey.Six;

        switch (iter)
        {
            case 0:
                currentKey = MorseKey.Six;
                break;
            case 1:
                currentKey = MorseKey.J;
                break;
            case 2:
                currentKey = MorseKey.K;
                break;
            case 3:
                prevInput = InputKey.NumbSign;
                currentKey = MorseKey.L;
                break;
            default:
                iter = 0;
                break;
        }
    }
    public virtual void OnFive()
    {
        soundToPlay = click;

        if (prevInput == InputKey.Five)
            iter += 1;
        else
            iter = 0;

        prevInput = InputKey.Five;

        switch (iter)
        {
            case 0:
                currentKey = MorseKey.Five;
                break;
            case 1:
                currentKey = MorseKey.M;
                break;
            case 2:
                currentKey = MorseKey.N;
                break;
            case 3:
                prevInput = InputKey.NumbSign;
                currentKey = MorseKey.O;
                break;
            default:
                iter = 0;
                break;
        }
    }
    public virtual void OnFour()
    {
        soundToPlay = click;

        if (prevInput == InputKey.Four)
            iter += 1;
        else
            iter = 0;

        prevInput = InputKey.Four;

        switch (iter)
        {
            case 0:
                currentKey = MorseKey.Four;
                break;
            case 1:
                currentKey = MorseKey.P;
                break;
            case 2:
                currentKey = MorseKey.Q;
                break;
            case 3:
                prevInput = InputKey.NumbSign;
                currentKey = MorseKey.R;
                break;
            default:
                iter = 0;
                break;
        }
    }
    public virtual void OnThree()
    {
        soundToPlay = click;

        if (prevInput == InputKey.Three)
            iter += 1;
        else
            iter = 0;

        prevInput = InputKey.Three;

        switch (iter)
        {
            case 0:
                currentKey = MorseKey.Three;
                break;
            case 1:
                currentKey = MorseKey.S;
                break;
            case 2:
                currentKey = MorseKey.T;
                break;
            case 3:
                prevInput = InputKey.NumbSign;
                currentKey = MorseKey.U;
                break;
            default:
                iter = 0;
                break;
        }
    }
    public virtual void OnTwo()
    {
        soundToPlay = click;

        if (prevInput == InputKey.Two)
            iter += 1;
        else
            iter = 0;

        prevInput = InputKey.Two;

        switch (iter)
        {
            case 0:
                currentKey = MorseKey.Two;
                break;
            case 1:
                currentKey = MorseKey.V;
                break;
            case 2:
                currentKey = MorseKey.W;
                break;
            case 3:
                prevInput = InputKey.NumbSign;
                currentKey = MorseKey.X;
                break;
            default:
                iter = 0;
                break;
        }
    }
    public virtual void OnOne()
    {
        soundToPlay = click;

        if (prevInput == InputKey.One)
            iter += 1;
        else
            iter = 0;

        prevInput = InputKey.One;

        switch (iter)
        {
            case 0:
                currentKey = MorseKey.One;
                break;
            case 1:
                currentKey = MorseKey.Y;
                break;
            case 2:
                currentKey = MorseKey.Z;
                break;
            case 3:
                prevInput = InputKey.NumbSign;
                currentKey = MorseKey._;
                break;
            default:
                iter = 0;
                break;
        }
    }
    public virtual void OnZero()
    {
        soundToPlay = click;

        currentKey = MorseKey.Zero;
        prevInput = InputKey.Zero;
    }
    public virtual void OnAsterisk()
    {
        soundToPlay = confirm;

        prevInput = InputKey.Asterisk;
        confirmedKey = currentKey;
        currentKey = MorseKey.None;

        onConfirm?.Invoke();
    }
    public virtual void OnNumbSign()
    {
        prevInput = InputKey.NumbSign;
    }

    protected void ComputeSound(MorseKey key)
    {
        switch (key)
        {
            case MorseKey.A:
                timeForAudio = soundA.length;
                codeSoundToPlay = soundA;
                break;
            case MorseKey.B:
                timeForAudio = soundB.length;
                codeSoundToPlay = soundB;
                break;
            case MorseKey.C:
                timeForAudio = soundC.length;
                codeSoundToPlay = soundC;
                break;
            case MorseKey.D:
                timeForAudio = soundD.length;
                codeSoundToPlay = soundD;
                break;
            case MorseKey.E:
                timeForAudio = soundE.length;
                codeSoundToPlay = soundE;
                break;
            case MorseKey.F:
                timeForAudio = soundF.length;
                codeSoundToPlay = soundF;
                break;
            case MorseKey.G:
                timeForAudio = soundG.length;
                codeSoundToPlay = soundG;
                break;
            case MorseKey.H:
                timeForAudio = soundH.length;
                codeSoundToPlay = soundH;
                break;
            case MorseKey.I:
                timeForAudio = soundI.length;
                codeSoundToPlay = soundI;
                break;
            case MorseKey.J:
                timeForAudio = soundJ.length;
                codeSoundToPlay = soundJ;
                break;
            case MorseKey.K:
                timeForAudio = soundK.length;
                codeSoundToPlay = soundK;
                break;
            case MorseKey.L:
                timeForAudio = soundL.length;
                codeSoundToPlay = soundL;
                break;
            case MorseKey.M:
                timeForAudio = soundM.length;
                codeSoundToPlay = soundM;
                break;
            case MorseKey.N:
                timeForAudio = soundN.length;
                codeSoundToPlay = soundN;
                break;
            case MorseKey.O:
                timeForAudio = soundO.length;
                codeSoundToPlay = soundO;
                break;
            case MorseKey.P:
                timeForAudio = soundP.length;
                codeSoundToPlay = soundP;
                break;
            case MorseKey.Q:
                timeForAudio = soundQ.length;
                codeSoundToPlay = soundQ;
                break;
            case MorseKey.R:
                timeForAudio = soundR.length;
                codeSoundToPlay = soundR;
                break;
            case MorseKey.S:
                timeForAudio = soundS.length;
                codeSoundToPlay = soundS;
                break;
            case MorseKey.T:
                timeForAudio = soundT.length;
                codeSoundToPlay = soundT;
                break;
            case MorseKey.U:
                timeForAudio = soundU.length;
                codeSoundToPlay = soundU;
                break;
            case MorseKey.V:
                timeForAudio = soundV.length;
                codeSoundToPlay = soundV;
                break;
            case MorseKey.W:
                timeForAudio = soundW.length;
                codeSoundToPlay = soundW;
                break;
            case MorseKey.X:
                timeForAudio = soundX.length;
                codeSoundToPlay = soundX;
                break;
            case MorseKey.Y:
                timeForAudio = soundY.length;
                codeSoundToPlay = soundY;
                break;
            case MorseKey.Z:
                timeForAudio = soundZ.length;
                codeSoundToPlay = soundZ;
                break;
            case MorseKey.Zero:
                timeForAudio = sound0.length;
                codeSoundToPlay = sound0;
                break;
            case MorseKey.One:
                timeForAudio = sound1.length;
                codeSoundToPlay = sound1;
                break;
            case MorseKey.Two:
                timeForAudio = sound2.length;
                codeSoundToPlay = sound2;
                break;
            case MorseKey.Three:
                timeForAudio = sound3.length;
                codeSoundToPlay = sound3;
                break;
            case MorseKey.Four:
                timeForAudio = sound4.length;
                codeSoundToPlay = sound4;
                break;
            case MorseKey.Five:
                timeForAudio = sound5.length;
                codeSoundToPlay = sound5;
                break;
            case MorseKey.Six:
                timeForAudio = sound6.length;
                codeSoundToPlay = sound6;
                break;
            case MorseKey.Seven:
                timeForAudio = sound7.length;
                codeSoundToPlay = sound7;
                break;
            case MorseKey.Eight:
                timeForAudio = sound8.length;
                codeSoundToPlay = sound8;
                break;
            case MorseKey.Nine:
                timeForAudio = sound9.length;
                codeSoundToPlay = sound0;
                break;
            case MorseKey._:
                timeForAudio = 1;
                codeSoundToPlay = null;
                break;
        }
    }
    protected void ReceivedMessage() => receivedMessage.Invoke();
    protected void UnreceivedMessage() => unreceivedMessage.Invoke();
    protected void Penalty() => penaltyEvent.Invoke();

    public event Action<string> onCurrentInput;
    public event Action onConfirm;

    public event Action receivedMessage;
    public event Action unreceivedMessage;
    public event Action penaltyEvent;
}
