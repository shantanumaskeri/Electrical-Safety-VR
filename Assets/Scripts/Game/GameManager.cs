using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public LevelLoader levelLoader;
    public LevelTimer levelTimer;
    public InputSystem inputSystem;
    public DialogueManager dialogueManager;
    public PlayerControl playerControl;

    [HideInInspector]
    public string itemToPickUp;

    private string currentStatus = "";
    private float startTime = 0.0f;

    private void Start()
    {
        SetGameStatus("VO -1");
        StartCoroutine(SetTalkSequence());
    }

    private IEnumerator SetTalkSequence()
    {
        startTime = playerControl.thirdPersonUserControl.startTime;
        yield return new WaitForSeconds(startTime);

        dialogueManager.StartNextSequence();
    }

    public void SetGameStatus(string status)
    {
        currentStatus = status;
    }

    public string GetGameStatus()
    {
        return currentStatus;
    }

    public void CheckGameStatus()
    {
        if (GetGameStatus() == "VO 0" || GetGameStatus() == "VO 1" || GetGameStatus() == "VO 4" || GetGameStatus() == "VO 5")
        {
            dialogueManager.StartNextSequence();
        }
        else if (GetGameStatus() == "VO 2")
        {
            playerControl.ActivatePlayer();
            //levelTimer.StartTimer();
            inputSystem.ShowPPEHelperIndicators();
        }
    }

    public IEnumerator End()
    {
        yield return new WaitForSeconds(3.0f);

        levelLoader.FadeToLevel();
    }

}
