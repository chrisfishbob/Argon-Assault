using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip gunAudio;
    AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public void PlayGunSound()
    {
        if (!audioData.isPlaying)
        {
            audioData.PlayOneShot(gunAudio);
        }
    }

    public void StopGunSound()
    {
        audioData.Stop();
    }

}
