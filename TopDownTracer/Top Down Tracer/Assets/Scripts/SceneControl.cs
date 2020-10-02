using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject player;
    public int Packages= 0;
    public float Timer = 5;
    GameObject Pack;
    public GameObject Package;
    Transform criador;

    // Start is called before the first frame update
    void Start()
    {
        Packages = 0;
        Debug.Log("LoadScene");
    }

    // Update is called once per frame
    void Update()
    {
        
        //Instancia um package em um lugar aleatório em cima da plataforma a cada 5 s
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Pack = Instantiate (Package, new Vector3(Random.Range(-209, 229), 6, Random.Range(-229, 229)), new Quaternion(0, 0, 0, 0)) as GameObject;
            Timer = 10f;
        }

        //Checa a vida do jogador para passar para a cena de fim
        if (player.GetComponent<PlayerManager>().health <= 0)
            SceneManager.LoadScene("Outro");
            
    }
}
