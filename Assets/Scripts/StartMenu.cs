using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public int m_bestScore;
    public string m_playerName;
    public static StartMenu Instance;
	private void Awake()
	{
		if (Instance!=null)
		{
            Destroy(gameObject);
		}
        Instance = this;
        DontDestroyOnLoad(gameObject);
	}
	// Start is called before the first frame update
	void Start()
    {
        LoadPlayerInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SavePlayerInputInfo()
	{
        SavePlayerInfo();
        SceneManager.LoadScene(1);
	}
	public void Quit()
	{
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string playerName;
    }
    public void SavePlayerInfo()
    {
        SaveData data = new SaveData();
        data.bestScore = m_bestScore;
        data.playerName = m_playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }
    public void LoadPlayerInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            m_playerName = data.playerName;
            m_bestScore = data.bestScore;
        }
		else
		{
            Debug.Log("Does not exist!!!");
		}
    }
}
