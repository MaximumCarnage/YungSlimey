using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionWeap : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Breakable"){
			Debug.Log("Hit Rock");
			Destroy(other.gameObject);
			
		}
	}
}
