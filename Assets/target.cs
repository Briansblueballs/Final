using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public float health = 50f;
    //public void so we can refrence it later in other code
    public void TakeDamage(float amount) {
        health -= amount;
        if(health <= 0f)
        {
            source.PlayOneShot(clip);
            die();
        }
    

    }

    void die()
    {
        Destroy(gameObject);
    }
      
    
}
