using UnityEngine;
/// <summary>
/// Faceted Water Script 
/// Copyright 2017 Liftlock Studios Inc. 
/// Coded by Robert French (robert@liftlockstudios.com)
/// Licenced to the Evening Unity Class of 2017 at triOS College Toronto under the LGPL 
/// Last Updated November 28 2017
/// </summary>
public class FacetedWater : MonoBehaviour {
	public Vector2 m_range = new Vector2(0.1f, 0.5f);
	public float m_speed = 0.3f;

	private float[] m_randomTimes;
	private Mesh m_mesh;
	
	/// <summary>
	/// Must be attached to a GameObject that has a MeshFilter component
	/// </summary>
	void Start(){
		m_mesh = GetComponent<MeshFilter>().mesh;
		int i = 0;
		m_randomTimes = new float[m_mesh.vertices.Length];
		
		while (i < m_mesh.vertices.Length) {
			m_randomTimes[i] = Random.Range(m_range.x, m_range.y);
			i++;
		}
		
	}

	void Update() {
		Vector3[] vertices = m_mesh.vertices;
		Vector3[] normals = m_mesh.normals;
		int i = 0;
		while (i < vertices.Length) {
			vertices[i].y = 1 * Mathf.PingPong(Time.time * m_speed, m_randomTimes[i]);
			i++;
		}
		m_mesh.vertices = vertices;
	}

}
