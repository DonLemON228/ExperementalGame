using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    public Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    [SerializeField] Animator cameraAnim;

    [SerializeField] Slider staminaSlider;
    [SerializeField] float staminaValue;
    [SerializeField] float minValueStamina;
    [SerializeField] float maxValueStamina;
    [SerializeField] float staminaReturn;



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Stamina();

        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey) && staminaValue > 0;

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        if (Input.GetKey(KeyCode.LeftShift) && staminaValue > 0)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                cameraAnim.SetBool("RunCamera", true);
                staminaValue -= staminaReturn * Time.deltaTime * 15;
            }
        }
        else
        {
            cameraAnim.SetBool("RunCamera", false);
            staminaValue += staminaReturn * Time.deltaTime * 10;
        }
    }

    private void Stamina()
    {
        if(staminaValue > 100f)
        {
            staminaValue = 100f;
        }
        staminaSlider.value = staminaValue;

        if((Input.GetKey(KeyCode.LeftShift) && staminaValue <= 0))
        {
            staminaReturn = 0;
        }
        else
        {
            staminaReturn = 2;

        }
    }
}