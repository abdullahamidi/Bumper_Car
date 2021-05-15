using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{

    private bool isPressing = false;
    private bool isUsable = false;
    private bool isFunctionUsed = true;

    public float chargeTime = 4.0f;
    public float useTime = 2.0f;
    public int speedMultiplier = 2;

    private float _chargeTime;
    private float _useTime;
    public Button speedUpButton;

    private void Start()
    {
        _chargeTime = chargeTime;
        _useTime = useTime;
    }

    private void Update()
    {
        if (isPressing && isUsable)
        {
            if (_useTime < 0)
            {
                isUsable = false;
                _chargeTime = chargeTime;
            }
            else
                _useTime -= Time.deltaTime;
        }
        else
        {
            if (_chargeTime < 0)
            {
                _useTime = useTime;
                isUsable = true;
            }
            else
            {
                _chargeTime -= Time.deltaTime;
            }
        }

        if (isUsable)
        {
            speedUpButton.gameObject.SetActive(true);
        }
        else
        {
            speedUpButton.gameObject.SetActive(false);
            if (!isFunctionUsed)
            {
                OnRelease();
            }
        }

    }
    public void SpeedIncrease()
    {
        CarController.instance.speed *= speedMultiplier;
    }

    public void SpeedDecrease()
    {
        CarController.instance.speed /= speedMultiplier;
    }

    public void OnPress()
    {
        isFunctionUsed = false;
        isPressing = true;
        SpeedIncrease();
        Debug.Log("Hızlanıyorum " + CarController.instance.speed);
    }

    public void OnRelease()
    {
        isPressing = false;
        SpeedDecrease();
        Debug.Log("Yavaşlıyorum " + CarController.instance.speed);
        isFunctionUsed = true;

    }

}
