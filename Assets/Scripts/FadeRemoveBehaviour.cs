using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeRemoveBehaviour : StateMachineBehaviour
{
    public float fadeTime = 1.0f;
    private float elapsedTime = 0f;
    SpriteRenderer spriteRenderer;
    GameObject objToRemove;
    Color startColor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        elapsedTime = 0f;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        objToRemove = animator.gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        elapsedTime += Time.deltaTime;

        float newAlpha = startColor.a * (1 - (elapsedTime / fadeTime));

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

        if(elapsedTime > fadeTime)
        {
            Destroy(objToRemove);
        }
    }
}
