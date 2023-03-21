using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class ConeAttack : MonoBehaviour
{

    public float damage = 2f;
    public float firstRate = 1f;
    public float range = 20f;
    public float force = 155;
    public AudioClip shotSFX;
    public AudioSource _audioSource;
    public Transform bulletSpawn;
    public Camera _cam;
    public Animator animator;
    private float nextFire = 0f;
    public GameObject hitEffectDefault;
    [SerializeField] int weaponDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    async void Shoot()
    {
        //_audioSource.PlayOneShot(shotSFX);
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range))
        {
            var enemyNavMesh = hit.transform.GetComponent<NavMeshAgent>();
            
            GameObject impact = Instantiate(hitEffectDefault, hit.point, Quaternion.LookRotation(hit.normal));

            if (hit.transform.gameObject.GetComponent<HpSystemEnemy>())
                hit.transform.gameObject.GetComponent<HpSystemEnemy>().GetDamage(weaponDamage);
            enemyNavMesh.enabled = false;
            await Task.Delay(1070);
            enemyNavMesh.enabled = true;
            Destroy(impact, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / firstRate;
            animator.SetTrigger("Attack");
        }
    }
}
