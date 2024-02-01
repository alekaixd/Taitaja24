using UnityEngine;

public class Enemy1AI : MonoBehaviour
{
    
    public float moveSpeed = 2f;
    [SerializeField] private bool isFacingRight = true;
    private Rigidbody2D rb;

    public Transform groundCheck2;
    public Transform groundCheck1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = new Vector2(isFacingRight ? moveSpeed : -moveSpeed, 0f);

        // Käytä Rigidbodyn liikuttamiseen
        rb.velocity = movement;

        // Käännä suuntaa, jos törmätään esteeseen tai reunukseen
        if (!IsGrounded() || IsBlocked())
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Tee jotain kun välilyöntinäppäintä painetaan
            Flip();
        }
    }

    private bool IsGrounded()
    {
        // Tarkista, onko Goomba törmännyt esteeseen (voit laajentaa tätä tarvittaessa)
        Collider2D hitCollider = Physics2D.OverlapCircle(groundCheck2.position, 0.05f, LayerMask.GetMask("Ground"));

        return hitCollider != null;
    }

    private bool IsBlocked()
    {
        // Tarkista, onko Goomba törmännyt esteeseen (voit laajentaa tätä tarvittaessa)
        Collider2D hitCollider = Physics2D.OverlapCircle(groundCheck1.position, 0.05f, LayerMask.GetMask("Ground"));

        return hitCollider != null;
    }


    private void Flip()
    {
        // Käännä Goomba toiseen suuntaan
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
