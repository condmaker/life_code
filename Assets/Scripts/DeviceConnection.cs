using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceConnection : MonoBehaviour
{
    [SerializeField]
    private bool connect = true;

    [SerializeField]
    private SerialInputsManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        if (connect)
        {
            inputManager.onConnection += () => gameObject.SetActive(true);
            inputManager.onDisconnection += () => gameObject.SetActive(false);

            gameObject.SetActive(true);
        }
        else
        {
            inputManager.onConnection += () => gameObject.SetActive(false);
            inputManager.onDisconnection += () => gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
