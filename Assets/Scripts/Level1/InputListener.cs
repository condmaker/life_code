using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField]
    private Inputs inputs;

    [SerializeField]
    private bool active = true;

    void Start()
    {
        inputs.receivedMessage += () => gameObject.SetActive(active);
        inputs.unreceivedMessage += () => gameObject.SetActive(!active);
    }

}
