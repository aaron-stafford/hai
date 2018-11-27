using System.Collections;
using System.Collections.Generic;
using System.IO; 
using UnityEngine;

// Thread safe Singleton
// https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
// Interface between data from data.json and how accessed in code.
public class GameDataManager {
  public GameData gameData;

  // Singleton creation code
  GameDataManager() {}
  private static readonly object padlock = new object();  
  private static GameDataManager instance = null;  
  public static GameDataManager Instance {
    get {
      lock (padlock) {
        if (instance == null) {
          instance = new GameDataManager();  
          // Choosing to load data at this point out of convenience
          instance.LoadData();
        }
        return instance;
      }
    }
  }
  // End of singleton creation code

  private static string gameDataFileName = "data.json";
/*
  private static GameDataManager instance;
  public static GameDataManager Instance {
    get {  
      if (instance == null) {  
        instance = new GameDataManager();  
        instance.Init();
      }  
      return instance;  
    } 
  }
*/
  public void LoadData() {
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
