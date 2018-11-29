using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
  public int timeLeft = 0;
  public Text countdownText;
  private bool m_StartTransition = false;;

  public void Init(int time) {
    timeLeft = time;
  }
	
	void Start () {
    StartCoroutine(LoseTime());
	}
	
	void Update () {
    GetComponent<Text>().text = "" + timeLeft;
    if(isTimerOff()) {
      if(MatchManager.Instance.DidWin()) {
        SceneManager.LoadScene("Win");
      }
      else {
        if(m_StartTransition) {
          GameObject gameObject = GameObject.Find("FadePanel");
          gameObject.GetComponent<Animator>().Play("FadeOutMatchGame");
          m_StartTransition = false;
        }
      }
    }
  }

  public bool isTimerOff() {
    return ! (timeLeft > 0);
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
