using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {
  public int m_TotalHealth;
  private float m_InitialWidth;

	// Use this for initialization
	void Start () {
	  // m_InitialWidth = GetComponent<RectTransform>().rect.width;
	  // Debug.Log(GetComponent<RectTransform>().rect);
	  // Debug.Log(m_InitialWidth);
	  RectTransform rt = GetComponent<RectTransform>();
    //Rect rect = GetComponent<RectTransform>().rect;
	  GetComponent<RectTransform>().sizeDelta =  new Vector2 (100, rt.sizeDelta.y);
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
