using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChoiceTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  private GameObject m_LeftObject; 
  private GameObject m_RightObject; 
  public float m_XOffset = 0.3f;
  public float m_YOffset = 0.0f;
  private Object[] m_Prefabs;

	void Start () {
    m_Prefabs = Resources.LoadAll("Prefabs");
    int randomValue = Random.Range(0, m_Prefabs.Length);
    Vector3 position = new Vector3(-m_XOffset, m_YOffset, 0.0f);	
	  m_LeftObject = Instantiate((GameObject)m_Prefabs[randomValue], position, Quaternion.identity);
    randomValue = Random.Range(0, m_Prefabs.Length);
    position = new Vector3(m_XOffset, m_YOffset, 0.0f);	
	  m_RightObject = Instantiate((GameObject)m_Prefabs[randomValue], position, Quaternion.identity);
	}

	void Update () {
	}

  public void OnPointerDown(PointerEventData eventData) {
  }

  public void OnPointerUp(PointerEventData eventData) {
    if( eventData.position.x < Screen.width * 0.5 ) {
      Debug.Log("Left side");
      m_LeftObject.AddComponent<Rigidbody>();
      int randomValue = Random.Range(0, m_Prefabs.Length);
      Vector3 position = new Vector3(-m_XOffset, m_YOffset, 0.0f);	
	    m_LeftObject = Instantiate((GameObject)m_Prefabs[randomValue], position, Quaternion.identity);
    }
    else {
      Debug.Log("Right side");
      m_RightObject.AddComponent<Rigidbody>();
      int randomValue = Random.Range(0, m_Prefabs.Length);
      Vector3 position = new Vector3(m_XOffset, m_YOffset, 0.0f);	
	    m_RightObject = Instantiate((GameObject)m_Prefabs[randomValue], position, Quaternion.identity);
    }
  }
}
