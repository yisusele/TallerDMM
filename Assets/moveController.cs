using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveController : MonoBehaviour
{  
    new Rigidbody2D rigidbody;
    Animator animator;

    public float Speed=40;
    // Start is called before the first frame update
    void Start(){
        rigidbody= GetComponent <Rigidbody2D>();
        animator= GetComponent <Animator>();

    }

    // Update is called once per frame
    void Update(){

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if (hor !=0 || ver!=0){

            Vector2 velocity= new Vector2(hor,ver).normalized*Speed;
        rigidbody.velocity = velocity;

        animator.SetFloat("Horizontal",hor);
        animator.SetFloat("Vertical",ver);
        animator.SetBool("Moving",true);
        } else{
             rigidbody.velocity = Vector2.zero;
             animator.SetBool("Moving",false);
        }
    }
}
