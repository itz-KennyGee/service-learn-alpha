using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private GameObject objInteracted;
    public Animator animator;
    public TMP_Text NPC;
    public TMP_Text dialogueText;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        //NPC = GameObject.FindGameObjectWithTag("NPCname").GetComponent<TMP_Text>();
        //dialogueText = GameObject.FindGameObjectWithTag("DialogueText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        // AND DIALOGUE BOX IS ACTIVE
        if (Input.GetKeyDown(KeyCode.Return)) {
            NextSentence();
        }
    }
    public void StartDialogue(Dialogue dialogue, GameObject obj)
    {
        objInteracted = obj;
        animator.SetBool("Open", true);
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        name = dialogue.NPC_Name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        } NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count== 0) { 
            EndDialogue(objInteracted);
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue(GameObject obj)
    {
        Debug.Log("End of conversation with " + this.gameObject);
        animator.SetBool("Open", false);
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Destroy(obj);
        Debug.Log("Destroyed " + obj.name);
    }
}
