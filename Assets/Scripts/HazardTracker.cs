using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTracker : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject[] hazards;

    // Update is called once per frame
    void Update()
    {        
        hazards = GameObject.FindGameObjectsWithTag("Hazard");

        if (hazards.Length == 0 )
        {
            FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue, this.gameObject);
            GameObject.Destroy(this);
            FindAnyObjectByType<PlayerController>().CompletedTraining();

        }
        //Debug.Log(hazards.Length);

    }
}
