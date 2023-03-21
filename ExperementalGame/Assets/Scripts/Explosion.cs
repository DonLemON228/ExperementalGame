using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider[] hitColiders = Physics.OverlapSphere(transform.position, 40.0f);

        foreach (var iter in hitColiders)
        {

            var rigidbody = iter.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(800.0f, transform.position, 40.0f, 10.0f);
            }
        }
    }
}
