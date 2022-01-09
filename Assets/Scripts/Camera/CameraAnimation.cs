using System.Collections;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{

    public float transitionSpeed;
    public GameManager gameManager;

    private bool isOrbitAnimEnabled = false;
    private Vector3 iniPosition;
    private Vector3 iniEulerAngles;

	private void Start()
	{
        iniPosition = transform.localPosition;
        iniEulerAngles = transform.localEulerAngles;
	}

    private void Update()
    {
        if (isOrbitAnimEnabled)
        {
            if (gameManager.itemToPickUp == "Switch")
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0.0f, 1.62f, 0.6f), Time.deltaTime * transitionSpeed);
                transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(17.0f, 0.0f, 0.0f), Time.deltaTime * transitionSpeed);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(-1.3f, 1.8f, 0.3f), Time.deltaTime * transitionSpeed);
                transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(34.0f, 90.0f, 0.0f), Time.deltaTime * transitionSpeed);
            }
        }
        else
		{
            transform.localPosition = Vector3.Lerp(transform.localPosition, iniPosition, Time.deltaTime * transitionSpeed);
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, iniEulerAngles, Time.deltaTime * transitionSpeed);
        }
    }

    public IEnumerator UpdateAnimationSettings(bool value, float delay)
    {
        yield return new WaitForSeconds(delay);

        isOrbitAnimEnabled = value;
    }

}
