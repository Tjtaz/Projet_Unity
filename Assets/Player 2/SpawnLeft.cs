using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeft : MonoBehaviour
{
    public GameObject CubeObstacle;
    public GameObject Spawn;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            SpawnCube();

        }
    }
    void SpawnCube()
    {
        Instantiate(CubeObstacle, Spawn.transform.position, Spawn.transform.rotation);
    }
}