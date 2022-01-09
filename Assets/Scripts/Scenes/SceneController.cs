using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public LevelLoader levelLoader;

    private void Start()
    {
        CheckCurrentSceneLoaded();
    }

    private void CheckCurrentSceneLoaded()
	{
        switch (SceneManager.GetActiveScene().buildIndex)
		{
            case 0:
                
                StartCoroutine(AutoChangeScene(5.0f));
                
                break;

            case 1:
            case 2:
            case 3:
                
                if (Input.GetKeyDown(KeyCode.Return) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    ManualChangeScene();
                }
                
                break;
		}
	}
    private void Update()
    {
        CheckCurrentSceneLoaded();
    }

    private IEnumerator AutoChangeScene(float transitionTime)
    {
        yield return new WaitForSeconds(transitionTime);

        levelLoader.FadeToLevel();
    }

    private void ManualChangeScene()
	{
        levelLoader.FadeToLevel();
    }

}
