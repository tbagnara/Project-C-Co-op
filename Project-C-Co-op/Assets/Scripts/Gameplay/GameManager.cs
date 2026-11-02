using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private int numberOfKeysLeft;
    public int playersAtExit;



    void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        PlayBGMusic();
        SetNumberOfKeys();
    }
    void Update()
    {
        IsLevelBeaten();
    }
    void PlayBGMusic() 
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.levelMusic);
    }
    void SetNumberOfKeys()
    {
        numberOfKeysLeft = GameObject.FindGameObjectsWithTag("Key").Length;
    }

    public void GrabbedAKey()
    {
        numberOfKeysLeft -= 1;
    }

    public void EnteredExit()
    {
        playersAtExit +=1;
    }
    public void LeftExit()
    {
        playersAtExit -= 1;
    }

    public void IsLevelBeaten()
    {
        if (playersAtExit == 2 && numberOfKeysLeft == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }







}
