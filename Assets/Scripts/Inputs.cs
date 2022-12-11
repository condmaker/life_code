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
        iter = 0;
        prevInput = InputKey.None;

        inputManager.onMessage += MessageDecoder;
    }

    private void MessageDecoder(string s)
    {
        Debug.Log("test");
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

        onCurrentInput?.Invoke(currentKey.ToString());
    }

    public virtual void OnNine()
    {
        if (prevInput == InputKey.Nine)
            iter += 1;
        else
            iter = 0;

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
                currentKey = MorseKey.C;
                break;
            default:
                iter = 0;
                break;
        }

        prevInput = InputKey.Nine;
    }
    public virtual void OnEight()
    {
        if (prevInput == InputKey.Eight)
            iter += 1;
        else
            iter = 0;

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
                currentKey = MorseKey.F;
                break;
            default:
                iter = 0;
                break;
        }

        prevInput = InputKey.Eight;
    }
    public virtual void OnSeven()
    {
        if (prevInput == InputKey.Seven)
            iter += 1;
        else
            iter = 0;

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
                currentKey = MorseKey.I;
                break;
            default:
                iter = 0;
                break;
        }

        prevInput = InputKey.Seven;
    }
    public virtual void OnSix()
    {
        if (prevInput == InputKey.Six)
            iter += 1;
        else
            iter = 0;

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
                currentKey = MorseKey.L;
                break;
            default:
                iter = 0;
                break;
        }

        prevInput = InputKey.Six;
    }
    public virtual void OnFive()
    {
        if (prevInput == InputKey.Five)
            iter += 1;
        else
            iter = 0;

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
                currentKey = MorseKey.O;
                break;
            default:
                iter = 0;
                break;
        }

        prevInput = InputKey.Five;
    }
    public virtual void OnFour()
    {
        if (prevInput == InputKey.Four)
            iter += 1;
        else
            iter = 0;

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
                currentKey = MorseKey.R;
                break;
            default:
                iter = 0;
                break;
        }

        prevInput = InputKey.Four;
    }
    public virtual void OnThree()
    {
        if (prevInput == InputKey.Three)
            iter += 1;
        else
            iter = 0;

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
                currentKey = MorseKey.U;
                break;
            default:
                iter = 0;
                break;
        }

        prevInput = InputKey.Three;
    }
    public virtual void OnTwo()
    {
        if (prevInput == InputKey.Two)
            iter += 1;
        else
            iter = 0;

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
                currentKey = MorseKey.X;
                break;
            default:
                iter = 0;
                break;
        }

        prevInput = InputKey.Two;
    }
    public virtual void OnOne()
    {
        if (prevInput == InputKey.One)
            iter += 1;
        else
            iter = 0;

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
                currentKey = MorseKey._;
                break;
            default:
                iter = 0;
                break;
        }

        prevInput = InputKey.One;
    }
    public virtual void OnZero()
    {
        currentKey = MorseKey.Zero;
        prevInput = InputKey.Zero;
    }
    public virtual void OnAsterisk()
    {
        prevInput = InputKey.Asterisk;
        confirmedKey = currentKey;
        currentKey = MorseKey.None;

        onConfirm?.Invoke();
    }
    public virtual void OnNumbSign()
    {
        prevInput = InputKey.NumbSign;
    }

    protected void ReceivedMessage() => receivedMessage.Invoke();
    protected void UnreceivedMessage() => unreceivedMessage.Invoke();

    public event Action<string> onCurrentInput;
    public event Action onConfirm;

    public event Action receivedMessage;
    public event Action unreceivedMessage;
}
