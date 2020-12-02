using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersAnimations : MonoBehaviour
{
public GameObject AnimationToPlay;

public Animator theAnimator;

public float waitTime1;
public float waitTime2;

public string animName;

public bool isAudioTrigger;
public bool isAnimTrigger;

public AudioClip audioToPlay;

void OnTriggerEnter()
{
    if(isAnimTrigger == true)
    {
    StartCoroutine(PlayAnimation());
    }
    if(isAudioTrigger == true)
    {
    StartCoroutine(PlayAudio());
    }
    StartCoroutine(destroyTrigger());
}



IEnumerator PlayAnimation()
{
    theAnimator = AnimationToPlay.GetComponent<Animator>();
    yield return new WaitForSeconds(waitTime1);
    theAnimator.Play(animName);
}

IEnumerator PlayAudio()
{
    AudioSource audio = GetComponent<AudioSource>();
    audio.Play();
    audio.clip = audioToPlay;
    
    yield return new WaitForSeconds(1);
}

IEnumerator destroyTrigger()
{
    yield return new WaitForSeconds(waitTime2);
    gameObject.SetActive(false);
}
}
