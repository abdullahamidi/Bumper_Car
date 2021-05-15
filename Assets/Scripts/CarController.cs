using UnityEngine;



public class CarController : MonoBehaviour
{
    public static CarController instance;

    private Rigidbody rigidbody;
    private Transform wheelTransform;


    public float speed;




    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        wheelTransform = GameObject.FindWithTag("SteeringWheel").transform;
    }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -2)
        {
            GameManager.instance.Lose();
        }
        VerticalMove();
    }



    public void HorizontalMove(float axis)
    {
            if (axis != 0)
            {
                Quaternion horizontalMovement = Quaternion.Euler(0, axis * Time.deltaTime, 0);
                rigidbody.MoveRotation(rigidbody.rotation * horizontalMovement);
                wheelTransform.localEulerAngles = new Vector3(0, 0, -axis);
            }
    }

    public void VerticalMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);
    }

}
