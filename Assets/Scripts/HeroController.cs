using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public Gun gun;

    public float speed = 3f;
    public float rotateSpeed = 180f;

    void Update()
    {
        float v = Input.GetAxis("Vertical");

        Vector3 offset = Vector3.zero;

        if (Input.GetMouseButtonUp(0))
        {
            gun.shoot();
            animator.SetBool("Shoot", true);
        }
        else
        {
            animator.SetBool("Shoot", false);
        }

        if (controller.isGrounded)
        {
            if (v != 0)
            {
                offset = transform.forward * v * speed * Time.deltaTime;
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

        }
        offset += Physics.gravity * Time.deltaTime;
        controller.Move(offset);
    }

    void damage()
    {
        Game_Manager.instance.deadUnit(gameObject);
    }
}
