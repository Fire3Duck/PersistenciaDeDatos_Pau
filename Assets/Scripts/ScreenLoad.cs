using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoad : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
