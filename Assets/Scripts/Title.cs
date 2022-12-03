using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField]
    SerialInputManager inputManager;

    private void Start()
    {
        inputManager.onMessage += MessageDecoder;
    }

    private void MessageDecoder(string s)
    {
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
            case "KM_KEYDOWN (*)":
                OnAsterisk();
                break;
            case "KM_KEYDOWN (#)":
                OnNumbSign();
                break;
        }
    }

    public virtual void OnNine()
    {

    }
    public virtual void OnEight()
    {

    }
    public virtual void OnSeven()
    {

    }
    public virtual void OnSix()
    {

    }
    public virtual void OnFive()
    {

    }
    public virtual void OnFour()
    {

    }
    public virtual void OnThree()
    {

    }
    public virtual void OnTwo()
    {

    }
    public virtual void OnOne()
    {

    }
    public virtual void OnAsterisk()
    {

    }
    public virtual void OnNumbSign()
    {

    }
}
