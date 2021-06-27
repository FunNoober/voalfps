using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class TriggersAnimations : MonoBehaviour
{

    public AnimationsClass[] animations;
    public SceneFading fader;

    void OnTriggerEnter()
    {
        for(int i = 0; i < animations.Length; i++)
        {
            //Animation Trigger
            if(animations[i].isAnimationTrigger == true)
            {
                animations[i].objectToAnimate.GetComponent<Animator>().Play(animations[i].animationName);
            }

            //Audio Trigger
            if(animations[i].isAudioTrigger == true)
            {
                animations[i].source.clip = animations[i].audioToPlay;
                animations[i].source.Play();
            }

            //Disable Trigger
            if(animations[i].isDisableTrigger == true)
            {
                for(int x = 0; x < animations[i].objectsToSetActive.Length; x++)
                {
                    animations[i].objectsToSetActive[x].SetActive(false);
                }
            }

            //Enable Trigger
            if(animations[i].isEnableTrigger == true)
            {
                for(int y = 0; y < animations[i].objectsToSetActive.Length; y++)
                {
                    animations[y].objectsToSetActive[y].SetActive(true);
                }
            }

            //Level Trigger
            if(animations[i].isLevelTrigger == true)
            {
                fader.FadeIn();
            }
        }


        DestroyTrigger();
    }

    void DestroyTrigger()
    {
        Destroy(this.gameObject);
    }



    [System.Serializable]
    public class AnimationsClass
    {
        public GameObject objectToAnimate;
        public GameObject[] objectsToSetActive;
        public AudioSource source;
        public AudioClip audioToPlay;

        public bool isAudioTrigger = false;
        public bool isAnimationTrigger = false;
        public bool isDisableTrigger = false;
        public bool isEnableTrigger = false;
        public bool isLevelTrigger = false;

        public string animationName;
    }

}
