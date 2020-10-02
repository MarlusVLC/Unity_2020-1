using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

[SelectionBase]


public class Shoot : MonoBehaviour
{
    public GameObject player;
    public GameObject laserBeam;
    public GameObject mainCamera;
    private Rigidbody rb;
    //Velocidade do tiro
    public float laserSpeed;

    public AudioClip tiro;
    public AudioSource audior;
    // Start is called before the first frame update
    void Start()
    {
        audior = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Atira com o 'Z'
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audior.clip = tiro;
            audior.pitch = Random.Range(0.7f,2.0f);
            audior.Play();
            CameraShaker.Instance.ShakeOnce(2.5f, 30f, 0.25f, 0.25f);
            GameObject tempObject;
            tempObject = Instantiate(laserBeam, this.transform.position, player.transform.rotation);
            SelfDestroy sd = tempObject.AddComponent<SelfDestroy>() as SelfDestroy;
            tempObject.transform.Rotate(Vector3.left * 90);
            rb = tempObject.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * -1*(laserSpeed);

        }
    }


}
