public class ScoreManager  {
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }
    private int m_Score = 0;
    private int m_MatchReward = 10;

    public void Init() {
      m_Score = 100;
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

    public bool AreWeDead() {
      if(m_Score <= 0) {
        return true;
      }
      return false;
    }
}
