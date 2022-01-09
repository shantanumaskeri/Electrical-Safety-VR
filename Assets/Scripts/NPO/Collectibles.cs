using UnityEngine;

public class Collectibles : MonoBehaviour
{

    public DialogueManager dialogueManager;
    
    private int itemsCollected = 0;
    private const int totalItemsToCollect = 5;

    public void SetCollectibles(int value)
    {
        itemsCollected = value;
    }

    public int GetCollectibles()
    {
        return itemsCollected;
    }

    public void CheckCollectibles()
    {
        if (GetCollectibles() == totalItemsToCollect)
        {
            dialogueManager.StartNextSequence();
        }
    }

}
