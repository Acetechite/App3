using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        float x = Input.GetAxis("Horizontal")*Time.deltaTime* 3.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 100.0f;

        rb.velocity = transform.forward*-z;
        rb.AddRelativeTorque(0,x,0);
        
    }
}
