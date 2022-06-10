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

    public GameObject playerItemDrop;

    public bool canMove;

    private Animator anim;

    public int lastScene = 0;

    private DialogueManager dMAn;
    public string[] names;
    public string[] dialogueLines;

    float speed = 0;
    public AudioSource bedroomFootsteps;
    public AudioSource hallwayFootsteps;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        bedroomFootsteps.Stop();
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

        dMAn = FindObjectOfType<DialogueManager>();
        dMAn.dialogLines = dialogueLines;
        dMAn.names = names;
        dMAn.currentLine = 0;
        dMAn.ShowDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "KitchenAfter")
        {
            anim.SetBool("afterMinigame", true);
        }
        if (!canMove && scene.name != "KitchenAfter")
        {
            myRigidbody.velocity = Vector2.zero;
            anim.Play("Player_Idle");
            return;
        }

        speed = myRigidbody.velocity.magnitude;
        if (scene.name == "house_inside")
        {
            if (speed > 0 && bedroomFootsteps.isPlaying == false)
            {
                bedroomFootsteps.Play();
            }
            else if (speed == 0)
            {
                bedroomFootsteps.Stop();
            }
        }
        else if (scene.name == "Hallway")
        {
            if (speed > 0 && hallwayFootsteps.isPlaying == false)
            {
                hallwayFootsteps.Play();
            }
            else if (speed == 0)
            {
                hallwayFootsteps.Stop();
            }
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (lastScene)
        {
            case 0:
                transform.position = FindObjectOfType<SpawnPointManager>().spawnPoints[0].transform.position;
                GameManager.gm.spawnPoint = FindObjectOfType<SpawnPointManager>().spawnPoints[0];
                return;
            case 1:
                transform.position = FindObjectOfType<SpawnPointManager>().spawnPoints[1].transform.position;
                GameManager.gm.spawnPoint = FindObjectOfType<SpawnPointManager>().spawnPoints[1];
                return;
            case 2:
                transform.position = FindObjectOfType<SpawnPointManager>().spawnPoints[2].transform.position;
                GameManager.gm.spawnPoint = FindObjectOfType<SpawnPointManager>().spawnPoints[2];
                return;
            case 3:
                transform.position = FindObjectOfType<SpawnPointManager>().spawnPoints[3].transform.position;
                GameManager.gm.spawnPoint = FindObjectOfType<SpawnPointManager>().spawnPoints[3];
                return;
        }
        
    }
}
