using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDamage : MonoBehaviour
{
    [SerializeField] private HpSystemEnemy health;
    [SerializeField] private GameObject pointHit;
    [SerializeField] private int fallingDamage;
    private float distance_;
    public Rigidbody rb;
    RaycastHit hit;

    private void RayCastDistance()
    {
        distance_ = hit.distance;
        if(Physics.Raycast(pointHit.transform.position, -pointHit.transform.up, out hit, 500f))
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("Ground") && rb.velocity.y <= -4)
        {
            RayCastDistance();
            //health.GetFallDamage(fallingDamage);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
