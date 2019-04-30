using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    public string input;
    public Sprite sprIdle;
    public Sprite sprJump;
    public Sprite sprDmg;
    private bool isDead = false;

    private bool hasJumped = false;
    private float timeSinceJump = 0;
    private float jumpDuration = 0.5f;

    private Animator anim;                
    private Rigidbody2D rb2d;               

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead == false)
        {
            if (hasJumped && timeSinceJump <= jumpDuration)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprJump;
                timeSinceJump += Time.deltaTime;
            }
            else
            {
                timeSinceJump = 0;
                gameObject.GetComponent<SpriteRenderer>().sprite = sprIdle;
                hasJumped = false;
            }

            if (Input.GetKeyDown(input))
            {
                timeSinceJump = 0;
                hasJumped = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = sprJump;
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;
        // If the bird collides with something set it to dead...
        isDead = true;

        Destroy(this.gameObject);
        //...tell the Animator about it...
        //anim.SetTrigger("Die");
        //...and tell the game control about it.
        //GameControl.instance.BirdDied();
    }
}