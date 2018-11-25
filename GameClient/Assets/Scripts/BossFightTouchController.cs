using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BossFightTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  private Object[] m_Prefabs;
  private bool haveWon = false;
  private bool haveLost = false;
  private float m_SpawnInterval = 0.4f;
  public GameObject m_CameraGameObject;
  private AudioClip[] m_MatchSounds = new AudioClip[2];

	// Use this for initialization (Stuff you only want to do once)
	void Start () {
    ScoreManager.Instance.Init();
    m_Prefabs = Resources.LoadAll("Prefabs", typeof(GameObject));
    m_MatchSounds[0] = (AudioClip) Resources.Load("Audio/match_yeah");
    m_MatchSounds[1] = (AudioClip) Resources.Load("Audio/match_thatsright");
    StartCoroutine(Begin());
	}
	
	// Update is called once per frame
	void Update () {
    if(haveWon) {
      WinConditionUpdate();
    }
    if(haveLost) {
      LoseConditionUpdate();
    }
  }

  private void WinConditionUpdate() {
    // Spawn new object somewhere.
    int randomValue = Random.Range(0, m_Prefabs.Length);
    Vector3 position = new Vector3(0.0f, 0.0f, -0.0f);	
    GameObject gameObject = (GameObject)m_Prefabs[randomValue];
	  GameObject newGameObject = Instantiate(gameObject, position, gameObject.transform.rotation);
    newGameObject.AddComponent<Rigidbody>();
    newGameObject.AddComponent<PrefabController>();
  }

  private void LoseConditionUpdate() {
    // Spawn new object somewhere.
    int randomValue = Random.Range(0, m_Prefabs.Length);
    Vector3 position = new Vector3(0.0f, 0.0f, -0.0f);	
    GameObject enemy = Instantiate(Resources.Load("EnemyPrefabs/Enemy")) as GameObject;
    enemy.transform.position = position;
    enemy.AddComponent<Rigidbody>();
    enemy.AddComponent<PrefabController>();
  }

  // Called when the mouse or finger touch down
  public void OnPointerDown(PointerEventData eventData) {
    Camera camera = m_CameraGameObject.GetComponent<Camera>(); 
    Ray raycast = camera.ScreenPointToRay(eventData.position);
    RaycastHit raycastHit;
    if (Physics.Raycast(raycast, out raycastHit))
    {
        if(raycastHit.transform.gameObject.name.Equals("Enemy")) {
          // Do nothing. This is just the guy in the middle
        }
        else if(raycastHit.transform.gameObject.name.Equals("Enemy(Clone)")) {
          Destroy(raycastHit.transform.gameObject);
          ScoreManager.Instance.AddToScore(10);
        }
        else {
          ScoreManager.Instance.AddToScore(-10);
          AudioSource audioSource = GetComponent<AudioSource> ();
          Assert.IsNotNull(audioSource);
          int randomValue = Random.Range(0, m_MatchSounds.Length);
          audioSource.PlayOneShot(m_MatchSounds[randomValue], 0.7F);
          Destroy(raycastHit.transform.gameObject);
        }
    }

    if(ScoreManager.Instance.IsBossDead()) {
      haveWon = true;
      StartCoroutine(TransitionToWin());
      AudioSource audioSource = GetComponent<AudioSource> ();
      Assert.IsNotNull(audioSource);
      AudioClip yay = (AudioClip) Resources.Load("Audio/yay");
      audioSource.PlayOneShot(yay, 0.7F);
    }

    if(ScoreManager.Instance.AreYouDead()) {
      haveLost = true;
      StartCoroutine(TransitionToLose());
    }
  }

  // Called when the mouse or finger touch up
  public void OnPointerUp(PointerEventData eventData) {
/*
    if( eventData.position.x < Screen.width * 0.5 ) {
      ScoreManager.Instance.AddToScore(10);
    }
    else {
      ScoreManager.Instance.AddToScore(-10);
    }

    if(ScoreManager.Instance.IsBossDead()) {
      SceneManager.LoadScene("Win");
    }
    else if(ScoreManager.Instance.AreYouDead()) {
      SceneManager.LoadScene("End");
    }
*/
  }

  IEnumerator TransitionToLose() {
    yield return new WaitForSeconds (10);
    SceneManager.LoadScene("End");
  }

  IEnumerator TransitionToWin () {
    yield return new WaitForSeconds (3);
    SceneManager.LoadScene("Win");
  }

  IEnumerator Begin () {
    while(true) {
      int coinToss = Random.Range(0, 3);
      Vector3 position = new Vector3(0.0f, 5.0f, -3.43f);	
      if(coinToss != 0) {
        GameObject enemy = Instantiate(Resources.Load("EnemyPrefabs/Enemy")) as GameObject;
        enemy.transform.position = position;
        enemy.AddComponent<Rigidbody>();
        enemy.AddComponent<PrefabController>();
      }
      else {
        int randomValue = Random.Range(0, m_Prefabs.Length);
        GameObject gameObject = (GameObject)m_Prefabs[randomValue];
 	      GameObject newGameObject = Instantiate(gameObject, position, gameObject.transform.rotation);
        newGameObject.AddComponent<Rigidbody>();
        newGameObject.AddComponent<PrefabController>();
      }
      yield return new WaitForSeconds (m_SpawnInterval);
    }
  }
}
