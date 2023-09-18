using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private Slider loadBar;
    [SerializeField] private GameObject loadPanel;

    public void LoadScene(string sceneName)
    {
        loadPanel.SetActive(true);
        StartCoroutine(LoadAsync(sceneName));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        while(!asyncOperation.isDone)
        {
            loadBar.value = asyncOperation.progress / 0.9f;
            yield return null;
        }
    }
}
    
