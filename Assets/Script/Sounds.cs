using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour

{
    AudioSource audioSource;
    public AudioClip zombiehit, zombiedead, key, door,shoot;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZombieHit()
    {
        audioSource.PlayOneShot(zombiehit);
    }
    public void ZombieDead()
    {
        audioSource.PlayOneShot(zombiedead);
    }
    public void DoorOpen()
    {
        audioSource.PlayOneShot(door);
    }
    public void keyCollect()
    {
        audioSource.PlayOneShot(key);
    }
    public void Shoot()
    {
        audioSource.PlayOneShot(shoot);
    }
}
