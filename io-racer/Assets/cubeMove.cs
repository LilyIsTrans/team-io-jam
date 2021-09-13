using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    float accel = 0f;
    public float hoverHeight;
    public float maxAccel;
    public GameObject road;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        accel = Input.GetAxis("Accelerator") * maxAccel;
        GetComponent<Rigidbody>().velocity = this.transform.forward*accel;

        
        
        this.transform.Rotate(new Vector3(0, Input.GetAxis("Steering"), 0));
        
        roadFollow();
    }

    void roadFollow(){
        RaycastHit hit;
        float roadY;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            roadY = hit.point.y;
            Vector3 Position = this.GetComponent<Transform>().position;
            this.GetComponent<Transform>().position = new Vector3(Position.x, roadY + hoverHeight, Position.z);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
