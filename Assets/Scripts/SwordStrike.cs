using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStrike : MonoBehaviour {
public int m_WeaponDamage;
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<Health>().takeDamage(m_WeaponDamage);
			
		}
	}
}
