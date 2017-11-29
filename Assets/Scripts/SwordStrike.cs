using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStrike : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy"){
			Debug.Log("WeGetHere");
			other.gameObject.GetComponent<Health>().takeDamage(10);
			
		}
	}
}
