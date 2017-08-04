using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCont : MonoBehaviour {


   // public Transform charTrans;//FIXME : change this hardcoded character finder
   

    public float speed=2f;
	// how fast my character moves right to left 2 fps
   


    float jumpCoefficient=300f;
    //How fast my character jump. I'll use this in rigidbody > Addforce


    //After myCharacter jumped we would wanna know if it is grounded or what??
     // if it is not then dont let it to jump again
    bool grounded=true;



	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        //Using Axes for calculating the rotation an next position
        float leftRight = Input.GetAxis("Horizontal");


       

        this.transform.Translate( speed * leftRight * Time.deltaTime , 0 , 0 );
       

        //I need the rigidbody component for jumping to not to calculate jumping and falling. Rigidbody > gravity does that for us
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Debug.Log(grounded);

        //if we are not on the ground then dont let us to jump
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {


            rb.AddForce(Vector2.up * jumpCoefficient);

            //if we jumped , we aint on floor anymore
            grounded = false;
           
        }



	}
    void OnCollisionEnter2D(Collision2D other)

    {

        //We need this for detecting we hit ground objects
        if (other.transform.tag == "ground")
        {
            grounded = true;
        }

       // Debug.Log(grounded);
        Debug.Log(other.transform.tag);
    }

       
}
