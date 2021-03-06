using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    

    public bool[] levelStatus;
    
    
    private void Awake()
    {
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void Save()
    {

        // Save
        SaveObject saveObject = new SaveObject
        {
            levelStatusObj = levelStatus,
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
        
    }
    public void Load()
    {
        // Load
        if(File.Exists(Application.dataPath + "/save.txt")){
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            for (int i = 0; i < levelStatus.Length; i++)
            {
                levelStatus[i] = saveObject.levelStatusObj[i];
            //  Debug.Log(loadedSaveObj.levelStatusObj[i]);
                
            }
        }
        
    }


    // json obj going to save
    private class SaveObject
    {
        public bool[] levelStatusObj;
    }
}

