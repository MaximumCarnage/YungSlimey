using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionColliders : MonoBehaviour {
public GameObject m_player;
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			m_player.GetComponent<CharacterChanging>().m_currentType;
		}
	}
}
