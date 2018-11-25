public class ScoreManager  {
  private static ScoreManager instance;
  public static ScoreManager Instance {
    get  
    {  
      if (instance == null)  
      {  
          instance = new ScoreManager();  
      }  
      return instance;  
    } 
  }
  
  public int m_Score = 0;
  private int m_MatchReward = 10;

  public void Init() {
    m_Score = 50;
  }

  public void AddToScore(int a_Offset) {
    m_Score += a_Offset;
  }

  public void UsedATap() {
    m_Score--;
  }

  public void FoundAMatch() {
    m_Score += m_MatchReward;
  }

  public void FoundAMatch(int a_MatchReward) {
    m_Score += a_MatchReward;
  }

  public bool IsBossDead() {
    if(m_Score <= 0) {
      return true;
    }
    return false;
  }
}
