using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    [Header("movement")]
    public float moveSpeed;
    public float groundDrag;

    public float jumpforce;
    public float jumpCoolDown;
    public float airM;
    bool readytojump;

    [Header("keybinds")]
    public KeyCode jumpkey = KeyCode.Space;


    [Header("Ground Check")]
    public float pHeight;
    public LayerMask whatisground;
    bool grounded;


    public Transform orientation;

    float horizontalInput;
    float verticleInput;

    Vector3 moveD;
    Rigidbody rb;

    // Start is called before the first frame update
   private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //checks to see if we can jump
        readytojump = true;
       
    }

    // Update is called once per frame

    private void Update()
    {//shoots a raycast down
        grounded = Physics.Raycast(transform.position, Vector3.down, pHeight * 0.5f + 0.2f, whatisground);

        myinput();
        speedcontrol();
        //if on the ground drag is applied unless you are jumping
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;


    }
    private void FixedUpdate()
    {
        mPlayer();
    }

    private void myinput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticleInput = Input.GetAxisRaw("Vertical");
        //checks if we are grounded and ready to jump
        if(Input.GetKey(jumpkey) && readytojump && grounded)
        {//if we meet those conditions we can jump, it makes a sound and resets our jump
            readytojump = false;

            jump();
            source.PlayOneShot(clip);

            Invoke(nameof(resetjump), jumpCoolDown);

        }
    }

    private void mPlayer()
    {//makes it so you move where the camera is facing
        moveD = orientation.forward * verticleInput + orientation.right * horizontalInput;
        //lets us move
        if (grounded)
            rb.AddForce(moveD.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveD.normalized * moveSpeed * airM *10f, ForceMode.Force);

      
    }

    private void speedcontrol()
    {//makes it so if your character is moving faster than it should be it gets fixed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void jump()
    {//shoots our charater up
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //apples force intstantly instead of when frames update i believe
        rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
        
    }

        private void resetjump()
        {
            readytojump = true;
        }
}
