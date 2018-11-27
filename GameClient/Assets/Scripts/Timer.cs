using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
  public int timeLeft = 0;
  public Text countdownText;

  public void Init(int time) {
    timeLeft = time;
  }
	
	void Start () {
    StartCoroutine(LoseTime());
	}
	
	void Update () {
    GetComponent<Text>().text = "" + timeLeft;
    if (isTimerOff())
    {
      if(MatchManager.Instance.DidWin()) {
        SceneManager.LoadScene("Win");
      }
      else {
        SceneManager.LoadScene("End");
      }
    }
  }

  public bool isTimerOff() {
    if (timeLeft > 0) {
      return false;
    }
    else {
      return true;
    }
  }

  IEnumerator LoseTime()
  {
    while (true)
    {
      yield return new WaitForSeconds(1);
      timeLeft--;
    }
  }
}
