using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private AudioSource m_RunningAudio;
    private AudioSource m_CrouchingAudio;

    void Start()
    {
        m_RunningAudio = transform.Find("RunningAudio").GetComponent<AudioSource>();
        m_CrouchingAudio = transform.Find("CrouchingAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySoundRunning()
    {
        m_RunningAudio.Play();
    }

    public void PlaySoundCrouching()
    {
        m_CrouchingAudio.Play();
    }
}