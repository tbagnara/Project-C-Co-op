using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.backgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
