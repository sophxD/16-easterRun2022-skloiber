using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string tagGround = "Ground";
    private const string tagObstacle = "Obstacle";
    private Rigidbody2D rb;
    private Animator anim;
    private bool grounded;
    private bool gameOver = false;

    //anim2, anim3, anim4, anim5;
    [SerializeField] 
    private float jumpForce;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !gameOver && !gameOver && !gameOver)
        {
            if (grounded)
            {
                jump();
            }
        }
    }

    void jump()
    {
        grounded = false;

        rb.velocity = Vector2.up * jumpForce;

        anim.SetTrigger("Jump");

        GameManager.instance.IncrementScore();
        Debug.Log("DeleteMe");
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)   
    {
        if(collision.gameObject.tag == tagGround)
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tagObstacle)
        {
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
            anim.Play("SantaDeath");
            gameOver = SetGameOverTrue();
        }
    }
}
