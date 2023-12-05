using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Animator animator;
    BoxCollider boxCollider;
    CapsuleCollider capsuleCollider;
    Rigidbody rb;
    public Transform player;

    float moveSpeed;
    float maxDist;
    float minDist;

    bool enterAr;
    int hit;
    Sounds ss;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        ss = GameObject.FindGameObjectWithTag("sounds").GetComponent<Sounds>();

        moveSpeed = 3f;
        minDist = 1f;
        maxDist = 300f;
        enterAr = false;
        hit = 0;
    }

    

    public void DestroyZombie()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if ((distance >= minDist && distance <= maxDist) && enterAr)
        {
            Vector3 targetPos = new Vector3(player.position.x, transform.position.y,
                player.position.z);
            transform.LookAt(targetPos);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            if (distance >= 1f && distance <= 1.75f)
            {
                animator.SetInteger("state", 2);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterAr = true;
            animator.SetInteger("state", 1);
            boxCollider.enabled = false;
        }
    }

    public void DamangeZombie()
    {
        hit++;
        
        if (hit == 3)
        {
            ss.ZombieDead();
            enterAr=false;
            animator.SetTrigger("prueba");
            rb.freezeRotation = true;
            rb.isKinematic = true;
            capsuleCollider.enabled = false;
            Player.zombies++;
        }
        else
        {
            ss.ZombieHit();
        }
    }

    public void Walk()
    {
        animator.SetInteger("state", 1);
    }
}
