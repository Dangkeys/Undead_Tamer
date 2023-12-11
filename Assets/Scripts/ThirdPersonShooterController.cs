using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using Unity.Netcode;
using UnityEngine;

public class ThirdPersonShooterController : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerCameraRoot;
    private CinemachineVirtualCamera aimVirtualCamera;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    [Header("Settings")]
    [SerializeField][Range(0, 1)] private float normalSensitivity;
    [SerializeField][Range(0, 1)] private float aimSensitivity;
    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        if (aimVirtualCamera == null)
        {
            aimVirtualCamera = ObjectHolder.Instance.AimVirtualCamera;
        }
    }
    public override void OnNetworkSpawn()
    {
        if (!IsOwner || !IsClient) return;
        aimVirtualCamera.Follow = playerCameraRoot;
    }
    private void Update()
    {
        if (!IsOwner || !IsClient) return;
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetPlayerSensitivity(aimSensitivity);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetPlayerSensitivity(normalSensitivity);
        }
    }
}
