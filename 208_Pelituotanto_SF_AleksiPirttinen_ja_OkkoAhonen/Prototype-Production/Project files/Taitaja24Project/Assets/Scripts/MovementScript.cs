using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpingPower = 10f;
    [SerializeField] private bool isFacingRight = true;
    //private Animator animator;
    public Rigidbody2D rb2d;
    public Transform groundCheck;
    public LayerMask groundlayer;
    public LayerMask paintlayer;
    public AnimationCurve movementCurve;
    public float time;
    //private SFX SFX;



    private void Start()
    {
        //SFX = GameObject.Find("SFX").GetComponent<SFX>();
        //animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //animator.SetFloat("Hor", horizontal);
        //SFX.PlayJump();
        if (Input.GetButtonDown("Jump") /*&& IsGrounded()Ä*/)
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);

        }
        //animator.SetFloat("Ver", rb2d.velocity.normalized.y);
        if (Input.GetButton("Horizontal"))
        {
            //speed = movementCurve.Evaluate(time);
            time += Time.deltaTime;
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            time = 0;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
    }

    /*private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, LayerMask.GetMask("Ground", "Paint"));
        Debug.Log("Grounded: ");
    }*/

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}