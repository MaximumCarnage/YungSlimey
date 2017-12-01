using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	public GameObject m_maincam;
	private CameraController m_camScript;
	private Transform m_currentPlayer;
	private Health m_healthScript;
	private int m_currentHealth;

	public GameObject[] m_emptyHeartUI;
	public GameObject[] m_halfHeartUI;
	public GameObject[] m_fullHeartUI;


	// Use this for initialization
	void Start(){
		m_camScript=m_maincam.GetComponent<CameraController>();
		m_currentPlayer=m_camScript.m_target;
		m_healthScript=m_currentPlayer.GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(m_currentHealth);
		if(m_currentHealth!=m_healthScript.m_health){

		m_currentHealth=m_healthScript.m_health;
			switch(m_currentHealth){
				case 0:
					m_halfHeartUI[0].SetActive(false);
					m_emptyHeartUI[0].SetActive(true);
				break;

				case 10:
					m_fullHeartUI[0].SetActive(false);
					m_halfHeartUI[0].SetActive(true);
				break;

				case 20:
					m_halfHeartUI[1].SetActive(false);
					m_emptyHeartUI[1].SetActive(true);
				break;

				case 30:
					m_fullHeartUI[1].SetActive(false);
					m_halfHeartUI[1].SetActive(true);
				break;

				case 40:
					m_halfHeartUI[2].SetActive(false);
					m_emptyHeartUI[2].SetActive(true);
				break;

				case 50:
					m_fullHeartUI[2].SetActive(false);
					m_halfHeartUI[2].SetActive(true);
				break;

				case 60:
					m_halfHeartUI[3].SetActive(false);
					m_emptyHeartUI[3].SetActive(true);
				break;

				case 70:
					m_fullHeartUI[3].SetActive(false);
					m_halfHeartUI[3].SetActive(true);
				break;

				case 80:
					m_halfHeartUI[4].SetActive(false);
					m_emptyHeartUI[4].SetActive(true);
				break;

				case 90:
					m_fullHeartUI[4].SetActive(false);
					m_halfHeartUI[4].SetActive(true);
				break;

				case 100:
					for(int i = 0 ; i<m_fullHeartUI.Length; i++){
						m_fullHeartUI[i].SetActive(true);
					}
				break;
			}
		}
	}
	public void ChangePlayer(){
		m_currentPlayer=m_camScript.m_target;
		m_healthScript=m_currentPlayer.GetComponent<Health>();
		
	}
}
