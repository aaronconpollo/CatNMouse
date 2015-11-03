using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Transform cat;
	Rigidbody rbody;
	public AudioSource scream;
	
	void Start () {
		rbody = GetComponent<Rigidbody>();
	}

	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 directionToCat = cat.position - transform.position;
		float angle = Vector3.Angle(transform.forward, directionToCat);

		if (angle < 180f) {

			Ray mouseRay = new Ray (transform.position, directionToCat);	
			RaycastHit mouseRayHitInfo = new RaycastHit();

			if (Physics.Raycast (mouseRay, out mouseRayHitInfo, 100f))
			{
				if(mouseRayHitInfo.collider.tag == "Cat" )
				{
					scream.Play();
					rbody.AddForce (-directionToCat.normalized * 1000f);

				}
			}
		}
	}
}

/* declare a public variable, of type Transform, called "cat"

FIXED UPDATE:
declare a var of type Vector3, called "directionToCat", set to a vector that goes from [current position] to [cat's current position]
if the angle between [current forward direction] vs. [directionToCat] is less than 180 degrees, then...
    declare a var of type Ray, called "mouseRay" that starts from [current position] and goes along [directionToCat]
    declare a var of type RaycastHit, called "mouseRayHitInfo"
    if raycast with mouseRay and mouseRayHitInfo for 100 units is TRUE, then... 
        if mouseRayHitInfo.collider.tag is exactly equal to the word "Cat"... (mouse sees cat!)
            add force on rigidbody, along [-directionToCat.normalized * 1000f] (run away!)
            */
