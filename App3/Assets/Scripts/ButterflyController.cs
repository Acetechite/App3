using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButterflyController : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;
    public AudioSource aud;
    public GameObject weapon;
    public Animation anim;
    public bool hasRed;
    public bool hasBlue;
    public bool hasGrey;

    public GameObject RedIm;
    public GameObject BlueIm;
    public GameObject GreyIm;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
        anim = GetComponent<Animation>();
        weapon.SetActive(false);
        hasRed = false;
        hasBlue = false;
        hasGrey = false;
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        float x = Input.GetAxis("Horizontal")*Time.deltaTime* 3.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 100.0f;

        if (z!=0 || x!=0)
        {
            anim.Play();
        }
        else
        {
            anim.Stop();
        }

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
            aud.clip = Resources.Load("Audio/Gun") as AudioClip;
            aud.Play();
            GreyIm.SetActive(true);
        }
        else if(other.gameObject.tag == "RedShroom"){
            Destroy(other.gameObject);
            hasRed = true;
            aud.clip = Resources.Load("Audio/RedShroom") as AudioClip;
            aud.Play();
            RedIm.SetActive(true);
        }
        else if (other.gameObject.tag == "BlueShroom")
        {
            Destroy(other.gameObject);
            hasBlue = true;
            aud.clip = Resources.Load("Audio/BlueShroom") as AudioClip;
            aud.Play();
            BlueIm.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RedWall" && hasRed)
        {
            Destroy(collision.gameObject);
            aud.clip = Resources.Load("Audio/RedWall") as AudioClip;
            aud.Play();
        }
        else if (collision.gameObject.tag == "BlueWall" && hasBlue)
        {
            Destroy(collision.gameObject);
            aud.clip = Resources.Load("Audio/BlueWall") as AudioClip;
            aud.Play();
        }
        else if (collision.gameObject.tag == "GreyWall" && hasGrey)
        {
            Destroy(collision.gameObject);
            aud.clip = Resources.Load("Audio/GreyWall") as AudioClip;
            aud.Play();
        }
    }
    
}
