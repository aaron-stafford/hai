using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChoiceTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  private GameObject m_LeftObject; 
  private GameObject m_RightObject; 

	void Start () {
	  m_LeftObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
    m_LeftObject.transform.position = new Vector3(-1.9f, 0.0f, 0.0f);	
	  m_RightObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    m_RightObject.transform.position = new Vector3(1.9f, 0.0f, 0.0f);	
	}

	void Update () {
	}

  public void OnPointerDown(PointerEventData eventData) {
  }

  public void OnPointerUp(PointerEventData eventData) {
    if( eventData.position.x < Screen.width * 0.5 ) {
      Debug.Log("Left side");
    }
    else {
      Debug.Log("Right side");
    }
  }
}
