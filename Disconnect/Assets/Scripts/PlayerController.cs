using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;

    private Rigidbody2D myRigidbody;

    private static bool playerExists;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy (gameObject);
        }

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
        }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }

        if(Mathf.Abs (Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            currentMoveSpeed = moveSpeed * diagonalMoveModifier;
        }
        else
        {
            currentMoveSpeed = moveSpeed;
        }
    }
}
