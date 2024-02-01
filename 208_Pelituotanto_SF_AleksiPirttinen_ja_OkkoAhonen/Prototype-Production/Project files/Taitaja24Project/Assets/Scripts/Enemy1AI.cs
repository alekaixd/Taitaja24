using UnityEngine;

public class Enemy1AI : MonoBehaviour
{
    
    public float moveSpeed = 2f;
    [SerializeField] private bool isFacingRight = true;
    private Rigidbody2D rb;

    public Transform groundCheck2;
    public Transform groundCheck1;
    public GameObject detectionZone;

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

        

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Tee jotain kun välilyöntinäppäintä painetaan
            Flip();
        }
    }

    private void Flip()
    {
        // Käännä Goomba toiseen suuntaan
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnCollisionExit(Collision collision)
    {
    }
}
