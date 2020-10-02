using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 30;
    public Vector3 linearMovement;
    public float y_speed = 100;
    public Vector3 angularMovement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

 
    }

    void FixedUpdate()
    {
        float translation = -1 * (Input.GetAxis("Vertical"));
        linearMovement = transform.forward * translation * speed;
        float rotation = (Input.GetAxis("Horizontal"));
        angularMovement = new Vector3(0, rotation, 0);
        rb.velocity = linearMovement;
        Quaternion deltaRotation = Quaternion.Euler(angularMovement * Time.deltaTime * y_speed);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }


}
