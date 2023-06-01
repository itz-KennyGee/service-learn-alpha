using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{

    [SerializeField] private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActionHandler();
    }

    private void ActionHandler()
    {
        if (Input.GetKeyDown("e"))
        {
            myAnimator.SetTrigger("PressGrab");
        }
    }

}
