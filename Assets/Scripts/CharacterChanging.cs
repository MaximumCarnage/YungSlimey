using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum characterType{ NORMAL, ASTRAL, BIG , SMALL , FLIGHT};

public class CharacterChanging : MonoBehaviour {

	public GameObject m_astralAvatar;
	public GameObject m_normalAvatar;

	public characterType m_currentType;


	void Start(){
		m_currentType = characterType.NORMAL;
		
	}

	void Update(){
		
		if(Input.GetKey(KeyCode.Space)){
			if(m_currentType == characterType.NORMAL){
				m_currentType = characterType.ASTRAL;
				 m_normalAvatar.SetActive(false);
				 m_astralAvatar.SetActive(true);
			}
			
			
		}
		else{
				m_currentType = characterType.NORMAL;
				 m_astralAvatar.SetActive(false);
				 m_normalAvatar.SetActive(true);
			}
	}
}
