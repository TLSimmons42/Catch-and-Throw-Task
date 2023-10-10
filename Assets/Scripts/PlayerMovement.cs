using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float lerTime = 3f;

    public Vector3 startPos;
    public Vector3 movePos;

    public bool movingToStartPos = false;
    public bool movingToNewPos = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        float x = Random.Range(-1f, 2f);
        float z = Random.Range(-1f, 2f);
        movePos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        movingToNewPos = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (movingToNewPos)
            {
                movingToNewPos = false;
            }
            else
            {
                movingToNewPos = false;
            }
            

        }
        if (movingToNewPos)
        {

            MoveToNewPos();
            if (transform.position == movePos)
            {
                movingToStartPos = true;
                movingToNewPos = false;
            }
        }
        if (movingToStartPos)
        {
            MoveToStartPos();
            if (transform.position == startPos)
            {
                movingToStartPos = false;
                movingToNewPos = true;
            }
        }
    }

    public void MoveToNewPos()
    {
        transform.position = Vector3.Lerp(transform.position, movePos, lerTime * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePos) < 0.01f)
        {
            Debug.Log("snap");
            // Swap the position of the cylinder.
            transform.position = movePos;
        }
    }
    public void MoveToStartPos()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, lerTime * Time.deltaTime);
        if (Vector3.Distance(transform.position, startPos) < 0.01f)
        {
            Debug.Log("snap");
            // Swap the position of the cylinder.
            transform.position = startPos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("anything");

        if (other.gameObject.CompareTag("throw ball"))
        {
            Debug.Log("target hit");
            GameManager.instance.SpawnMovingThrowBallTarget();
            Destroy(gameObject);
        }
    }
}
