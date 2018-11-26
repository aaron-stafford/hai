using System.Collections;
using System.Collections.Generic;
using System.IO; 
using UnityEngine;

public class GameDataManager {
  public GameData gameData;
  private static string gameDataFileName = "data.json";

  private static GameDataManager instance;
  public static GameDataManager Instance {
    get {  
      if (instance == null) {  
        instance = new GameDataManager();  
      }  
      return instance;  
    } 
  }

  public void Init() {
    string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
    if(File.Exists(filePath)) {
      string dataAsJson = File.ReadAllText(filePath); 
      gameData = JsonUtility.FromJson<GameData>(dataAsJson);
    }
    else {
      Debug.Log("Failed to load json from: " + filePath);
    }
  }
}
