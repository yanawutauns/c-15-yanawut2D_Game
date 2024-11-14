using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    int health = 10; //set;
    public int Health => health; //get;

    float strength = 10.0f;
    public float Strenth => strength;

    float speed = 5.0f;
    public float Speed => speed;

    float originalSpeed;
    float speedBoostDuration = 0.0f;
    float speedBoostTimer = 0.0f;
    bool isSpeedBoostActive = false;

    [SerializeField] TextMeshProUGUI healthTxt, speedTxt, strengthTxt;
    void Start()
    {
        originalSpeed = speed;
        UpdateHealthText();
        UpdateSpeedText();
        UpdateStrengthText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpeedBoostTimer();
    }

    void UpdateSpeedBoostTimer()
    {
        if (isSpeedBoostActive)
        {
            speedBoostTimer += Time.deltaTime;
            Debug.Log("++++Speed Boost++++");
            if (speedBoostTimer >= speedBoostDuration)
            {
                speed = originalSpeed;
                isSpeedBoostActive = false ;
                Debug.Log("Speed boost ended. Speed reser.");
            }
        }
    }

    public void PowerUp(int healthIncrease)
    {
        health += healthIncrease;
        Debug.Log($"Health increased by {healthIncrease} . New health : {health}");
        UpdateHealthText();
    }

    public void PowerUp(float strenthMultiplier)
    {
        strength *= strenthMultiplier;
        Debug.Log($"Health increased by {strenthMultiplier * 100}% . New Strength : {strength}");
        UpdateStrengthText();
    }

    public void PowerUp(float speedMultiplier, float duration)
    {
        if (!isSpeedBoostActive)
        {
            speed *= speedMultiplier;
            isSpeedBoostActive = true ;
            speedBoostDuration = duration;
            speedBoostTimer = 0.0f;
            UpdateSpeedText();
            Debug.Log($"Health increased by {speedMultiplier * 100}% for {duration} seconds. ");
        }
    }
    void UpdateHealthText()
    {
        healthTxt.text = $"Health: {Health}";
    }

    void UpdateStrengthText()
    {
        strengthTxt.text = $"Strength: {Strenth}";
    }

    void UpdateSpeedText()
    {
        speedTxt.text = $"Speed: {Speed}";
    }
}