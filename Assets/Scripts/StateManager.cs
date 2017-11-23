using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {
private GameObject m_activeState;
public GameObject[] m_gameStates;



	// Use this for initialization
	void Start () {
		int numStates = m_gameStates.Length;
		for(int i=0;i<numStates;i++){
			m_gameStates[i].SetActive(false);
	
		}
		m_activeState=m_gameStates[2];
		m_activeState.SetActive(true);
	
	}
	

	// Update is called once per frame
	void Update () {
	
		if(m_activeState == m_gameStates[0]){
			StartCoroutine(Splash());
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
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[1];
		m_activeState.SetActive(true);
	}

	public void PlayGame(){
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[2];
		m_activeState.SetActive(true);
	}

	public void GameOver(){
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[3];
		m_activeState.SetActive(true);
		
	}
	


}
