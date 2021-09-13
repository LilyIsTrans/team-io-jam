using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject car;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - car.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = car.transform.position + offset;
    }
}
