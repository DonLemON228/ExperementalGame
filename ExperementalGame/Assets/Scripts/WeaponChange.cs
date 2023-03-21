using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{

    public GameObject Cone;
    public GameObject Shield;
    public GameObject RepulsiveField;
    public GameObject Staff;
    public GameObject explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cone.SetActive(true);
            Shield.SetActive(false);
            RepulsiveField.SetActive(false);
            Staff.SetActive(false);
            explosionParticle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Cone.SetActive(false);
            Shield.SetActive(true);
            RepulsiveField.SetActive(false);
            Staff.SetActive(false);
            explosionParticle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Cone.SetActive(false);
            Shield.SetActive(false);
            RepulsiveField.SetActive(true);
            Staff.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Cone.SetActive(false);
            Shield.SetActive(false);
            RepulsiveField.SetActive(false);
            Staff.SetActive(true);
            explosionParticle.SetActive(false);
        }
    }
}
