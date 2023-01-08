using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputListener : MonoBehaviour
{
    [SerializeField]
    private Inputs inputs;

    [SerializeField]
    private bool active = true;

    void Start()
    {
        inputs.penaltyEvent += () => GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0);

        inputs.receivedMessage += () => gameObject.SetActive(active);

        inputs.unreceivedMessage += () => GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
        inputs.unreceivedMessage += () => gameObject.SetActive(!active);
    }


}
