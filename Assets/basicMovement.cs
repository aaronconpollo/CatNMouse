using UnityEngine;
using System.Collections;

public class basicMovement : MonoBehaviour {

	Rigidbody rbody;

	void Start () {
		rbody = GetComponent<Rigidbody>();
	}

	void Update () {

		rbody.velocity +=  transform.forward * 6.4f + Physics.gravity;
		//transform.position += transform.forward * Time.deltaTime * 5f;
		Ray moveRay = new Ray( transform.position, transform.forward);
		
		if (Physics.Raycast ( moveRay, 5f ) ) {
			
			int randomNumber = Random.Range (0, 2);
			if (randomNumber == 0) {
				transform.Rotate (0f, 90f, 0f);
			}
			else {
				transform.Rotate (0f, -90f, 0f);
				
			}
			
		}
		
	}
}
