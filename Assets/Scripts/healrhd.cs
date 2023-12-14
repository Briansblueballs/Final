
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healrhd : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("D"))
        {//refrences our health code and makes it to it subtracts 50
            health.healthammount -= 50;
            source.PlayOneShot(clip);
        }
       
        if(health.healthammount <= 0)
        {
            die();
        }
        
    }
    void die()
    {
        ReloadLevel();


    }
    void ReloadLevel()
    {
        //refernces our current scene and loads it again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}