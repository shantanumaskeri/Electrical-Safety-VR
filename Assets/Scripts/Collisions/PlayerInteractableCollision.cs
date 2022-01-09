using UnityEngine;

public class PlayerInteractableCollision : MonoBehaviour
{

    public GameObject closetDrawer;
    public GameObject closetDoor;
    public GameObject gogglesInDrawer;
    public GameObject helmet;
    public GameObject leftGloves;
    public GameObject rightGloves;
    public GameObject padLock;
    public GameObject dangerTag;
    public GameObject instructionText;
    public GameObject procedureBox;
    public BoxCollider cabinet;
    public BoxCollider closet;
    public BoxCollider cabinet2;
    public Transform levelLoader;
    public Animator switchBoardAnimator;
    public CameraAnimation cameraAnimation;
    public PlayerControl playerControl;
    public DialogueManager dialogueManager;
    public GameManager gameManager;
    
    private void Start()
    {
        cabinet.enabled = true;
        closet.enabled = false;
        cabinet2.enabled = false;

        instructionText.SetActive(false);
        procedureBox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Interactable")
            {
                if (gameObject.name == "Closet Cabinet")
                {
                    gameManager.itemToPickUp = "Shoes";
                    gameManager.SetGameStatus("Open Drawer");

                    playerControl.PositionPlayer(-2.220271f, 0.09499991f, -0.8782288f);
                    playerControl.OrientPlayer(90.0f);
                }

                else if (gameObject.name == "Desk Cabinet")
                {
                    gameManager.itemToPickUp = "Goggles";
                    gameManager.SetGameStatus("Pick Up Item");

                    playerControl.OrientPlayer(270.0f);
                }

                else if (gameObject.name == "Desk Cabinet 2")
                {
                    gameManager.itemToPickUp = "Helmet";
                    gameManager.SetGameStatus("Pick Up Item");

                    playerControl.OrientPlayer(270.0f);
                }

                else if (gameObject.name == "Shelf Drawer")
                {
                    gameManager.itemToPickUp = "Gloves";
                    gameManager.SetGameStatus("Pick Up Item");

                    playerControl.OrientPlayer(270.0f);
                }

                else if (gameObject.name == "Closet Door")
                {
                    gameManager.itemToPickUp = "Coveralls";
                    gameManager.SetGameStatus("Open Closet");

                    playerControl.PositionPlayer(-2.072029f, 0.09499991f, -1.563386f);
                    playerControl.OrientPlayer(90.0f);
                }

                else if (gameObject.name == "LockTag Cabinet")
                {
                    gameManager.itemToPickUp = "LockTag";
                    gameManager.SetGameStatus("Pick Up Item");

                    playerControl.PositionPlayer(-1.803432f, 0.09499991f, -4.472014f);
                    playerControl.OrientPlayer(90.0f);
                }

                else if (gameObject.name == "Server Door")
                {
                    gameManager.itemToPickUp = "Switch";

                    switchBoardAnimator.SetBool("IsOpen", true);

                    dialogueManager.StartNextSequence();
                    gameManager.SetGameStatus("VO 4");

                    playerControl.PositionPlayer(10.6f, 0.1f, -4.227f);
                    playerControl.OrientPlayer(90.0f);
                    
                    levelLoader.localPosition = new Vector3(0.0f, -0.74f, 0.11f);
                    levelLoader.localEulerAngles = new Vector3(0.35f, -180.0f, 0.0f);

                    procedureBox.SetActive(true);
                }
            }

            instructionText.SetActive(true);
            playerControl.DeactivatePlayer();

            StartCoroutine(cameraAnimation.UpdateAnimationSettings(true, 0.0f));
        }
    }

}
