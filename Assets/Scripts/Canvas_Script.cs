using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Script : MonoBehaviour
{
    public InputField inputName;
    public Text bestScore;
    public Text playerName;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        bestScore.text = StartMenu.Instance.m_bestScore.ToString();
        playerName.text = StartMenu.Instance.m_playerName;
    }
    public void SetName()
	{
        StartMenu.Instance.m_playerName = inputName.text;

    }
}
