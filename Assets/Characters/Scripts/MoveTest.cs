using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MoveTest : MonoBehaviour {

    public float RunSpeed;
    public float SideSpeed;
    public Vector3 JumpSpeed;
    private int Rail;

    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(rb);
        
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
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(2, transform.position.y, transform.position.z), ref speed, 0.05f);
                }
                break;
            case -1:
                {
                    //transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                    Vector3 speed = Vector3.zero;
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-2, transform.position.y, transform.position.z), ref speed, 0.05f);
                }
                break;
            default :
                {
                    //transform.position = new Vector3(0, transform.position.y, transform.position.z);
                    Vector3 speed = Vector3.zero;
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, transform.position.y, transform.position.z), ref speed, 0.05f);
                }
                break;

        }
        
        //Jump

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Préparation saut
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity = JumpSpeed;
            v.y = JumpSpeed.y;
            //Saut
            gameObject.GetComponent<Rigidbody>().velocity = JumpSpeed;
            //Raycast
            
        }
    }

}
