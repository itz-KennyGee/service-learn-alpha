using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private GameObject Player;
    public Dialogue dialogue;
    private bool hasTriggered = false;
    LayerMask mask;
    private float range = 2.5f;

    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, this.transform.position) <= range && !hasTriggered)
        {
            Debug.Log("In range of " + this.gameObject.name);
            TriggerDialogue();
            hasTriggered = true;
        } 

        if (Vector3.Distance(Player.transform.position, this.transform.position) > range && hasTriggered)
        {
            Debug.Log("Out of range of " + this.gameObject.name);
            hasTriggered = false;
        }
    }
    

}
