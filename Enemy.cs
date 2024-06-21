using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3f;
    public float movHor = 1f;
    public bool isGroundFloor = true;
    public bool isGroundFront = false;

    public LayerMask groundLayer;
    public float frontGrndRayDist = 0.25f;
    public float floorCheckY = 0.52f;
    public float frontCheck = 0.51f;
    public float frontDist = 0.001f;

    public int scoreGive = 50;
    //Al parecer raycast se usa para el tema de las colisiones
    private RaycastHit2D hit;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
void Update()
{
    //Evitar caer en precipicio
    isGroundFloor = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - floorCheckY), Vector2.down, frontGrndRayDist, groundLayer);
    if (!isGroundFloor)
    {
        movHor = movHor * -1;
    }

    //Choque con paredes
    //Raycast detecta conlisiones y lo toma como true o false
    if (Physics2D.Raycast(transform.position, new Vector2(movHor, 0), frontCheck, groundLayer))
    {
        movHor = movHor * -1;
    }

    //Choque con otro enemigo
    hit = Physics2D.Raycast(transform.position + new Vector3(movHor * frontCheck, 0, 0), new Vector2(movHor, 0), frontDist);

    if (hit.collider != null && hit.collider.CompareTag("Enemy"))
    {
        movHor = movHor * -1;
    }
}


    void FixedUpdate(){
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //Dañará a Player
        if(collision.gameObject.CompareTag("Player")){
            Player.obj.getDamage();
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        //Dañará al enemigo
        if(collision.gameObject.CompareTag("Player")){
            getKilled();
        }
    }

    private void getKilled(){
        gameObject.SetActive(false);
    }
}