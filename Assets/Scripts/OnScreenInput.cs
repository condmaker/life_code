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
        GetComponent<TextMeshProUGUI>();

        input.onCurrentInput += ChangeTitle;
        input.onConfirm += ConfirmTitle;
    }

    private void ChangeTitle(string s)
    {
        text.text = "Current Input: " + s.Remove(0, 8);
    }

    private void ConfirmTitle()
    {
        text.text = "Input Sent.";
    }

}
