using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [SerializeField] private int levelNumber;    
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private TextMeshProUGUI pauseMenuText;

    private int numberOfKeysLeft;
    private int playersAtExit;

    void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void OnEnable()
    {
        PlayerController.onLevelFail += HandleLevelFail;
    }
    void OnDisable()
    {
        PlayerController.onLevelFail -= HandleLevelFail;
    }
    void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.levelMusic);
        numberOfKeysLeft = GameObject.FindGameObjectsWithTag("Key").Length;
    }
    void Update()
    {
        PauseInput();
    }



    public void GrabbedAKey()
    {
        numberOfKeysLeft -= 1;
    }

    public void EnteredExit()
    {
        playersAtExit +=1;
        IsLevelBeaten();
    }
    public void LeftExit()
    {
        playersAtExit -= 1;
    }

    void IsLevelBeaten()
    {
        if (playersAtExit == 2 && numberOfKeysLeft == 0 && Time.timeScale != 0)
        {
            Time.timeScale = 0;
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.goalSound);
            DisplayPauseMenu("Game Win");
            StartCoroutine( FreezeWaitTimeThenLoad(2, "Level" + (levelNumber + 1) ) );
        }
    }

    void HandleLevelFail()
    {
        DisplayPauseMenu("Game Over");
        StartCoroutine( FreezeWaitTimeThenLoad(2, SceneManager.GetActiveScene().name ) );
    }

    IEnumerator FreezeWaitTimeThenLoad(float seconds, string sceneName)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                DisplayPauseMenu("Pause");
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                DisplayPauseMenu("Hide");
            }
        }
    }

    void DisplayPauseMenu(string menuType) 
    {
        if (pauseMenu.isActiveAndEnabled == false)
            pauseMenu.enabled = true;

        switch (menuType)
        {
            case "Game Over":
                pauseMenuText.text = "- - - Game Over - - -";
                break;
            case "Game Win":
                pauseMenuText.text = "- - ! Level Escaped ! - -";
                break;
            case "Pause":
                pauseMenuText.text = "- - - Paused - - -";
                break;
            default:
                pauseMenu.enabled = false;
                break;
        }
    }





}
