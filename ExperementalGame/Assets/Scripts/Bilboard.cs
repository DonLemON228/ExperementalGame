using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    private Quaternion startRotation;

    private void Start()
    {
        startRotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation * startRotation;
    }
}
