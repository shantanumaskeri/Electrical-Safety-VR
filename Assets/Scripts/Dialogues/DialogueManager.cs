using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class DialogueManager : MonoBehaviour
{

    public AudioSource audioSource;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public ThirdPersonCharacter thirdPersonCharacter;
    public AudioClip phoneRing;
    public DialogueList[] dialogueLists;
    public GameManager gameManager;

    [HideInInspector]
    public bool isDialogueBoxOpen = false;

    private Queue<string> sentences;
    private int dialogueID = -1;
    
    private void Start()
    {
        sentences = new Queue<string>();
    }

    public IEnumerator InitializeDialogue()
    {
        if (gameManager.GetGameStatus() == "VO 0")
        {
            audioSource.clip = phoneRing;
            audioSource.Play();

            yield return new WaitForSeconds(4.2f);
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
        }

        if (gameManager.GetGameStatus() == "VO 2")
        {
            thirdPersonCharacter.ResetCharacterForTalking();
        }

        StartDialogue(dialogueLists[dialogueID].dialogue);
    }

    private void StartDialogue(Dialogue dialogue)
    {
        isDialogueBoxOpen = true;

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            audioSource.Stop();
            audioSource.clip = dialogueLists[dialogueID].dialogue.audios[sentences.Count - 1];
            audioSource.Play();
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        isDialogueBoxOpen = false;

        animator.SetBool("IsOpen", false);

        gameManager.CheckGameStatus();
    }

    public void StartNextSequence()
    {
        dialogueID++;
        gameManager.SetGameStatus("VO " + dialogueID);

        StartCoroutine(InitializeDialogue());
    }

}
