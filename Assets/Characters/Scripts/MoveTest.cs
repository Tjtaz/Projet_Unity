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

    // Update is called once per frame
    void Update()
    {
        //Run
        transform.Translate(Vector3.forward * RunSpeed * Time.deltaTime);
        //Rail
        Rail = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rail = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        { 
            Rail = -1;
        }

        switch (Rail)
        {
            case 1:
                {
                    transform.position = new Vector3(2, transform.position.y, transform.position.z);
                }
                break;
            case -1:
                {
                    transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                    
                }
                break;
            default :
                {
                    transform.position = new Vector3(0, transform.position.y, transform.position.z);
                }
                break;

        }
        
        //Jump

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Préparation saut
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity = JumpSpeed;
            v.y = JumpSpeed.y;
            //Saut
            gameObject.GetComponent<Rigidbody>().velocity = JumpSpeed;
        }
    }

}
