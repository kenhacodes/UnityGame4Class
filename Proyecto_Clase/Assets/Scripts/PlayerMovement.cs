using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -11f;
    public float jumpHeight = 1.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LifeAndEnergyMeter LEM;

    public Vector3 velocity;
    public bool isGrounded;
    public float currentSpeed;
    public float energyUse = 0.1f;
    public float jumpEnergyUse = 20f;
    private Coroutine regen;
    private WaitForSeconds regenTick = new WaitForSeconds(0.01f);

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift) && LEM.energy > 0)
        {
            currentSpeed *= 1.5f;
            LEM.energy -= energyUse;
            if (regen != null)
            {
                StopCoroutine(regen);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            regen = StartCoroutine(FillEnergy());
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (!isGrounded)
        {
            currentSpeed += speed / 3;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && LEM.energy > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            LEM.energy -= jumpEnergyUse;

            if (regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(FillEnergy());
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private IEnumerator FillEnergy()
    {
        yield return new WaitForSeconds(1.5f);
        
        while (!LEM.isMaxEnergy)
        {
            LEM.energy += LEM.maxEnergy / 1000;
            yield return regenTick;
        }
        regen = null;
    }
}
