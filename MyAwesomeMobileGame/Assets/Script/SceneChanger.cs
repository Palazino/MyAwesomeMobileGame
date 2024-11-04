using UnityEngine;
using UnityEngine.SceneManagement;

public class AwesomeSceneChange : MonoBehaviour
{

    public void LoadNextScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int currentSceneIndex = activeScene.buildIndex;
        Debug.Log("Current scene index: " + currentSceneIndex);

        int maxScenesInBuild = SceneManager.sceneCountInBuildSettings;
        int nextSceneIndexToLoad = (currentSceneIndex + 1) % maxScenesInBuild;
        Debug.Log("Loading next scene index: " + nextSceneIndexToLoad);

        SceneManager.LoadScene(nextSceneIndexToLoad);
    }
}
