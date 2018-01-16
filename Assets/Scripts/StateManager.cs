using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {
public int m_CrystalCount;
public GameObject[] m_gameStates;
public GameObject m_maincam;
public GameObject m_TipCanvas;
public Transform m_victoryTarget;
public Transform m_victoryPlayer;
private GameObject m_activeState;
private CameraController m_camPlayScript;
private CamSwivel m_camMenuScript;



	// Use this for initialization
	void Start () {
		int numStates = m_gameStates.Length;
		for(int i = 0;i<numStates;i++){
			m_gameStates[i].SetActive(false);
	
		}
		m_activeState = m_gameStates[0];
		m_activeState.SetActive(true);
		m_camPlayScript = m_maincam.GetComponent<CameraController>();
		m_camMenuScript = m_maincam.GetComponent<CamSwivel>();
	}
	

	void Update(){
		if(m_CrystalCount == 2){
			EndGame();
			m_CrystalCount = 0;
		}
		
	}
	IEnumerator Splash(){
		yield return new WaitForSeconds(3);
		Menu();
	}
	
	public void Exit(){
		 #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
	}

	public void Menu(){
		//StartCoroutine(Splash());
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[1];
		m_activeState.SetActive(true);
	}

	public void PlayGame(){
		m_camMenuScript.enabled = false;
		m_camPlayScript.enabled = true;
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[2];
		m_activeState.SetActive(true);
		m_TipCanvas.GetComponent<TipCanvas>().tips();
	}

	

	public void EndGame(){
		m_camPlayScript.enabled = false;
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[3];
		m_activeState.SetActive(true);
		m_maincam.transform.position = m_victoryTarget.position;
		m_maincam.transform.LookAt(m_victoryPlayer);
	}
	


}
