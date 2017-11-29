using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStrike : MonoBehaviour {

	void OnTriggerEnter(Collision other){
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<Health>();
		}
	}
}
