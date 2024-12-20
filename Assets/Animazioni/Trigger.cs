using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
     anim.SetTrigger("DoorTrigger");
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("DoorTrigger");
    }
}
