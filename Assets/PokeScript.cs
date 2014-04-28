using UnityEngine;
using System.Collections;

public class PokeScript : MonoBehaviour {
	public GameObject explosionPrefab;
	public AudioClip explosionSound;
	public AudioClip pokeSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown (0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Ray ray;
			// For mouse control
			if(Input.GetMouseButtonDown(0))
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			else
				ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

			audio.PlayOneShot(pokeSound);

			// create a logical plane at this object's position
			// and perpendicular to world Y:
			Plane plane = new Plane(Vector3.up, Vector3.zero);
			//			Plane plane = new Plane(Vector3.up, transform.position);
			float distance = 0; // this will return the distance from the camera

			if (plane.Raycast(ray, out distance)){ // if plane hit...
				Vector3 pos = ray.GetPoint(distance); // get the point
				// pos has the position in the plane you've touched


				// Now poke straight down at that point on the plane
				RaycastHit[] r = Physics.SphereCastAll(pos, 2.4F, -1.0F * Vector3.up, 9.0F);
				for(int i = 0; i < r.Length; i++){
					if(r[i].rigidbody != null){

						if(r[i].rigidbody.gameObject.tag == "Bug") {
							// Play explosion
							audio.PlayOneShot(explosionSound);
							Instantiate(explosionPrefab, pos, new Quaternion());
							// Remove the bug
							Destroy( r[i].rigidbody.gameObject );
							// Update the game object
						}
						if(r[i].rigidbody.gameObject.tag == "Plane"){

							r[i].rigidbody.AddForce(0, -1000, 0);

						}
					}

				}

			}
		}
	}
}
