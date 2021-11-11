using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

    public CharacterController2D controller;
  
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    



    // Update is called once per frame
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("jump"))

    }
        void FixedUpdate ()
    {
    //character movement
    controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);

    }
}
