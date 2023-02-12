using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{

    public GameObject ballPrefab;
    public float shootForce = 10.0f;

    public float timer = 0f;

    public bool shoot = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            shoot = true;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            shoot = false;
        }
        timer += Time.deltaTime;
        if (timer >= 2 && shoot)
        {
            //shoot = false;
            int temp = Random.Range(0, 2);
            Debug.Log(temp);
            if (temp == 0)
            {
                ShootBall();
            }
            else
            {
                ShootBall();
            }
            timer = 0;
        }

    }

    void ShootBall()
    {
        // Spawn a ball and apply force in the shoot direction
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Vector3 ballTargetPos = GameManager.instance.CatchTrial();
        ball.GetComponent<BallMovement>().target = ballTargetPos;
    }
}
