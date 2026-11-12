using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{    
    public void OpenScene(string sceneName) // Loads the scene with a certain name
    {
        SceneManager.LoadScene(sceneName);
    }
}
