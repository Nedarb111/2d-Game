using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public int count;
    public TextMeshProUGUI countText;
    public GameObject crab;
  
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    private void Start()
    {
        count = 0;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            count = count + 1;
            Destroy(collision.gameObject);
            SetCountText();

        }
        if(collision.gameObject.CompareTag("Crab"))
        {
            Destroy(crab.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);

        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }
        public void OnLanding ()
    {
        //telling the animator to stop jumping
        animator.SetBool("IsJumping", false);
    }
        void FixedUpdate ()
    {
    //character movement
    controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    jump = false;

    }
}
