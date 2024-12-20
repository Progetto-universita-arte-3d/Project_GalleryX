using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public Animator anim;

    private void OnTrigger1Enter(Collider other)
    {
     anim.SetTrigger("DoorTrigger1");
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("DoorTrigger1");
    }
}

