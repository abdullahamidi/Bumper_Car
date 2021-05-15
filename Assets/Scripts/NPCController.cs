using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleInputNamespace;
using Random = UnityEngine.Random;

public class NPCController : MonoBehaviour
{

    private GameObject map;

    private Bounds mapBounds;

    private Quaternion lookRotation;
    private Vector3 direction;

    private float duration = 0f;
    private float elapsed = 0f;
    private float radius;
    private float distanceToCenter = 0f;
    private int randomAngle;

    public float speed = 10f;
    public int maximumSteeringAngle;



    private void Awake()
    {
        map = GameObject.FindGameObjectWithTag("Map");
        mapBounds = map.GetComponent<MeshCollider>().bounds;
        radius = mapBounds.size.x / 2;
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {

        distanceToCenter = Vector3.Distance(transform.position, mapBounds.center);

        if (elapsed > duration || distanceToCenter > radius - 5f)
        {
            PickRandomRotation();
            elapsed = 0f;
        }


        elapsed += Time.fixedDeltaTime;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime);

        VerticalMove();

        if (transform.position.y < -2)
        {
            PrefabController.instance.DestroyCar(this.gameObject);
            GameManager.carCount--;
        }
    }

    public void AvoidMapBounds()
    {
        direction = (mapBounds.center - transform.position).normalized;

        lookRotation = Quaternion.LookRotation(direction); //look towards center
    }

    public void VerticalMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);
    }

    public void PickRandomRotation()
    {
        if (distanceToCenter > radius - 5f) //map bounds are close
        {
            AvoidMapBounds();
        }
        else
        {
            randomAngle = Random.Range(-maximumSteeringAngle, maximumSteeringAngle);
            duration = Random.Range(2, 4);
            lookRotation.eulerAngles = new Vector3(0, randomAngle, 0);
        }
    }

}
