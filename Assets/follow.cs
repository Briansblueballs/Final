using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class follow : MonoBehaviour
{
    public Transform player;
    public float speed;
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //causes the enemy to follow the player
        transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other)
    {//looks for tag 
        if (other.gameObject.CompareTag("u"))
        {//if the tag u is found during collision it destroys the object
            Destroy(gameObject);
            source.PlayOneShot(clip);
        }
    }
}
