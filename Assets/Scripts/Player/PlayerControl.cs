using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerControl : MonoBehaviour
{

    public Sprite[] safetyShieldSprites;
    public Image playerShield;
    public Collectibles collectibles;
    
    private int id = 0;
    
    public ThirdPersonUserControl thirdPersonUserControl;

    private void Start()
    {
        DeactivatePlayer();
    }

    public void ActivatePlayer()
    {
        thirdPersonUserControl.isActive = true;
    }

    public void DeactivatePlayer()
    {
        thirdPersonUserControl.isActive = false;
    }

    public void PositionPlayer(float xpos, float ypos, float zpos)
	{
        gameObject.transform.position = new Vector3(xpos, ypos, zpos);
	}

    public void OrientPlayer(float angle)
	{
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, angle, gameObject.transform.eulerAngles.z);
    }

    public void UpdateShield()
    {
        id += 1;

        playerShield.sprite = safetyShieldSprites[id];
    }

}
