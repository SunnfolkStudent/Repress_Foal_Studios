using Unity.Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform _target;
    private CinemachineCamera  _cinemachineCamera;
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _cinemachineCamera = GetComponent<CinemachineCamera>();

        _cinemachineCamera.LookAt = _target;
    }

    
}
