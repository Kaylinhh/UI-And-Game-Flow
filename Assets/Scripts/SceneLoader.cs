using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneLoader : MonoBehaviour // handles scene navigation
{

    public Button quitButton;

    public void GoToScene(string sceneName)
    {
        SceneTransitionManager.instance.LoadScene(sceneName);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#elif UNITY_WEBGL
    quitButton.gameObject.SetActive(false);
    Debug.Log("Quit not supported in WebGL. Close the tab to exit.");
#else
    Application.Quit();
    Debug.Log("You've closed the game.");
#endif
    }

}
