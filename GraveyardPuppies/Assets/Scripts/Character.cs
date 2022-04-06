using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Character : MonoBehaviour
{
    //*********************** MUUTTUJAT JA TARVITTAVAT KOMPONENTIT ***********************//

    private float Speed = 10; // Kävelynopeus
    private float Force = 400;

    // Publicit näkyy käyttöliittymässä scriptin kohdalla (ja toisilla scripteillä on niihin pääsy?) ja niihin voi esim. vetää objecteja tms
    //public bool grounded = true; //false // Tämä voisi olla private, mutta koska hahmon hyppimisessä on vielä häikkää halusin nähdä näkyykö hahmo miten groundedina
   // public Transform GroundCheck; // Groundedid yms toimii sinänsä, hahmo ei putoa maan läpi
   // public LayerMask groundLayer;
    public bool facingRight; // Tätä tarvitaan hahmon kääntämiseen

    private Animator animator; // Animaatiot
    private Rigidbody2D rb2d; // Fysiikat

    /*
    // Animaatioiden vastaavat intit
    const int idle = 0;
    const int run = 1;
    const int jump = 2;*/
    //const int fall = 3;

   // bool jumping;

    private float dirX; // Hahmon suunta
    private Vector3 theScale;



    //*********************** START, MITÄ KAIKKEA TEHDÄÄN OHJELMAN KÄYNNISTYESSÄ ***********************//

    void Awake()
    {
        animator = GetComponent<Animator>();
       // grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        theScale = transform.localScale;
    }

    //*********************** VARSINAINEN PELI ***********************//

    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * Speed;

        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb2d.velocity.y == 0)
        {
            rb2d.AddForce(Vector2.up * Force);    
        }

        if (Mathf.Abs(dirX) > 0 && rb2d.velocity.y == 0)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }
      
        if (rb2d.velocity.y > 0)
        {
            animator.SetInteger("state", 2);
        }
        if (rb2d.velocity.y < 0)
        {
            animator.SetInteger("state", 3);
        }

        //float horizontal = Input.GetAxis("Horizontal");

        /* HandleJumpFall();

         // Hahmon liikuttamiseen tarvittavat inputit
         float horizontal = Input.GetAxis("Horizontal");

         // Hyppy

             if ((Input.GetKeyDown(KeyCode.Space)))
             {
                 //grounded = false;
                 jumping = true;
                 animator.SetInteger("state", 2);

                 //transform.Translate(Vector3.up * 90 * Time.deltaTime, Space.World);
                 //rb2d.velocity = Vector2.zero;
                 //rb2d.AddForce(new Vector2(0, Force));
                 rb2d.AddForce(new Vector2(rb2d.velocity.x, Force));
                // grounded = true;
             }
             else if (horizontal != 0)
             {
                 //grounded = true;
                 // Idlestä run animaatioon
                 animator.SetInteger("state", 1);
                 // Liikkuu
                 transform.Translate(new Vector3(horizontal * Time.deltaTime * Speed, 0, 0));
             }
             else
             {
                 //grounded = true;
                 animator.SetInteger("state", 0);
             }


         if (Input.GetKeyDown(KeyCode.Space))
         {
             animator.SetInteger("state", 3);
         }*/

        // Kääntää hahmon
        if (dirX > 0 && !facingRight)
        {
            Flip();
        }
        else if (dirX < 0 && facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(dirX, rb2d.velocity.y);
    }

    /* void HandleJumpFall()
     {
         if (jumping)
         {
             if (rb2d.velocity.y > 0)
             {
                 animator.SetInteger("state", 3);
             }
             else
             {
                 animator.SetInteger("state", 1);
             }
         }
     }*/

    //*********************** FUNKTIO MILLÄ HAHMO KÄÄNTYY ***********************//

    void Flip()
    {
        facingRight = !facingRight;
        //Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Kääntää hahmon x-akselilla
        transform.localScale = theScale;
    }
}
