using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camM : MonoBehaviour
{
    public Transform campos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {//makes our camera empty game object follow the empty game object on our player
        transform.position = campos.position;
    }
}