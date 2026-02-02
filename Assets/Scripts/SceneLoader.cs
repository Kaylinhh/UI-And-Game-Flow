using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneLoader : MonoBehaviour // handles scene navigation
{
    public void GoToScene(string sceneName)
    {
        SceneTransitionManager.instance.LoadScene(sceneName);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
        Debug.Log("You've closed the game.");
#endif
    }
}
