using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSound : StateMachineBehaviour
{
    AudioManager audioManager;
    public bool playOnEnter = true, playOnExit = false, playAfterDelay = false;

    //delayed sound timer
    public float playDelay = 0.25f;
    private float timeSinceEntered = 0f;
    private bool hasDelayedSoundPlayed = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnEnter)
        {
            audioManager.PlaySFX(audioManager.enemyDeath);
        }

        timeSinceEntered = 0f;
        hasDelayedSoundPlayed = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playAfterDelay && !hasDelayedSoundPlayed)
        {
            timeSinceEntered += Time.deltaTime;

            if (timeSinceEntered > playDelay)
            {
                audioManager.PlaySFX(audioManager.enemyDeath);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnExit)
        {
            audioManager.PlaySFX(audioManager.enemyDeath);
        }
    }
}
