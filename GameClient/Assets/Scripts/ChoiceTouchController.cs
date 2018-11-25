using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChoiceTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  private GameObject m_LeftObject; 
  private GameObject m_RightObject; 
  public GameObject m_GameRoot; 
  public float m_XOffset = 0.3f;
  public float m_YOffset = 0.0f;
  private Object[] m_Prefabs;
  public float m_MatchTime = 1.0f;
  private float m_Timestamp;
  bool m_CheckForMatched = true;
  private bool m_TouchStateDown;

	void Start () {
    m_Prefabs = Resources.LoadAll("Prefabs", typeof(GameObject));
    int randomValue = Random.Range(0, m_Prefabs.Length);
    Vector3 position = new Vector3(-m_XOffset, m_YOffset, 0.0f);	
    GameObject gameObject = (GameObject)m_Prefabs[randomValue];
	  m_LeftObject = Instantiate(gameObject, position, gameObject.transform.rotation);
    m_LeftObject.transform.parent = m_GameRoot.transform;

    randomValue = Random.Range(0, m_Prefabs.Length);
    position = new Vector3(m_XOffset, m_YOffset, 0.0f);	
    gameObject = (GameObject)m_Prefabs[randomValue];
	  m_RightObject = Instantiate(gameObject, position, gameObject.transform.rotation);
    m_RightObject.transform.parent = m_GameRoot.transform;
    m_Timestamp = Time.time;
    MatchManager.Instance.Reset();
    m_TouchStateDown = false;
    Debug.Log("The timer has started.");
	}

	void Update () {
    if(m_CheckForMatched) {
      if(m_LeftObject.name.Equals(m_RightObject.name)) {
        float currentTime = Time.time;
        float elapsedTime = currentTime - m_Timestamp;
        if(elapsedTime > m_MatchTime) {
          MatchManager.Instance.FoundMatch();
          m_GameRoot.GetComponent<Animator>().Play("Matched", -1, 0);
          m_CheckForMatched = false;
        }
      }
    }
	}

  public void OnPointerDown(PointerEventData eventData) {
    m_TouchStateDown = true;
  }

  public void OnPointerUp(PointerEventData eventData) {
    int randomValue = Random.Range(0, m_Prefabs.Length);
    GameObject gameObject = (GameObject)m_Prefabs[randomValue];
    if( eventData.position.x < Screen.width * 0.5 ) {
      m_LeftObject.AddComponent<Rigidbody>();
      m_LeftObject.AddComponent<PrefabController>();
      Vector3 position = new Vector3(-m_XOffset, m_YOffset, 0.0f);	
	    m_LeftObject = Instantiate(gameObject, position, gameObject.transform.rotation);
      m_LeftObject.transform.parent = m_GameRoot.transform;
    }
    else {
      m_RightObject.AddComponent<Rigidbody>();
      m_RightObject.AddComponent<PrefabController>();
      Vector3 position = new Vector3(m_XOffset, m_YOffset, 0.0f);	
	    m_RightObject = Instantiate(gameObject, position, gameObject.transform.rotation);
      m_RightObject.transform.parent = m_GameRoot.transform;
    }
    m_Timestamp = Time.time;
    m_CheckForMatched = true;
    m_TouchStateDown = false;
  }
}
