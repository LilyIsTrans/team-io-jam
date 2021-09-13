using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    float accel = 0f;
    public float hoverHeight;
    public float hoverStrength; //A multiplier to the output of the smooth wave generator to determine the max and min height of the bobbing
    public float maxAccel;
    public GameObject road;
    byte index; //Keeps track of index in lookup table
    float[] sineLookup = new float[256]; //Lookup table for sine values (so we don't need to compute them at runtime)

    void Start()
    {

        for (float i = 0; i <= 255; i++)
        {
            sineLookup[(int)i] = (Mathf.Sin(Mathf.Deg2Rad * (i * (360f / 255f))) * hoverStrength);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        accel = Input.GetAxis("Accelerator") * maxAccel;
        GetComponent<Rigidbody>().velocity = this.transform.forward * accel;



        this.transform.Rotate(new Vector3(0, Input.GetAxis("Steering"), 0));

        roadFollow();
    }

    void roadFollow()
    {
        RaycastHit hit;
        float roadY;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            roadY = hit.point.y;
            Vector3 Position = this.GetComponent<Transform>().position;
            this.GetComponent<Transform>().position = new Vector3(Position.x, roadY + hoverHeight + sineLookup[index], Position.z);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
        index++;
    }
}
