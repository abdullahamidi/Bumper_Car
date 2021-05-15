using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    //public int force;

    public enum CollisionStates
    {
        None, Front, Left, Back, Right
    }



    public CollisionStates CollisionDetect(Vector3 direction)
    {
        if (direction.x != 0f && direction.z != 0f) //find the most collided part
        {
            float max = Mathf.Max(Mathf.Abs(direction.x), Mathf.Abs(direction.z));
            if (max == Mathf.Abs(direction.x))
            {
                direction.z = 0f;
            }
            else
            {
                direction.x = 0f;
            }
        }
        if (direction.z > 0f)
        {
            return CollisionStates.Front;
        }
        else if (direction.z < 0f)
        {
            return CollisionStates.Back;
        }
        if (direction.x < 0f)
        {
            return CollisionStates.Left;
        }
        else if (direction.x > 0f)
        {
            return CollisionStates.Right;
        }
        else
        {
            return CollisionStates.None;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = transform.InverseTransformPoint(collision.transform.position); //find the collision direction
        Vector3 forceDir = -(transform.position - collision.transform.position).normalized;
        float speedVariable = CarController.instance.speed;
        if (CollisionDetect(direction) == CollisionStates.Front)
        {
            if (gameObject.tag == "Player")
            {
                AnimationController.instance.FrontCrashAnimation();
            }
            if (collision.gameObject.tag == "Car" || collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(forceDir * (speedVariable), ForceMode.Impulse);
            }
        }
        else if (CollisionDetect(direction) == CollisionStates.Back)
        {
            if (gameObject.tag == "Player")
            {
                AnimationController.instance.BackCrashAnimation();
            }
            if (collision.gameObject.tag == "Car" || collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(forceDir * (speedVariable), ForceMode.Impulse);
            }
        }
        else if (CollisionDetect(direction) == CollisionStates.Left)
        {
            if (gameObject.tag == "Player")
            {

                AnimationController.instance.LeftCrashAnimation();
            }
            if (collision.gameObject.tag == "Car" || collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(forceDir * (speedVariable) / 2, ForceMode.Impulse);
            }
        }
        else
        {
            if (gameObject.tag == "Player")
            {

                AnimationController.instance.RightCrashAnimation();
            }
            if (collision.gameObject.tag == "Car" || collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(forceDir * (speedVariable) / 2, ForceMode.Impulse);
            }
        }


    }
}
