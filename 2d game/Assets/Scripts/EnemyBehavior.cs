using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] float movespeed = 1f;

    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            myRigidbody.velocity = new Vector2(movespeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-movespeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this just turns the enemy haha
        //also put transfrom.localscale.y instead of the exsact measure inscase I needed to change the length at some point.
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }


}

