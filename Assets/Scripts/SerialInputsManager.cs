using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SerialInputsManager : MonoBehaviour
{
    [SerializeField]
    private SerialController serialController;

    // Executed each frame
    void Update()
    {
        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
        {
            Debug.Log("Connection established");
            onConnection.Invoke();
        }
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
        {
            Debug.Log("Connection attempt failed or disconnection detected");
            onDisconnection.Invoke();
        }
        else
        {
            Debug.Log("Message arrived: " + message);
            onMessage?.Invoke(message);
        }
    }

    public event Action onConnection;
    public event Action onDisconnection;
    public event Action<string> onMessage;
}
