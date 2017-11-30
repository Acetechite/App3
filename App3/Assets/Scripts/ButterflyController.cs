using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;
    public GameObject weapon;
    public bool hasRed;
    public bool hasBlue;
    public bool hasGrey;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        weapon.SetActive(false);
        hasRed = false;
        hasBlue = false;
        hasGrey = false;
}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        float x = Input.GetAxis("Horizontal")*Time.deltaTime* 3.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 100.0f;

        rb.velocity = transform.forward*-z;
        rb.AddRelativeTorque(0,x,0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gun")
        {
            Destroy(other.gameObject);
            weapon.SetActive(true);
            hasGrey = true;
        }
        else if(other.gameObject.tag == "RedShroom"){
            Destroy(other.gameObject);
            hasRed = true;
        }
        else if (other.gameObject.tag == "BlueShroom")
        {
            Destroy(other.gameObject);
            hasBlue = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "RedWall" && hasRed)
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "BlueWall" && hasBlue)
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "GreyWall" && hasGrey)
        {
            Destroy(collision.gameObject);
        }
    }
}
