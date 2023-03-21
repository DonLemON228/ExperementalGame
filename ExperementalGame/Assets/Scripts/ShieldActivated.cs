using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShieldActivated : MonoBehaviour
{
    public Animator animatorShield;
    public Animator animatorCube;
    public WeaponChange weapon;
    public Rigidbody rb;
    public GroundCheck groundCheck;
    public bool canActive = true;
    public bool canAttack = true;

    [SerializeField] float coolDownTime = 40;
    [SerializeField] GameObject CoolDownTimer;
    [SerializeField] Slider CoolDownSlider;
    public float timeLeft = 60;
    private float gameTime;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    void BlockMoveON()
    {
        rb.isKinematic = true;
        weapon.enabled = false;
        canActive = true;
    }

    void BlockMoveOff()
    {
        rb.isKinematic = false;
        weapon.enabled = true;
        canActive = false;
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

        if(gameTime >= 1)
        {
            timeLeft -= 1;
            gameTime = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && groundCheck.isGrounded == true && canActive == false && canAttack == true)
        {
            animatorCube.SetTrigger("CubeUse");
            animatorShield.SetTrigger("Apear");
            StartCoroutine(CoolDown());
        }
        
        if(canAttack == false)
        {
            Timer();
        }
        else
        {
            timeLeft = coolDownTime;
        }
    }
}
