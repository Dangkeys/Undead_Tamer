using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public static ObjectHolder Instance { get; private set; }
    [field:SerializeField] public CinemachineVirtualCamera PlayerFollowCamera {get; private set;}
    [field:SerializeField] public CinemachineVirtualCamera AimVirtualCamera {get; private set;}
    [field:SerializeField] public GameObject MainCamera {get; private set;}
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
