using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneBehavior : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
