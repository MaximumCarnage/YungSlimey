using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionTips : MonoBehaviour {
	public Text m_tipcanvas;
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "PlayerBody"){
			m_tipcanvas.text = "In Order to save the island, you must gather two crystals by completing trials, to the left is the Maze of the Arachnids, and to the right is the Den of the Lions ";
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "PlayerBody"){
			m_tipcanvas.text = "";
		}
	}
}
