using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject AudioSource;

    private void Awake()
    {
        DontDestroyOnLoad(AudioSource);
    }

    public void ToNextScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    
}