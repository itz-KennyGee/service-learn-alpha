using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTracker : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject[] hazards;
    // Start is called before the first frame update
    void Start()
    {
        hazards = GameObject.FindGameObjectsWithTag("Hazard");
    }

    // Update is called once per frame
    void Update()
    {
        if (hazards.Length > 0) { }

        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue, this.gameObject);


    }
}
