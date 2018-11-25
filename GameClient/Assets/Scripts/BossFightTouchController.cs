using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BossFightTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  private Object[] m_Prefabs;

	// Use this for initialization (Stuff you only want to do once)
	void Start () {
    ScoreManager.Instance.Init();
    m_Prefabs = Resources.LoadAll("Prefabs", typeof(GameObject));
	}
	
	// Update is called once per frame
	void Update () {
    // Spawn new object somewhere.
    int randomValue = Random.Range(0, m_Prefabs.Length);
    Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);	
    GameObject gameObject = (GameObject)m_Prefabs[randomValue];
	  GameObject newGameObject = Instantiate(gameObject, position, gameObject.transform.rotation);
    newGameObject.AddComponent<Rigidbody>();
    newGameObject.AddComponent<PrefabController>();
  }

  // Called when the mouse or finger touch down
  public void OnPointerDown(PointerEventData eventData) {
  }

  // Called when the mouse or finger touch up
  public void OnPointerUp(PointerEventData eventData) {
    if( eventData.position.x < Screen.width * 0.5 ) {
      ScoreManager.Instance.AddToScore(10);
    }
    else {
      ScoreManager.Instance.AddToScore(-10);
    }

    if(ScoreManager.Instance.IsBossDead()) {
      SceneManager.LoadScene("Win");
    }
  }
}
