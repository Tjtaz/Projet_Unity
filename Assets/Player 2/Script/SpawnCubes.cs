using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject CubeObstacle;
    public GameObject CubeObstacles;
    public GameObject SpawnCube;
    public GameObject SpawnCubeL;
    public GameObject SpawnCubeR;
    public GameObject SpawnCubeUP;
    public GameObject SpawnCubeDwn;
    public float coolDown = 1;
    public float coolDownTimer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer >0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (Input.GetKeyDown("kp_uparrow") && coolDownTimer ==0)
        {
            SpawnCubeMiddle();
            coolDownTimer = coolDown;
        }
        if (Input.GetKeyDown("kp_leftarrow") && coolDownTimer == 0)
        {
            SpawnCubeLeft();
            coolDownTimer = coolDown;
        }
        if (Input.GetKeyDown("kp_rightarrow") && coolDownTimer == 0)
        {
            SpawnCubeRight();
            coolDownTimer = coolDown;
        }
        if (Input.GetKeyDown("kp_downarrow") && coolDownTimer == 0)
        {
            SpawnCubeUp();
            coolDownTimer = coolDown;
        }
        if (Input.GetKeyDown("kp_5") && coolDownTimer == 0)
        {
            SpawnCubeDown();
            coolDownTimer = coolDown;
        }
       
    }   

    void SpawnCubeMiddle()
    {
        Instantiate(CubeObstacle, SpawnCube.transform.position, SpawnCube.transform.rotation);
        
    }
    void SpawnCubeLeft()
    {
        Instantiate(CubeObstacle, SpawnCubeL.transform.position, SpawnCubeL.transform.rotation);
        
    }
    void SpawnCubeRight()
    {
        Instantiate(CubeObstacle, SpawnCubeR.transform.position, SpawnCubeR.transform.rotation);
       
    }
    void SpawnCubeUp()
    {
        Instantiate(CubeObstacles, SpawnCubeUP.transform.position, SpawnCubeUP.transform.rotation);
    }
    void SpawnCubeDown()
    {
        Instantiate(CubeObstacles, SpawnCubeDwn.transform.position, SpawnCubeDwn.transform.rotation);
    }
}
