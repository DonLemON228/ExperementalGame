using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextHeal : MonoBehaviour
{

    public Animator startAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startAnim.SetBool("startOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startAnim.SetBool("startOpen", false);
        }
    }
}
