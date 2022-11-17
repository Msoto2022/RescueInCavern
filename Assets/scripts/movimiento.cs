using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{   
    public float Speed;
    public float JumpForce;
    public float SaltosMaximos;
    public LayerMask capaSuelo;


    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private float SaltosRestantes;
 
    private Animator animator;
    private BoxCollider2D boxcollider;
    void Start()
    {
        Rigidbody2D =GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();

        SaltosRestantes = SaltosMaximos;

        
       
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if(Horizontal != 0f)
        {
            animator.SetBool("isRunning",true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
       

        Jump();
        
    }
    
    bool Suelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, new Vector2(boxcollider.bounds.size.x,boxcollider.bounds.size.y), 0f,Vector2.down, 0.2f,capaSuelo);
        return raycastHit.collider!=null;
    }
    private void Jump()
    {
        Debug.Log(SaltosRestantes);
        if(Suelo())
        {
            SaltosRestantes = SaltosMaximos;
        }
        if (Input.GetKeyDown(KeyCode.W) && SaltosRestantes > 0)
        {
            SaltosRestantes --;
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
        

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed ,Rigidbody2D.velocity.y);
    }
}
