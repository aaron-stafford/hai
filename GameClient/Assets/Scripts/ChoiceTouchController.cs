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
    //m_Prefabs = Resources.LoadAll("Prefabs", typeof(GameObject));
    m_Prefabs = Resources.LoadAll("Prefabs", typeof(GameObject));
    int randomValue = Random.Range(0, m_Prefabs.Length);
    Vector3 position = new Vector3(-m_XOffset, m_YOffset, 0.0f);	
    GameObject gameObject = (GameObject)m_Prefabs[randomValue];
	  m_LeftObject = Instantiate(gameObject, position, gameObject.transform.rotation);
    randomValue = Random.Range(0, m_Prefabs.Length);
    position = new Vector3(m_XOffset, m_YOffset, 0.0f);	
    gameObject = (GameObject)m_Prefabs[randomValue];
	  m_RightObject = Instantiate(gameObject, position, gameObject.transform.rotation);
	}

	void Update () {
	}

  public void OnPointerDown(PointerEventData eventData) {
  }

  public void OnPointerUp(PointerEventData eventData) {
    int randomValue = Random.Range(0, m_Prefabs.Length);
    GameObject gameObject = (GameObject)m_Prefabs[randomValue];
    if( eventData.position.x < Screen.width * 0.5 ) {
      m_LeftObject.AddComponent<Rigidbody>();
      m_LeftObject.AddComponent<PrefabController>();
      Vector3 position = new Vector3(-m_XOffset, m_YOffset, 0.0f);	
	    m_LeftObject = Instantiate(gameObject, position, gameObject.transform.rotation);
    }
    else {
      m_RightObject.AddComponent<Rigidbody>();
      m_RightObject.AddComponent<PrefabController>();
      Vector3 position = new Vector3(m_XOffset, m_YOffset, 0.0f);	
	    m_RightObject = Instantiate(gameObject, position, gameObject.transform.rotation);
    }
  }
}
