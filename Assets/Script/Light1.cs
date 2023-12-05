using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light1 : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnLight()
    {
        animator.SetInteger("estado", 2);
    }

    public void OffLight()
    {
        animator.SetInteger("estado", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        
            animator.SetInteger("estado", 1);
        
    }

    private void OnTriggerExit(Collider other)
    {
        
            animator.SetInteger("estado", 3);

        
    }
}
