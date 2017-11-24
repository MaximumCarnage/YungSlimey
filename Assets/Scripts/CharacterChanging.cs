using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
public enum characterType{ NORMAL, ASTRAL, BIG , SMALL , FLIGHT};

public class CharacterChanging : MonoBehaviour {
	public Animator m_playeranimator;
	public GameObject m_astralAvatar;
	public GameObject m_normalAvatar;
	public GameObject m_sleepyPlayer;
	public Transform  m_currentAvatar;
	public characterType m_currentType;
	public AnimatorController m_normalAnim; 
	public AnimatorController m_astralAnim; 
	public Camera m_mainCam;
	public ThirdPersonOrbitCamBasic m_camScript;
	void Start(){
		m_currentType = characterType.NORMAL;
		m_playeranimator = GetComponent<Animator>();
		m_camScript = m_mainCam.GetComponent<ThirdPersonOrbitCamBasic>();
	}

	void Update(){
		
		if(Input.GetKeyDown(KeyCode.O) && m_currentType == characterType.NORMAL){
				m_currentType = characterType.ASTRAL;
				Instantiate(m_sleepyPlayer,m_currentAvatar.position,Quaternion.identity);
				m_camScript.player=m_astralAvatar.transform;
				m_astralAvatar.transform.position=m_currentAvatar.position;
				m_currentAvatar=m_astralAvatar.transform;
				 m_normalAvatar.SetActive(false);
				 m_astralAvatar.SetActive(true);
			
			
			
		}
		else if(Input.GetKeyDown(KeyCode.O) && m_currentType == characterType.ASTRAL){
				m_currentType = characterType.NORMAL;
				m_camScript.player=m_normalAvatar.transform;
				 m_astralAvatar.SetActive(false);
				 m_normalAvatar.SetActive(true);
			}
	}
}
