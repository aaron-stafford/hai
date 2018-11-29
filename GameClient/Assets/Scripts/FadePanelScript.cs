using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadePanelScript : MonoBehaviour {

  public void LoadStartScene() {
    SceneManager.LoadScene("Start");
  }

  public void LoadMatchGameScene() {
    SceneManager.LoadScene("MatchGame");
  }
}
