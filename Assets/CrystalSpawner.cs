using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour {
	public GameObject BluePrefab;
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Spiders"||other.gameObject.name == "Lion"){
			Instantiate(BluePrefab,transform.position,Quaternion.identity);
		}
	}
}
