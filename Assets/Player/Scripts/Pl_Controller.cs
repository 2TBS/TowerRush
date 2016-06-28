﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class state
{
    public string name = "Stand";
    public float speed;
    public float height;
    public Vector3 center;
    public Vector3 camPos;
}

public class Pl_Controller : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    public Pl_Values plValues;
    public float hor;
    public float ver;
    public int state;
    public bool running;
    private Pl_InputManager input;
    public bool grounded;

    public state[] states = new state[3];
    private state curState;

    public Transform adjTrans;

    private float adjvar = 1;

    void Start() {
        input = GetComponentInParent<Pl_InputManager> ();
    }
    void Update()
    {
            if (controller.isGrounded)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
            CheckState();
            CheckInput();
            if (controller.isGrounded)
            {

                if(Input.GetKey(input.GetKey(1))) ver = -1f;
                else if(Input.GetKey(input.GetKey(2))) ver = 1f;
                else ver = 0f;
                if(Input.GetKey(input.GetKey(3))) hor = 1f;
                else if(Input.GetKey(input.GetKey(4))) hor = -1f;
                else hor = 0f;

                if (Mathf.Abs(ver) > 0.1f && Mathf.Abs(hor) > 0.1f)
                {
                    adjvar = -0.701f;
                }
                else
                {
                    adjvar = -1f;
                }

                moveDirection = new Vector3(hor * adjvar, -1f, ver * adjvar);
                moveDirection = transform.TransformDirection(moveDirection);
                //Debug.Log(moveDirection);
                moveDirection *= speed;
                if (Input.GetKeyDown(input.GetKey(5)))
                {
                    if (state == 0)
                    {
                        moveDirection.y = jumpSpeed;
                    }
                    else if (state == 1)
                    {
                        state = 0;
                    }
                    else if (state == 2)
                    {
                        state = 1;
                    }
                }

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            SetPlValues();
            //Debug.Log(moveDirection);
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.C) && controller.isGrounded)
        {
            if (state == 0)
            {
                state = 1;
            }

            else if (state == 1)
            {
                state = 0;
            }
            //else if (state == 2) state = 1;
        }
        running = (controller.isGrounded && controller.velocity.magnitude > 1 && state == 0 && Input.GetKey(input.GetKey(6)) && Input.GetKey(input.GetKey(1)) && !Input.GetKey(input.GetKey(2)));
    }

    void CheckState()
    {
        if (running)
        {
            curState = states[0];
        }
        else if (state == 0)
        {
            curState = states[1];
        }
        else if (state == 1)
        {
            curState = states[2];
        }

        speed = curState.speed;
        controller.height = curState.height;
        controller.center = curState.center;
        //adjTrans.localPosition = Vector3.Lerp(adjTrans.localPosition, curState.camPos, Time.deltaTime * 10);
    }

    void SetPlValues()
    {
        plValues.hor = hor;
        plValues.ver = ver;
        plValues.speed = speed;
        plValues.running = running;
        plValues.state = state;
        plValues.grounded = grounded;
    }
}
