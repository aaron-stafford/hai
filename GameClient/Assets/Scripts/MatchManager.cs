using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager {
  private static MatchManager instance = null;
  public static MatchManager Instance {
    get  
    {  
      if (instance == null)  
      {  
          instance = new MatchManager();  
      }  
      return instance;  
    } 
  }

  private int m_NumberOfMatches = 0;
  private int m_MatchesToWin = 3;

  public void Reset() {
    m_NumberOfMatches = 0;
  }

  public void FoundMatch() {
    m_NumberOfMatches++;
    if(MatchManager.Instance.DidWin()) {
      SceneManager.LoadScene("Win");
    }
  }

  public bool DidWin() {
    if(m_NumberOfMatches >= m_MatchesToWin) {
      return true;
    }
    return false;
  }
}
