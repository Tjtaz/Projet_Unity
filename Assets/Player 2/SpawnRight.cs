﻿



    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRight : MonoBehaviour
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
        if (Input.GetKeyDown("p"))
        {
            SpawnCube();

        }
    }
    void SpawnCube()
    {
        Instantiate(CubeObstacle, Spawn.transform.position, Spawn.transform.rotation);
    }
}
