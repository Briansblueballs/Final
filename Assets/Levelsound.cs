using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelsound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {//when the player hits a item tagged "s" it plays the next level sound effect

        if (other.gameObject.CompareTag("s"))
        {
            source.PlayOneShot(clip);
            
        }
    }
}
