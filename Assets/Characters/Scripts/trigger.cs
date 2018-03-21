using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject Hero;
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Hero.GetComponent<MoveTest>().takeDamage(1);
            Debug.Log("ouille");
        }
    }
 }
