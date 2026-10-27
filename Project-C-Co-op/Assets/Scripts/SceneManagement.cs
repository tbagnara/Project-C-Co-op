using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{    
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
