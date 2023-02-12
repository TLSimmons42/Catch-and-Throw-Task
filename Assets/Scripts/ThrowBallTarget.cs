using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("anything");

        if (other.gameObject.CompareTag("throw ball"))
        {
            Debug.Log("target hit");
            GameManager.instance.SpawnThrowBallTarget();
            Destroy(gameObject);
        }
    }
}
