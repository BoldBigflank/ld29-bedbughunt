using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaneScript : MonoBehaviour {
	Vector3[] vertices;
	List<GameObject> bodies;
	public GameObject body;
	PlayMakerFSM gameManagerFSM;

	// Use this for initialization
	void Start () {
		bodies = new List<GameObject>();
		// Attach a rigidbody and collider to every vertex
		vertices = GetComponent<MeshFilter>().mesh.vertices;
		for(int i = 0; i < vertices.Length; i++){
			GameObject b = (GameObject)Instantiate(body);
			b.transform.parent = transform;
			b.transform.localPosition = vertices[i];
			b.GetComponent<SpringJoint>().connectedAnchor = transform.localPosition;
			bodies.Add(b);
		}

		gameManagerFSM = PlayMakerFSM.FindFsmOnGameObject(GameObject.FindGameObjectWithTag("GameController"), "FSM_game");
	}
	
	// Update is called once per frame
	void Update () {
		// Update the vertex to the rigidbody's new position
		for(int i = 0; i < bodies.Count; i++){
//			Debug.Log ("Vertex at: " + vertices[i].ToString());

			vertices[i] = bodies[i].transform.localPosition;
		}
		GetComponent<MeshFilter>().mesh.vertices = vertices;

		Color c = gameManagerFSM.FsmVariables.GetFsmColor("stripeColor").Value;
		renderer.material.SetColor ("_Color", c);

	}
}
