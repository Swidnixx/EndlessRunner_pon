using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5;
    public LayerMask groundMask;
    Rigidbody2D rb;
    BoxCollider2D boxCol;
    bool grounded;
    bool doubleJumped; // true - means that double jump is not accesible anymore

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast( boxCol.bounds.center, boxCol.bounds.size, 0, Vector2.down, 0.1f, groundMask);
        grounded = hit.collider != null;
        
        if(Input.GetMouseButtonDown(0))
        {
            if(grounded)
            {
                Vector2 force = new Vector2(0, jumpForce);
                rb.velocity = force;
                doubleJumped = false;
            }
            else if( !doubleJumped )
            {
                Vector2 force = new Vector2(0, jumpForce);
                rb.velocity = force;
                doubleJumped = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (boxCol == null) return;

        //Raycast debug
        Color c = grounded ? Color.green : Color.red;
        Gizmos.color = c;
        Gizmos.DrawWireCube(boxCol.bounds.center + Vector3.down * 0.1f, boxCol.bounds.size);
    }
}
