using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBuilder : MonoBehaviour {

	public GameObject m_waterPrefab; 
	public Transform m_waterContainer; 
	public float m_waterHeight = 1.0f;
	public int m_terrainWidth; // x 
	public int m_terrainDepth; // z

	void Start() {
		GameObject tmpObj; 
		for(int x = 0; x < m_terrainWidth; x++) {
			for (int z = 0; z < m_terrainDepth; z++) {
				tmpObj = Instantiate(m_waterPrefab, new Vector3(x * 100 + 50, m_waterHeight, z * 100 + 50), Quaternion.identity);
				tmpObj.name = "WaterPlane";
				tmpObj.transform.parent = m_waterContainer;
			}
		}
	}



}
