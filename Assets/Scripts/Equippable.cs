using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Equippable : MonoBehaviour
{
    public Canvas canvas;
    [SerializeField] private TMP_Text pickUpNotif;
    [SerializeField] private float range;
    RaycastHit hit;
    LayerMask mask;
    //private GameObject lastHit;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        Debug.Log(canvas.name);
        mask = LayerMask.GetMask("PickUp");

        //material = this.GetComponent<Renderer>().material;
        //Debug.Log(material.ToString());
        //Debug.Log(canvas.GetComponentInChildren<TMP_Text>().name);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range, mask))
        {

            Debug.Log(hit.collider.gameObject.GetComponent<Renderer>().name);
            //canvas.GetComponentInChildren<TMP_Text>().text
            //hit.collider.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            pickUpNotif.gameObject.SetActive(true);
            pickUpNotif.text = "Pick Up " + hit.collider.gameObject.name;

        }
        else
        {
            //hit.collider.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            pickUpNotif.gameObject.SetActive(false);

        }
    }

}
