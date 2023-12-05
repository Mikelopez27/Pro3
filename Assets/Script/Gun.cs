using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Animator animator;
    Sounds ss;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ss = GameObject.FindGameObjectWithTag("sounds").GetComponent<Sounds>();
    }

    public void ShutGunAnimator()
    {
        ss.Shoot();
        animator.SetInteger("estado", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
