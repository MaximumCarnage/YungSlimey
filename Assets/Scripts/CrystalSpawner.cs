using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour {
	public GameObject BluePrefab;
	public StateManager m_stateManger;
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Spiders"||other.gameObject.name == "Lion"){
			Instantiate(BluePrefab,transform.position,Quaternion.identity);
			m_stateManger.m_CrystalCount++;
			GetComponent<SphereCollider>().enabled = false;
		}

	}
}
