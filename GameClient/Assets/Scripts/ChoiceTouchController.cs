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
  private Object[] m_Prefabs;
  private float m_Timestamp;
  bool m_CheckForMatched = true;
  private AudioClip[] m_MatchSounds = new AudioClip[2];
  private AudioClip m_Pop;

	void Start () {
    // Load all of the characters that we intend to use
    m_Prefabs = Resources.LoadAll("Prefabs", typeof(GameObject));

    // Randomly pick the first of two characters to show
    int randomValue = Random.Range(0, m_Prefabs.Length);
    GameObject gameObject = (GameObject)m_Prefabs[randomValue];

    // Set the spawn location based on data from data.json
    float optionSpawnOffsetX = GameDataManager.Instance.gameData.optionSpawnOffsetX;
    float optionSpawnOffsetY = GameDataManager.Instance.gameData.optionSpawnOffsetY;
    Vector3 position = new Vector3(-optionSpawnOffsetX, optionSpawnOffsetY, 0.0f);	

    // Instatiate the character at the spown location
	  m_LeftObject = Instantiate(gameObject, position, gameObject.transform.rotation);

    // Set the parent for the new character
    // TODO: Update this comment when you work out why this is done
    m_LeftObject.transform.parent = m_GameRoot.transform;

    // Randomly pick the second character to show 
    randomValue = Random.Range(0, m_Prefabs.Length);
    gameObject = (GameObject)m_Prefabs[randomValue];

    // Set the spawn location based on data from data.json
    position = new Vector3(optionSpawnOffsetX, optionSpawnOffsetY, 0.0f);	

    // Instatiate the character at the spown location
	  m_RightObject = Instantiate(gameObject, position, gameObject.transform.rotation);

    // Set the parent for the new character
    // TODO: Update this comment when you work out why this is done
    m_RightObject.transform.parent = m_GameRoot.transform;

    m_Timestamp = Time.time;

    // Load all other sound resources that we intend to use.
    // TODO: Find a better way to do this. It should be possible to remove
    // these lines of code by doing something different
    m_MatchSounds[0] = (AudioClip) Resources.Load("Audio/match_yeah");
    m_MatchSounds[1] = (AudioClip) Resources.Load("Audio/match_thatsright");
    m_Pop = (AudioClip) Resources.Load("Audio/pop");
    // Reset the match manager.
    // TODO: There should be a better place for this.
    MatchManager.Instance.Reset();
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

      // Set the spawn location based on data from data.json
      float optionSpawnOffsetX = GameDataManager.Instance.gameData.optionSpawnOffsetX;
      float optionSpawnOffsetY = GameDataManager.Instance.gameData.optionSpawnOffsetY;
      Vector3 position = new Vector3(-optionSpawnOffsetX, optionSpawnOffsetY, 0.0f);	

	    m_LeftObject = Instantiate(gameObject, position, gameObject.transform.rotation);
      m_LeftObject.transform.parent = m_GameRoot.transform;
    }
    else {
      m_RightObject.AddComponent<Rigidbody>();
      m_RightObject.AddComponent<PrefabController>();

      // Set the spawn location based on data from data.json
      float optionSpawnOffsetX = GameDataManager.Instance.gameData.optionSpawnOffsetX;
      float optionSpawnOffsetY = GameDataManager.Instance.gameData.optionSpawnOffsetY;
      Vector3 position = new Vector3(optionSpawnOffsetX, optionSpawnOffsetY, 0.0f);	

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
