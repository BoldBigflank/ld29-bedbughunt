using UnityEngine;
using System.Collections;

public class BugObjectScript : MonoBehaviour {
	public float speed = 0.5F;
	Vector3 velocity;
	PlayMakerFSM gameManagerFSM;
	public AudioClip[] bounceSounds;

	// Use this for initialization
	void Start () {
		// Its start position
		transform.position = new Vector3(
			Random.Range(-20.0F, 20.0F),
			-1.0F,
			Random.Range (-12.0F, 12.0F));

		// Its speed
		Vector2 v = Random.insideUnitCircle.normalized;
		velocity = new Vector3(v.x, 0.0F, v.y);
		gameManagerFSM = PlayMakerFSM.FindFsmOnGameObject(GameObject.FindGameObjectWithTag("GameController"), "FSM_game");

	}
	
	// Update is called once per frame
	void Update () {
		speed = gameManagerFSM.FsmVariables.GetFsmFloat("speed").Value;
		transform.position += velocity * speed;

//		transform.RotateAround(transform.position, Vector3.up, 5.0F);	
	}

	void HitEdge(Vector3 from){
		if(Mathf.RoundToInt( from.x ) != 0 ) velocity.x = -1 * from.x * Mathf.Abs(velocity.x);
		if(Mathf.RoundToInt( from.z ) != 0 ) velocity.z = -1 * from.z * Mathf.Abs(velocity.z);
		int r = Random.Range (0, bounceSounds.Length);
		audio.PlayOneShot(bounceSounds[r]);
	}

	void OnCollisionEnter(Collision col){
		if(col.rigidbody != null && col.rigidbody.gameObject.tag == "Plane"){

			col.rigidbody.AddForce(0, 200, 0);
		}
	}
}
