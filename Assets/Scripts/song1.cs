using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class song1 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public GameObject Espawner;
    public float sTime;
    public float sDelay;

    // Start is called before the first frame update
    void Start()
    {//causes our spawn to work in the time we set
        InvokeRepeating("spawn", sTime, sDelay);
    }

    // Update is called once per frame
    void spawn()
    {
        //sets the positions of our gameobject randomly in the ranges set
        Vector3 RandomSpawnPosition = new Vector3(Random.Range(-20, -11), 10, Random.Range(0, -5));
        //actually makes our objects
        Instantiate(Espawner, RandomSpawnPosition, Quaternion.identity);
        source.PlayOneShot(clip);
    }
}