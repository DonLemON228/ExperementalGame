using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class ExplosionColiderNavMeshControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var navMesh = other.transform.GetComponent<NavMeshAgent>();
            navMesh.enabled = false;
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
