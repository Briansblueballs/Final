using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public float damage = 10f;
    public float range = 100f;
    public Camera fpscam;
    public ParticleSystem flash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//left mouse click it calls our void shoot and the particle system
        if (Input.GetButtonDown("Fire1"))
        {//plays sound
            source.PlayOneShot(clip);
            //uses the shoot
            shoot();
        }
    }

    void shoot()
    {//uses the particle system
        flash.Play();

        RaycastHit hit;
        //bassicaly if something connects with the raycasts range it tells the name and looks at the target code to deal damage
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            //uses our target code and causes our other code to be refrenced letting us damage the enemy
           target Target = hit.transform.GetComponent<target>();
            if(Target != null)
            {
                Target.TakeDamage(damage);       
            }
        }

    }
}
