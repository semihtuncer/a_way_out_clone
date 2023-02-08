using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;

        anim.SetBool("OPEN", isOpen);
    }
}
