using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float startMoveSpeed; //Liikkumisnopeus muuttuja jota voi muuttaa inspectorissa
    private float moveSpeed; //Liikkumisnopeus
    public float jumpForce; //Hyppyvoima

    int jumpsAmount = 2; //Hyppyjen m‰‰r‰
    public float jumpThreshold; //Kuinka paljon Joystickia pit‰‰ k‰‰nt‰‰ ylˆsp‰in, jotta pelaaja hypp‰isi
    int jumpsLeft; //J‰ljell‰ olevien hyppyjen m‰‰r‰

    public Transform GroundCheck;
    public LayerMask GroundLayer;

    bool isGrounded = true; //Onko pelaaja koskettanut maata

    public Joystick joystick; 
    Rigidbody2D rb2d; // Viittaus rigidbodyyn
    float scaleX; 

    Animator anim;

    public GameObject dialogButton;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
        anim = GetComponent<Animator>();
        moveSpeed = startMoveSpeed;
    }


    void Update()
    {  
        // K‰velemis animaatiota varten tehty animaattorin Speed floatin asetus
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); 
    }


    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Flip();
        rb2d.velocity = new Vector2(joystick.Horizontal * moveSpeed, rb2d.velocity.y); //Lis‰t‰‰n pelaajalle nopeutta joystickin osoittamaan suuntaan, ja kerrotaan se asetetulla nopeudella
    }


    //T‰m‰ funktio k‰‰nt‰‰ pelaajan grafiikan oikeaan suuntaan katsomalla Joystickin arvoa (-1 = t‰ysin vasen, 1 = t‰ysin oikea)
    public void Flip()
    {
        if (joystick.Horizontal > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (joystick.Horizontal < 0)
        {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        }
    }


    // Koodi hyppy‰ varten
    public void Jump()
    {
        CheckIfGrounded();
        if (jumpsLeft > 0)
        {
            AudioManager.instance.Play("Jump");
            anim.SetBool("IsJumping", true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce); //Lis‰t‰‰n pelaajan Y-akselin nopeuteen hyppyvoima
            jumpsLeft--;
            StartCoroutine(ResetJumpAnimation());
            
        }
    }


    // Tarkistaa jos pelaaja osuu maahan
    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer); //isGrounded on tosi, jos pelaajan alle liitetty groundCheck objekti koskee jotain "Ground" tasolla olevaa objektia
        ResetJumps();       
    }

    // Resetoi hypyt
    public void ResetJumps()
    {

        // tarkistaa jos pelaaja on maassa jos on hypyt resetoituvat
        if (isGrounded)
        {   
            
            jumpsLeft = jumpsAmount;
        }
    }


    // Hyppyanimaatio resetti
    IEnumerator ResetJumpAnimation()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsJumping", false);
    }
}
