using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BossFightTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  private Object[] m_Prefabs;
  private bool haveWon = false;
  private float m_SpawnInterval = 0.5f;
  public GameObject m_CameraGameObject;

	// Use this for initialization (Stuff you only want to do once)
	void Start () {
    ScoreManager.Instance.Init();
    m_Prefabs = Resources.LoadAll("Prefabs", typeof(GameObject));
    StartCoroutine(Begin());
	}
	
	// Update is called once per frame
	void Update () {
    if(haveWon) {
      WinConditionUpdate();
    }

  }

  private void WinConditionUpdate() {
    // Spawn new object somewhere.
    int randomValue = Random.Range(0, m_Prefabs.Length);
    Vector3 position = new Vector3(0.0f, 0.0f, -4.0f);	
    GameObject gameObject = (GameObject)m_Prefabs[randomValue];
	  GameObject newGameObject = Instantiate(gameObject, position, gameObject.transform.rotation);
    newGameObject.AddComponent<Rigidbody>();
    newGameObject.AddComponent<PrefabController>();
  }

  // Called when the mouse or finger touch down
  public void OnPointerDown(PointerEventData eventData) {
    Camera camera = m_CameraGameObject.GetComponent<Camera>(); 
    Ray raycast = camera.ScreenPointToRay(eventData.position);
    RaycastHit raycastHit;
    if (Physics.Raycast(raycast, out raycastHit))
    {
        Destroy(raycastHit.transform.gameObject);
        Debug.Log("Something Hit");
        ScoreManager.Instance.AddToScore(-10);
    }

    if(ScoreManager.Instance.IsBossDead()) {
      SceneManager.LoadScene("Win");
    }
    else if(ScoreManager.Instance.AreYouDead()) {
      SceneManager.LoadScene("End");
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

  IEnumerator Begin () {
    while(true) {
      int randomValue = Random.Range(0, m_Prefabs.Length);
      Vector3 position = new Vector3(0.0f, 5.0f, -3.43f);	
      GameObject gameObject = (GameObject)m_Prefabs[randomValue];
 	    GameObject newGameObject = Instantiate(gameObject, position, gameObject.transform.rotation);
      newGameObject.AddComponent<Rigidbody>();
      newGameObject.AddComponent<PrefabController>();
      yield return new WaitForSeconds (m_SpawnInterval);
    }
  }
}
