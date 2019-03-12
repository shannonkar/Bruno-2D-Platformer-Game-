using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    public AudioMixerSnapshot outOfAction;
    public AudioMixerSnapshot inAction;
    public float bpm = 128;

    // time in milliseconds to fade the music + store length of quarter note
    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    void Start()
    {
        // improving the sound of transitions
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote/10;
        m_TransitionOut = (m_QuarterNote * 32)/10;
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Action"))
        {
            print("action entered");
            inAction.TransitionTo(m_TransitionIn);
        }
    }

    // void OnTriggerExit2D(Collision2D other)
    // {
    //     if (other.collider.CompareTag("Door"))
    //     {
    //         print("intense entered");
    //         outOfAction.TransitionTo(m_TransitionOut);
    //     }
    // }
}
