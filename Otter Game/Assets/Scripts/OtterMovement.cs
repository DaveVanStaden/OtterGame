using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtterMovement : MonoBehaviour
{
    private Rigidbody2D otterBody;

    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        otterBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canMove == true)
        {
            MoveOtter();
        }

        if (Input.GetMouseButtonUp(0) && canMove == true)
        {
            StartCoroutine("JumpCoolDown");
        }

        Turning();
        boundaries();

        //print(canMove);
    }

    private void MoveOtter()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.DrawLine(transform.position, hit.point, Color.red);
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Otter")
            {
                var pos = Camera.main.ScreenToWorldPoint(new Vector2((float)Input.mousePosition.x, (float)Input.mousePosition.y));
                transform.position = new Vector2(pos.x, pos.y);

                if (transform.position.y > 0.1)
                {
                    transform.position = new Vector2(transform.position.x, 0.1f);
                }
            }
        }
    }

    private void OtterJump()
    {
        otterBody.velocity = new Vector2(2, 4);
        //canJump = false;
        //StartCoroutine("JumpCoolDown");
    }

    private void Turning()
    {
        if (otterBody.velocity.y >= 0.01f)
        {
            print("UP WE GO");
            transform.Rotate(0, 0, 5);
        }

        if (otterBody.velocity.y <= 0.01f)
        {
            //transform.Rotate(0, 0, -5);
            //print("DOWN WE GO");
        }
    }

    private void boundaries()
    {
        if (transform.position.y < -4)
        {
            transform.position = new Vector2(transform.position.x, -4);
        }

        if (transform.position.y > 0.15)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if (transform.position.y > 2.6)
        {
            StartCoroutine("StatusQuo");
        }

        if (transform.position.x < -7.5)
        {
            transform.position = new Vector2(-7.5f, transform.position.y);
        }

        if (transform.position.x > 7.5)
        {
            transform.position = new Vector2(7.5f, transform.position.y);
        }

        if (transform.position.y > 2f)
        {
            otterBody.gravityScale = 1;
        }
        else
        {
            otterBody.gravityScale = 0;
        }
    }

    IEnumerator JumpCoolDown()
    {
        yield return new WaitForSeconds(0.2f);
        OtterJump();
    }

    IEnumerator StatusQuo()
    {
        yield return new WaitForSeconds(1.75f);
        otterBody.velocity = Vector2.zero;
    }
}