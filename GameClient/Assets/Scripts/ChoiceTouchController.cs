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
  private float m_Timestamp;
  bool m_CheckForMatched = true;
  private AudioClip[] m_MatchSounds = new AudioClip[2];
  private AudioClip m_Pop;

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
    Debug.Log("The timer has started.");
    m_MatchSounds[0] = (AudioClip) Resources.Load("Audio/match_yeah");
    m_MatchSounds[1] = (AudioClip) Resources.Load("Audio/match_thatsright");
    m_Pop = (AudioClip) Resources.Load("Audio/pop");
    GameDataManager.Instance.Init();;
	}

	void Update () {
    if(m_CheckForMatched) {
      if(m_LeftObject.name.Equals(m_RightObject.name)) {
        float currentTime = Time.time;
        float elapsedTime = currentTime - m_Timestamp;
        float matchTime = GameDataManager.Instance.gameData.timeToRecognizeAMatch;
        if(elapsedTime > matchTime) {
          MatchManager.Instance.FoundMatch();
          m_GameRoot.GetComponent<Animator>().Play("Matched", -1, 0);
          m_CheckForMatched = false;
          AudioSource audioSource = GetComponent<AudioSource> ();
          Assert.IsNotNull(audioSource);
          int randomValue = Random.Range(0, m_MatchSounds.Length);
          audioSource.PlayOneShot(m_MatchSounds[randomValue], 0.7F);
        }
      }
    }
	}

  public void OnPointerDown(PointerEventData eventData) {
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
    AudioSource audioSource = GetComponent<AudioSource> ();
    Assert.IsNotNull(audioSource);
    audioSource.PlayOneShot(m_Pop, 0.7F);
  }

  public void OnPointerUp(PointerEventData eventData) {
  }
}
