using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TipCanvas : MonoBehaviour {
	public Text m_tipText;
	// Use this for initialization

	
	public void tips(){
		StartCoroutine(startTips());
		
	}
	public IEnumerator startTips(){
		m_tipText.text = " Welcome To Corin and the Creeping Nightmare! Move around and explore the island with WASD, and pressing the 'O' key will cause your spirit to leave your body";
		yield return new WaitForSeconds(7);
		m_tipText.text = "";
	}
}
