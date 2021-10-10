using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerHandler : MonoBehaviour
{
    // Variable for the ways which our player moves
    [Header("General")]
    [Tooltip ("In ms^-1")] [SerializeField] float xSpeed = 20f;
    [Tooltip ("In ms^-1")] [SerializeField] float ySpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 15.5f;
    [Tooltip("In m")] [SerializeField] float yRange = 8.0f;
    [SerializeField] GameObject[] guns;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -10f;

    [SerializeField] float positionYawFactor = -1f;
    [SerializeField] float controlYawFactor = -5f;

    [SerializeField] float positionRollFactor = -1f;
    [SerializeField] float controlRollFactor = -5f;

    [SerializeField] GameObject deathExplosion;

    

    bool isControlEnabled = true;
    bool fire = false; //probably doesn't need to be here??
    public int runNumber = 0;

    public Joystick joystick;

    float xThrow;
    float yThrow;

    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessGunSound();
            //ProcessFiring();
        }
        
    }  

    void OnPlayerDeath()
    {
        isControlEnabled = false;
        deathExplosion.SetActive(true);
        
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        //  Touch Control
        xThrow = joystick.Horizontal;
        //print(xThrow);
        yThrow = joystick.Vertical;
        
        //Keyboard/ Joystick control
        //xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //print(xThrow);
        //yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    public void EnableFire()
    {

        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = true;
            fire = true;
            gun.SetActive(true);
        }
    }

    public void DisableFire()
    {
        print("disable fire");
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
            fire = false;
            gun.SetActive(true);
        }
    }

    public void ProcessGunSound()
    {
        if (fire)
        {
            FindObjectOfType<GunAudioPlayer>().PlayGunSound();
        }

        else
        {
            FindObjectOfType<GunAudioPlayer>().StopGunSound();
        }

    }
}
