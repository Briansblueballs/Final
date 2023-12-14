using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class health : MonoBehaviour
{
    public TextMeshProUGUI healthtext;
    public static float healthammount;


    // Start is called before the first frame update
    void Start()
    {//sets the amount everytime we start the game
        healthammount = 100f;
    }

    // Update is called once per frame
    void Update()
    {//displays our health
        healthtext.text = "Health:" + Mathf.Round(healthammount);
    }
}
