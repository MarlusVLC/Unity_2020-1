using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 4;
    public float timer = 20;
    public float timeMultiplier = 1;
    private bool timeLock15;
    private bool timeLock10;
    private bool timeLock5;


    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        timeLock15 = false;
        timeLock10 = false;
        timeLock5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime * timeMultiplier;
        Debug.Log("Tempo do jogador: " + timer + "\n Tempo arredondado pra baixo: " + Mathf.RoundToInt(timer));
        if (Mathf.RoundToInt(timer) == 15 && !timeLock15)
        {
            health -= 1;
            timeLock15 = true;
        }
        else if (Mathf.RoundToInt(timer) == 10 && !timeLock10)
        {
            health -= 1;
            timeLock10 = true;
        }
        else if (Mathf.RoundToInt(timer) == 5 && !timeLock5)
        {
            health -= 1;
            timeLock5 = true;
        }
        else if (Mathf.RoundToInt(timer) <= 1 && !timeLock5)
        {
            health -= 1;
        }



            //if (Mathf.Floor(timer) % 5 == 0 && !timeLock)
            //{
            //    health -= 1;
            //    timeLock = true;
            //} else
            //{
            //    timeLock = false;
            //}
            Debug.Log("Vidas: " + health);

    }
}

