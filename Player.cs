using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player obj;

    public int lives = 3;
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isInmune = false;
    public float speed = 5f;
    public float jumpForce = 3f;

    public float movHor;
    public float inmuneTimeCnt = 0f;
    public float inmuneTime = 0.5f;

    public LayerMask groundLayer;
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;

    //Tengo que ponerlo en public para que el personaje pueda saltar cuando aplasta a un enemigo
    public Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;


    private void Awake(){
        obj = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");
        isMoving = (movHor != 0f);
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        if(Input.GetKeyDown(KeyCode.Space)){
            jump();
        }

        flip(movHor);

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isInmune", isInmune);
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    void OnDestroy() {
        obj = null;    
    }
    

    public void getDamage(){
        lives --;
        if(lives <= 0){
            this.gameObject.SetActive(false);
            Game.obj.gameOver();
        }
    }

    public void flip(float _xValue){
        Vector3 theScale = transform.localScale;

        //Al parecer va a hacer un efecto espejo en la animación de correr del personaje
        if(_xValue < 0){
            theScale.x = Mathf.Abs(theScale.x) * -1;
            transform.localScale = theScale;
        }
        else if(_xValue > 0){
            theScale.x = Mathf.Abs(theScale.x);
            transform.localScale = theScale;
        }
    }

    public void jump(){
        if(!isGrounded) return;

        rb.velocity = Vector2.up * jumpForce;
    }

    public void addLive(){
        lives++;
        if(lives > Game.obj.maxLives){
            lives = Game.obj.maxLives;
        }
    }
}
