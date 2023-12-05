using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerDoor : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void idleOpenDoor()
    {
        animator.SetInteger("estado", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
