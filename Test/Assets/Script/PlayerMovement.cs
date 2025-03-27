using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovementState { idle , running , jumping , falling}

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if ( rb.velocity.y > 1f )
        {
            state = MovementState.jumping;
        }
        else if ( rb.velocity.y < -.1f )
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);

    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}






//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    private Rigidbody2D rb;
//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //if(Input.GetKey("space"))
//        //{
//        //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
//        //}    //长按空格可以飞！！！

//        //if(Input.GetKeyDown("space"))
//        //{
//        //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
//        //}

//        float dirX = Input.GetAxisRaw("Horizontal");
//        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

//        if (Input.GetButtonDown("Jump"))
//        {
//            rb.velocity = new Vector2(rb.velocity.x, 7f);
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    private Rigidbody2D rb;
//    private SpriteRenderer sprite;
//    private Animator anim;

//    private float dirX = 0f;
//    [SerializeField] private float moveSpeed = 7f;
//    [SerializeField] private float jumpForce = 7f;



//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        sprite = GetComponent<SpriteRenderer>();
//        anim = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    private void Update()
//    {
//        dirX = Input.GetAxisRaw("Horizontal");
//        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

//        if (Input.GetButtonDown("Jump"))
//        {
//            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//        }

//        UpdateAnimationState();
//    }
//    private void UpdateAnimationState()
//    {
//        if (dirX > 0f)
//        {
//            anim.SetBool("running", true);
//            sprite.flipX = false;
//        }

//        else if (dirX < 0f)
//        {
//            anim.SetBool("running", true);
//            sprite.flipX = true;
//        }
//        else
//        {
//            anim.SetBool("running", false);
//        }
//    }


//}






////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;

////public class PlayerMovement : MonoBehaviour
////{
////    private Rigidbody2D rb;
////    // Start is called before the first frame update
////    void Start()
////    {
////        rb = GetComponent<Rigidbody2D>();
////    }

////    // Update is called once per frame
////    void Update()
////    {
////        //if(Input.GetKey("space"))
////        //{
////        //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
////        //}    //长按空格可以飞！！！

////        //if(Input.GetKeyDown("space"))
////        //{
////        //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
////        //}

////        float dirX = Input.GetAxisRaw("Horizontal");
////        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

////        if (Input.GetButtonDown("Jump"))
////        {
////            rb.velocity = new Vector2(rb.velocity.x, 7f);
////        }
////    }
////}
















////
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    private Rigidbody2D rb;
//    private SpriteRenderer sprite;
//    private Animator anim;

//    private float dirX = 0f;
//    [SerializeField] private float moveSpeed = 7f;
//    [SerializeField] private float jumpForce = 7f;



//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        sprite = GetComponent<SpriteRenderer>();
//        anim = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    private void Update()
//    {
//        dirX = Input.GetAxisRaw("Horizontal");
//        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

//        if (Input.GetButtonDown("Jump"))
//        {
//            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//        }

//        UpdateAnimationState();
//    }
//    private void UpdateAnimationState()
//    {
//        if (dirX > 0f)
//        {
//            anim.SetBool("running", true);
//            sprite.flipX = false;
//        }

//        else if (dirX < 0f)
//        {
//            anim.SetBool("running", true);
//            sprite.flipX = true;
//        }
//        else
//        {
//            anim.SetBool("running", false);
//        }
//    }


//}






////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;

////public class PlayerMovement : MonoBehaviour
////{
////    private Rigidbody2D rb;
////    // Start is called before the first frame update
////    void Start()
////    {
////        rb = GetComponent<Rigidbody2D>();
////    }

////    // Update is called once per frame
////    void Update()
////    {
////        //if(Input.GetKey("space"))
////        //{
////        //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
////        //}    //长按空格可以飞！！！

////        //if(Input.GetKeyDown("space"))
////        //{
////        //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
////        //}

////        float dirX = Input.GetAxisRaw("Horizontal");
////        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

////        if (Input.GetButtonDown("Jump"))
////        {
////            rb.velocity = new Vector2(rb.velocity.x, 7f);
////        }
////    }
////}
