using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnScreenInput : MonoBehaviour
{
    [SerializeField]
    private Inputs input;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        input.onCurrentInput += ChangeTitle;
        input.onConfirm += ConfirmTitle;
    }

    private void ChangeTitle(string s)
    {
        if (s != "None") text.text = "Current Input: " + s;
    }

    private void ConfirmTitle()
    {
        text.text = "Input Confirmed.";
    }

}
