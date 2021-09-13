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
    void Update()
    {
        if (Input.GetKey("space")){
            if (accel < 30){
                accel += 1f;
            }
        }
        else {
            if (accel > 0){
                accel -= 0.2f;
            }
        }
        GetComponent<Rigidbody>().velocity = this.transform.forward*accel;
        if (Input.GetKey("right")){
            print("right!");
            this.transform.Rotate(new Vector3(0, 1, 0));
        }
        if (Input.GetKey("left")){
            print("left!");
            this.transform.Rotate(new Vector3(0, -1, 0));
        }
        roadFollow();
    }

    void roadFollow(){
        print(road.transform.position.z);
//        this.transform.Translate(new Vector3(0, 0, road.transform.position.z));
    }
}
