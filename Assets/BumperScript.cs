using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Bug"){
			other.gameObject.SendMessage("HitEdge", transform.position.normalized);
		}
	}
}
