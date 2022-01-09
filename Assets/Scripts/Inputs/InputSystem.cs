using UnityEngine;
using UnityEngine.UI;

public class InputSystem : MonoBehaviour
{

    public Animator drawerAnimator;
    public Animator closetAnimator;
    public Animator deskAnimator;
    public Animator desk2Animator;
    public Animator doorAnimator;
    public Animator helmetArrowAnimator;
    public Animator glovesArrowAnimator;
    public Animator gogglesArrowAnimator;
    public Animator shoesArrowAnimator;
    public Animator coverallsArrowAnimator;
    public Animator locktagArrowAnimator;
    public Animation serverSwitch;
    public GameObject leftShoeInDrawer;
    public GameObject rightShoeInDrawer;
    public GameObject coverallsTopInCloset;
    public GameObject coverallsBottomInCloset;
    public GameObject helmetOnTable;
    public GameObject gogglesInDrawer;
    public GameObject leftGloveOnShelf;
    public GameObject rightGloveOnShelf;
    public GameObject closetDrawer;
    public GameObject closetDoor;
    public GameObject deskDrawer;
    public GameObject lockOnSelf;
    public GameObject tagOnSelf;
    public GameObject whiteShirtOnAvatar;
    public GameObject blackPantOnAvatar;
    public GameObject leftShoesOnAvatar;
    public GameObject rightShoesOnAvatar;
    public GameObject coverallTopOnAvatar;
    public GameObject coverallPantOnAvatar;
    public GameObject gogglesOnAvatar;
    public GameObject helmetOnAvatar;
    public GameObject leftGloveOnAvatar;
    public GameObject rightGloveOnAvatar;
    public GameObject instructionText;
    public GameObject padlock;
    public GameObject dangerTag;
    public BoxCollider cabinet;
    public BoxCollider closet;
    public BoxCollider desk;
    public BoxCollider desk2;
    public BoxCollider shelf;
    public BoxCollider cabinet2;
    public Text instructionStep1;
    public Text instructionStep2;
    public Text instructionStep3;
    public LevelTimer levelTimer;
    public CameraAnimation cameraAnimation;
    public DialogueManager dialogueManager;
    public PlayerControl playerControl;
    public Collectibles collectibles;
    public GameManager gameManager;

    private void Update()
    {
        ConfigureKeyActions();
    }

    public void ShowPPEHelperIndicators()
	{
        helmetArrowAnimator.enabled = true;
        glovesArrowAnimator.enabled = true;
        gogglesArrowAnimator.enabled = true;
        shoesArrowAnimator.enabled = true;
        coverallsArrowAnimator.enabled = true;
	}

    private void ShowLockTagHelperIndicator()
	{
        locktagArrowAnimator.enabled = true;
	}

    private void ConfigureKeyActions()
    {
        if (Input.GetKeyDown(KeyCode.Return) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            switch (gameManager.GetGameStatus())
            {
                case "VO 0":
                case "VO 1":
                case "VO 2":
                    
                    if (dialogueManager.isDialogueBoxOpen)
					{
                        dialogueManager.DisplayNextSentence();
                    }
                    
                    break;

                case "VO 3":

                    if (dialogueManager.isDialogueBoxOpen)
                    {
                        dialogueManager.DisplayNextSentence();
                    }

                    cabinet2.enabled = true;

                    ShowLockTagHelperIndicator();

                    break;

                case "VO 4":
                    
                    instructionStep1.color = Color.green;

                    if (dialogueManager.isDialogueBoxOpen)
                    {
                        dialogueManager.DisplayNextSentence();
                    }

                    serverSwitch.CrossFade("Off");
                    gameManager.SetGameStatus("VO 5");
                    
                    break;

                case "VO 5":
                    
                    instructionStep2.color = Color.green;
                    padlock.SetActive(true);

                    if (dialogueManager.isDialogueBoxOpen)
                    {
                        dialogueManager.DisplayNextSentence();
                    }

                    gameManager.SetGameStatus("VO 6");
                    
                    break;

                case "VO 6":
                    
                    //levelTimer.StopTimer();
                    instructionText.SetActive(false);
                    instructionStep3.color = Color.green;
                    dangerTag.SetActive(true);

                    if (dialogueManager.isDialogueBoxOpen)
                    {
                        dialogueManager.DisplayNextSentence();
                    }

                    StartCoroutine(gameManager.End());
                    
                    break;

                case "Open Drawer":
                    
                    drawerAnimator.SetBool("IsOpen", true);
                    gameManager.SetGameStatus("Pick Up Item");
                    
                    break;

                case "Open Closet":
                    
                    closetAnimator.SetBool("IsOpen", true);
                    gameManager.SetGameStatus("Pick Up Item");
                    
                    break;

                case "Open Desk":
                    
                    deskAnimator.SetBool("IsOpen", true);
                    gameManager.SetGameStatus("Pick Up Item");
                    
                    break;

                case "Open Desk 2":
                    
                    desk2Animator.SetBool("IsOpen", true);
                    gameManager.SetGameStatus("Pick Up Item");
                    
                    break;

                case "Pick Up Item":
                    
                    if (gameManager.itemToPickUp == "Shoes")
                    {
                        leftShoeInDrawer.SetActive(false);
                        rightShoeInDrawer.SetActive(false);
                        leftShoesOnAvatar.SetActive(true);
                        rightShoesOnAvatar.SetActive(true);
                        
                        drawerAnimator.SetBool("IsOpen", false);

                        cabinet.enabled = false;
                        closet.enabled = true;
                    }

                    else if (gameManager.itemToPickUp == "Coveralls")
                    {
                        coverallsTopInCloset.SetActive(false);
                        coverallsBottomInCloset.SetActive(false);
                        whiteShirtOnAvatar.SetActive(false);
                        blackPantOnAvatar.SetActive(false);
                        coverallTopOnAvatar.SetActive(true);
                        coverallPantOnAvatar.SetActive(true);
                        
                        closetAnimator.SetBool("IsOpen", false);

                        closet.enabled = false;
                    }

                    else if (gameManager.itemToPickUp == "Goggles")
                    {
                        gogglesInDrawer.SetActive(false);
                        gogglesOnAvatar.SetActive(true);
                        
                        deskAnimator.SetBool("IsOpen", false);

                        desk.enabled = false;
                    }

                    else if (gameManager.itemToPickUp == "Helmet")
                    {
                        helmetOnTable.SetActive(false);
                        helmetOnAvatar.SetActive(true);
                        
                        desk2.enabled = false;
                    }

                    else if (gameManager.itemToPickUp == "Gloves")
                    {
                        leftGloveOnShelf.SetActive(false);
                        rightGloveOnShelf.SetActive(false);
                        leftGloveOnAvatar.SetActive(true);
                        rightGloveOnAvatar.SetActive(true);

                        shelf.enabled = false;
                    }

                    else if (gameManager.itemToPickUp == "LockTag")
                    {
                        lockOnSelf.SetActive(false);
                        tagOnSelf.SetActive(false);

                        cabinet2.enabled = false;

                        doorAnimator.SetBool("IsOpen", true);
                    }

                    instructionText.SetActive(false);

                    gameManager.SetGameStatus("Item Picked");

                    if (collectibles.GetCollectibles() < 5)
                    {
                        playerControl.UpdateShield();
                        collectibles.SetCollectibles(collectibles.GetCollectibles() + 1);
                        collectibles.CheckCollectibles();
                    }

                    playerControl.ActivatePlayer();

                    StartCoroutine(cameraAnimation.UpdateAnimationSettings(false, 0.5f));

                    break;
            }
        }
    }

}
