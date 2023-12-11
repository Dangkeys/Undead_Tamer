using System.Collections;
using System.Collections.Generic;
using QFSW.QC;
using Unity.Netcode;
using UnityEngine;

public class JoinHandler : MonoBehaviour
{
    [Command]
    private void StartServer()
    {
        NetworkManager.Singleton.StartServer();
    }
    [Command]
    private void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
    [Command]
    private void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }
}
