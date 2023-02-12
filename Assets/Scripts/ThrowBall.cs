using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowBall : XRGrabInteractable
{

    Rigidbody rb;
    public bool isHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        if (args.interactorObject.transform.gameObject.CompareTag("Right Hand") || args.interactorObject.transform.gameObject.CompareTag("Left Hand"))
        {
            Debug.Log("picked up ball");
            rb.isKinematic = false;
            isHeld = true;
        }

        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        rb.isKinematic = false;

        Debug.Log(args.interactorObject.transform.gameObject.name);
        if (args.interactorObject.transform.gameObject.CompareTag("Right Hand") || args.interactorObject.transform.gameObject.CompareTag("Left Hand"))
        {
            Debug.Log("throw ball");
            isHeld = false;
            GameManager.instance.SpawnBall();
            Destroy(gameObject, 8);
        }

        base.OnSelectExited(args);
    }
}
