using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MoveTest : MonoBehaviour {

    public float RunSpeed;
    public float SideSpeed;
    public float JumpSpeed;
    private int Rail;
    private BoxCollider characterCollider;
    public int PV = 3;
    public Animator MyAnim;

    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(rb);
        characterCollider = gameObject.GetComponent<BoxCollider>();
    }
    private void Update()
    {
        //Run
        transform.Translate(Vector3.forward * RunSpeed * Time.deltaTime);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        //Rail
        Rail = 0;
        if (Input.GetKey(KeyCode.D))
        {
            Rail = 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Rail = -1;
        }
        
        switch (Rail)
        {
            case 1:
                {
                    //transform.position = new Vector3(2, transform.position.y, transform.position.z);
                    Vector3 speed = Vector3.zero;
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(2, transform.position.y, transform.position.z), ref speed, 0.035f);
                }
                break;
            case -1:
                {
                    //transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                    Vector3 speed = Vector3.zero;
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-2, transform.position.y, transform.position.z), ref speed, 0.035f);
                }
                break;
            default:
                {
                    //transform.position = new Vector3(0, transform.position.y, transform.position.z);
                    Vector3 speed = Vector3.zero;
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, transform.position.y, transform.position.z), ref speed, 0.035f);
                }
                break;

        }
        

        if (rb.velocity.y >= -0.08 && rb.velocity.y <= 0.08)
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.Z))
            {
                rb.AddForce(transform.up * JumpSpeed, ForceMode.Impulse);
                characterCollider.size = new Vector3(characterCollider.size.x, 2.0f, characterCollider.size.z);
                characterCollider.center = new Vector3(characterCollider.center.x, 0.5f, characterCollider.center.z);
                MyAnim.SetTrigger("Jump");
            }


            //Slide
            else if (Input.GetKey(KeyCode.S))
            {
                characterCollider.size = new Vector3(characterCollider.size.x, 1f, characterCollider.size.z);
                characterCollider.center = new Vector3(characterCollider.center.x, 0f, characterCollider.center.z);
                MyAnim.SetTrigger("Glissade");

            }
            else
            {
                characterCollider.size = new Vector3(characterCollider.size.x, 2.0f, characterCollider.size.z);
                characterCollider.center = new Vector3(characterCollider.center.x, 0.5f, characterCollider.center.z);
            }
        }        
    }
    public void takeDamage(int damage)
    {
        PV -= damage;
        Debug.Log(PV);
        if (PV <= 0)
        {
            MyAnim.SetTrigger("Mort");
            Debug.Log(PV);
        }
    }

}

