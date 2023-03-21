using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Threading.Tasks;

public class RepulsiveField : MonoBehaviour
{

    public Animator animatorSphere;
    public WeaponChange weapon;
    public FirstPersonMovement firstPersonMovement;
    public Crouch crouch;
    public Jump jump;
    public GroundCheck groundCheck;
    public SphereCollider collider;
    public bool canActive = true;
    public bool canAttack = true;
    [SerializeField] int explosionDamage;
    public int coolDownTime = 80;

    [SerializeField] GameObject CoolDownTimer;
    [SerializeField] Slider CoolDownSlider;
    public float timeLeft = 60;
    private float gameTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    async void Exploision()
    {
        Collider[] hitColiders = Physics.OverlapSphere(transform.position, 40.0f);

        foreach (var iter in hitColiders)
        {
            var rigidbody = iter.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(700.0f, transform.position, 40.0f, 10.0f);
                iter.GetComponent<HpSystemEnemy>().GetDamage(explosionDamage);
            }
        }
    }

    void BlockMoveON()
    {
        firstPersonMovement.enabled = false;
        crouch.enabled = false;
        jump.enabled = false;
        weapon.enabled = false;
        canActive = true;
        
    }

    void ColliderOn()
    {
        collider.enabled = true;
    }

    void BlockMoveOff()
    {
        firstPersonMovement.enabled = true;
        crouch.enabled = true;
        jump.enabled = true;
        weapon.enabled = true;
        canActive = false;
        collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var navMesh = other.gameObject.GetComponent<NavMeshAgent>();
            var moveScript = other.gameObject.GetComponent<EnemyMove>();
            var animator = other.gameObject.GetComponent<Animator>();
            moveScript.enabled = false;
            navMesh.enabled = false;
        }
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
    async void Update()
    {
        if (Input.GetButtonDown("Fire1") && groundCheck.isGrounded == true && canActive == false && canAttack == true)
        {
            animatorSphere.SetTrigger("CanAttack");
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
