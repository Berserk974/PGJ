using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float _speed = 10f;
    public float _jumpForce = 100f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // deplacement
        _rb.AddForce(_speed * Input.GetAxis("Horizontal") * transform.right);

        //saut
        bool grounded = Physics2D.OverlapCircle(transform.position + GetComponent<Collider2D>().bounds.extents.y * -transform.up, 0.1f, 1 << LayerMask.NameToLayer("Ground")) != null;
        if (Input.GetKeyDown("z") && grounded)
        {
            _rb.AddForce(_jumpForce * transform.up, ForceMode2D.Impulse);
        }

        //retombée
        if (!grounded && _rb.velocity.y < 0) _rb.gravityScale = 20;
        else _rb.gravityScale = 11;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + GetComponent<Collider2D>().bounds.extents.y * -transform.up, 0.1f);
    }

}
