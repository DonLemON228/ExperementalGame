using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCameraAnim : MonoBehaviour
{
    public Animator cameraAnim;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                cameraAnim.SetBool("RunCamera", true);
            }
        }
        else
        {
            cameraAnim.SetBool("RunCamera", false);
        }
    }
}
