using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPackage : MonoBehaviour
{
    public AudioSource audioP;

    // Start is called before the first frame update
    void Start()
    {
        audioP = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount < 1)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tiro")
        {
            audioP.pitch = Random.Range(1.0f, 2.0f);
            audioP.Play();

        }
    }
}


