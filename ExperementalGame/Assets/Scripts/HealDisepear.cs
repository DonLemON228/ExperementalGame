using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class HealDisepear : MonoBehaviour
{

    [SerializeField] GameObject healSphere;
    [SerializeField] SphereCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public async void HealSphereOff()
    {
        healSphere.SetActive(false);
        collider.enabled = false;
        await Task.Delay(40000);
        collider.enabled = true;
        healSphere.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
