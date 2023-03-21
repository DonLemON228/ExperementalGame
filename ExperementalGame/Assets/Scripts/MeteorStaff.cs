using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class MeteorStaff : MonoBehaviour
{
    public float range = 20f;
    public Transform bulletSpawn;
    public Camera _cam;
    public Animator animator;
    private float nextFire = 0f;
    public float force = 155;
    public float gravityForse = 155;
    public ParticleSystem slash;
    public float timer = 100;
    public bool CanOnTimer = false;
    public bool canAttack = true;
    [SerializeField] int coolDownTime = 120;

    [SerializeField] GameObject CoolDownTimer;
    [SerializeField] Slider CoolDownSlider;
    public float timeLeft = 60;
    private float gameTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range) )
        {

            if(hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<NavMeshAgent>().enabled = false;
                hit.transform.GetComponent<EnemyMove>().enabled = false;
                var enemyAnim = hit.transform.GetComponent<Animator>();
                enemyAnim.SetTrigger("Floating");
                var enemyRigiBody = hit.transform.GetComponent<Rigidbody>();
                enemyRigiBody.useGravity = false;
                enemyRigiBody.AddForce(enemyRigiBody.transform.up * gravityForse);
            }

            

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }

    void Impact()
    {
        slash.Play();
    }

    IEnumerator CoolDown()
    {
        CoolDownTimer.SetActive(true);
        canAttack = false;
        yield return new WaitForSeconds(coolDownTime);
        canAttack = true;
        CoolDownTimer.SetActive(false);
    }

    void Timer()
    {
        CoolDownSlider.value = timeLeft;
        gameTime += 1 * Time.deltaTime;

        if (gameTime >= 1)
        {
            timeLeft -= 1;
            gameTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && canAttack == true)
        {
            animator.SetTrigger("Attack");
            StartCoroutine(CoolDown());
        }
        if (canAttack == false)
        {
            Timer();
        }
        else
        {
            timeLeft = coolDownTime;
        }
    }
}
