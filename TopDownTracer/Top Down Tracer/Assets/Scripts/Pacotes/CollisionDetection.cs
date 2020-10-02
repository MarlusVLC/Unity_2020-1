using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //bool itExists;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Tiro")
        {
            GameObject.Find("Manager").GetComponent<SceneControl>().Packages += 1;
            Destroy(gameObject);
        }
    }
}
