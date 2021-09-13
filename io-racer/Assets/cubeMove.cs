using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    float accel = 0f;
    public GameObject road;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        accel = Input.GetAxis("Accelerator") * 30;
        GetComponent<Rigidbody>().velocity = this.transform.forward*accel;

        
        
        this.transform.Rotate(new Vector3(0, Input.GetAxis("Steering"), 0));
        
        roadFollow();
    }

    void roadFollow(){
        print(road.transform.position.z);
//        this.transform.Translate(new Vector3(0, 0, road.transform.position.z));
    }
}
