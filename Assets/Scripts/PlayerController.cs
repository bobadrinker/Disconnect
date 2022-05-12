using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float currentMoveSpeed;
    //public float diagonalMoveModifier;

    private Rigidbody2D myRigidbody;

    private Vector2 moveInput;

    private static bool playerExists;

    public bool canMove;

    private Animator anim;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

        // Start is called before the first frame update
        void Start()
    {
        anim = GetComponent<Animator>();

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
            anim.Play("Player_Idle");
            return;
        }

        /*if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
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
        }*/

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if(moveInput != Vector2.zero)
        {
            myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);

        } else
        {
            myRigidbody.velocity = Vector2.zero;
        }

        /*if(Mathf.Abs (Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            currentMoveSpeed = moveSpeed * diagonalMoveModifier;
        }
        else
        {
            currentMoveSpeed = moveSpeed;
        }*/
    }

    public int lastScene = 0;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (lastScene)
        {
            case 0:
                transform.position = FindObjectOfType<SpawnPointManager>().spawnPoints[0].transform.position;
                return;
            case 1:
                transform.position = FindObjectOfType<SpawnPointManager>().spawnPoints[1].transform.position;
                Debug.Log(FindObjectOfType<SpawnPointManager>().spawnPoints[1].transform.position);
                return;
            case 2:
                transform.position = FindObjectOfType<SpawnPointManager>().spawnPoints[2].transform.position;
                return;
            case 3:
                transform.position = FindObjectOfType<SpawnPointManager>().spawnPoints[3].transform.position;
                return;
        }
        
    }
}
