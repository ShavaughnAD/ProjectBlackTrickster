using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineComposer composer;

    public float ySensitivity = 5;
    public float xSensitivity = 5;

    [SerializeField] float minHeightY = -10;
    [SerializeField] float maxHeightY = -10;

    void Start()
    {
        composer = GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineComposer>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Mouse Y") * ySensitivity;
        composer.m_TrackedObjectOffset.y += vertical;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, minHeightY, maxHeightY);
    }
}
