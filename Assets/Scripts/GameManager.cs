using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class GameManager : Singleton<GameManager>
{

    public GameObject throwBallSpawnPos;
    public GameObject throwBall;
    public GameObject throwBallTarget;

    public GameObject head;
    public GameObject rightHand;
    public GameObject leftHand;

    public GameObject throwHandRight;
    public GameObject throwHandLeft;
    public GameObject catchHandRight;
    public GameObject catchHandLeft;

    public UIView calibrationUI;

    public Vector3 chestCenterPos;
    public GameObject chestCenter;


    public float shoulderHight;
    public float rightSideArmLength;
    public float leftSideArmLength;

    public Vector3 targetPos;

    public GameObject rightSideTestTarget1;
    public GameObject rightSideTestTarget2;
    public GameObject rightSideTestTarget3;

    public GameObject leftSideTestTarget1;
    public GameObject leftSideTestTarget2;
    public GameObject leftSideTestTarget3;


    public bool spawnball = false;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            spawnball = false;
            catchHandRight.SetActive(true);
            catchHandLeft.SetActive(true);
            throwHandRight.SetActive(false);
            throwHandLeft.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnball = true;
            catchHandRight.SetActive(false);
            catchHandLeft.SetActive(false);
            throwHandRight.SetActive(true);
            throwHandLeft.SetActive(true);
            SpawnBall();
            SpawnThrowBallTarget();
        }
    }

    public void StartCalibration()
    {
        //display the UI telling the person to stand in a T-Pos
        calibrationUI.Show();
    }

    public void AssignTPos()
    {
        //assign the Pos of the 3 parts of the T
        //headCalibrationPos = head.transform;
        //rightHandCalibrationPos = rightHand.transform;
        //leftHandCalibrationPos = leftHand.transform;

        shoulderHight = (rightHand.transform.position.y + leftHand.transform.position.y) / 2;

        chestCenterPos = new Vector3(head.transform.position.x, shoulderHight, head.transform.position.z);
        chestCenter.transform.position = chestCenterPos;

        rightSideArmLength = Vector3.Distance(chestCenterPos, rightHand.transform.position);
        leftSideArmLength = Vector3.Distance(chestCenterPos, leftHand.transform.position);



        // Calculate the Pos of the Targets for the ball flight
        //rightSideTestTarget1.transform.position = calculateTargetPos(1, 0, 0);
        //rightSideTestTarget2.transform.position = calculateTargetPos(1, 1, 1);
        //rightSideTestTarget3.transform.position = calculateTargetPos(1, 2, 2);

        //leftSideTestTarget1.transform.position = calculateTargetPos(0, 0, 1);
        //leftSideTestTarget2.transform.position = calculateTargetPos(0, 1, 1);
        //leftSideTestTarget3.transform.position = calculateTargetPos(0, 2, 1);

    }

    // side 0 = left  -- side 1 = right
    // distance 0 = front -- distance 1 = neutral  -- distance 2 = behind
    // elevation 0 = below -- elevation 1 == middle -- elevation 2 high

    public Vector3 calculateTargetPos(int side, int distance, int elevation)
    {
        Vector3 pos = new Vector3(0,0,0);
        
        switch (distance)
        {
            case 0:
                pos.z = head.transform.position.z + .3f;
                break;
            case 1:
                pos.z = head.transform.position.z;
                break;
            case 2:
                pos.z = head.transform.position.z + (-.3f);
                break;
        }

        switch (side)
        {
            case 0:
                pos.x = leftHand.transform.position.x;
                break;
            case 1:
                pos.x = rightHand.transform.position.x;
                break;

        }

        switch (elevation)
        {
            case 0:
                pos.y = shoulderHight + .3f;
                break;
            case 1:
                pos.y = shoulderHight;
                break;
            case 2:
                pos.y = shoulderHight + (-.3f);
                break;
        }

        return pos;
    }

    public Vector3 CatchTrial()
    {
        int side = Random.Range(0, 2);
        int dis = Random.Range(0, 3);
        int elevation = Random.Range(0, 3);

        targetPos = calculateTargetPos(side, dis, elevation);

        return targetPos;

    }

    public void SpawnBall()
    {
        Instantiate(throwBall, throwBallSpawnPos.transform.position, Quaternion.identity);
    }
    public void SpawnThrowBallTarget()
    {
        float x = Random.Range(-3f, 4f);
        float z = Random.Range(1f, 5f);
        Vector3 pos = new Vector3(x, 0.02f, z);
        Instantiate(throwBallTarget, pos, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("throw ball"))
        {
            Debug.Log("target hit");
            SpawnThrowBallTarget();
            Destroy(gameObject);
        }
    }
}
