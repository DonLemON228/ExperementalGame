using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class NavMeshBack : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var enemyAnim = other.gameObject.GetComponent<Animator>();
            enemyAnim.SetBool("Falling 0", false);
            await Task.Delay(1000);
            var navMesh = other.transform.GetComponent<NavMeshAgent>();
            var moveScript = other.transform.GetComponent<EnemyMove>();
            navMesh.enabled = true;
            moveScript.enabled = true;
            
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
