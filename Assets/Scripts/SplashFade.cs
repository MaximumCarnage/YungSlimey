﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashFade : MonoBehaviour {
	public Image m_img;
	public StateManager m_statemgr;
	public bool m_clicked = false;
	void Update(){
		if(Input.GetMouseButtonDown(0) && m_clicked == false){
			m_clicked = true;
			StartCoroutine(FadeImage(true));
			
		}
		
		
		
	}
	public IEnumerator FadeImage(bool fadeAway)
    {
		
        // fade from opaque to transparent
        if (fadeAway)
        {
			
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                m_img.color = new Color(1, 1, 1, i);
                yield return null;
            }
			yield return new WaitForSeconds(2);
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 100; i += Time.deltaTime)
            {
                // set color with i as alpha
                m_img.color = new Color(1, 1, 1, i);
                yield return null;
            }
			
        }
		
		m_statemgr.Menu();
    }
}
