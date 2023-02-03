using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public float shootForce = 10.0f;

    public Transform target_1;
    public Transform target_2;

    public float timer = 0f;

    public bool shoot = true;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2 & shoot)
        {
            //shoot = false;
            int temp = Random.Range(0, 2);
            Debug.Log(temp);
            if (temp == 0)
            {
                ShootBall(target_1);
            }
            else
            {
                ShootBall(target_2);
            }
            timer = 0;
        }

    }

    void ShootBall(Transform pos)
    {
        // Spawn a ball and apply force in the shoot direction
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<BallMovement>().target = pos;
    }
}
