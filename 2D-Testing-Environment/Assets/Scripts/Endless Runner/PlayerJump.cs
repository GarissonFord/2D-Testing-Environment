using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    public float weakJumpForce;
    public bool grounded;

    public Transform groundCheck;

    public int numJumps, maxJumps;

    public int scoreMultiplier;

    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(grounded)
        {
           
        }

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            if(grounded)
            {
                Jump(jumpForce);
            }

            if (!grounded && numJumps < maxJumps)
                Jump(weakJumpForce);

            if(scoreMultiplier > 0)
                scoreMultiplier--;
        }

        /*
        if (Input.GetButtonDown("Jump") && grounded)
            rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            */
    }

    public void Jump(float jumpForce)
    {
        rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        numJumps++;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject coll = collision.gameObject;
        if(coll.CompareTag("Ground"))
        {
            Debug.Log(scoreMultiplier);
            gc.UpdateScore(scoreMultiplier);
            numJumps = 0;
            scoreMultiplier = 5;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Boundary"))
        {
            SceneManager.LoadScene("EndlessRunner");
        }
    }
}
