using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public SavaData activeSave;
    public static SaveManager instance;
    public bool hasLoaded;
    private void Awake()
    {
        instance = this;
        Load();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            DeleteSaveData();
        }
    }
    public void Save()
    {
        string dataPath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SavaData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save",FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();
        Debug.Log("Saved");
    }
    public void Load()
    {
        string dataPath = Application.persistentDataPath;
        if (File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SavaData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);
            activeSave = serializer.Deserialize(stream) as SavaData;
            stream.Close();
            Debug.Log("Loaded");
            hasLoaded = true;
        }
    }
    public void DeleteSaveData()
    {
        string dataPath = Application.persistentDataPath;
        if (File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + activeSave.saveName + ".save");
        }
    }
    [System.Serializable]
    public class SavaData
    {
        public string saveName;
        public Vector3 playerPosition;
    }
}
