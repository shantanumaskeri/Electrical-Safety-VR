using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public Animator animator;

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1))
        {
            LoadLevel(0);
        }
        else
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex)); 
    }

    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            
            slider.value = progress;

            if (progress < 1f)
            {
                progressText.text = progress * 100f + "%";
            }
            else
            {
                progressText.text = "LOADING. PLEASE WAIT...";

                operation.allowSceneActivation = true;
            }
            
            yield return null;
        }
    }

}
