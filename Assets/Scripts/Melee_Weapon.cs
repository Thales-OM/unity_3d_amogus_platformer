using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Weapon : MonoBehaviour
{   
    public string Layer;
    public string Sword_Down; //можно добавить хэширование, но стоит выяснить насколько влияет на скорость вызова
    public string Sword_Up;
    public string Sword_Draw;
    public string Sword_Swing_Punch;
    public string Sword_Sheath;
    private float time_before_idle;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        time_before_idle = 0f;
    }

    void OnEnable()
    {
        animator.Play(Sword_Draw);
        time_before_idle = 0f;
    }
    void Update()
    {
        // leave spin or jump to complete before changing
        /*if (anim.isPlaying)
        {
            return;
        }*/

        if (Input.GetMouseButtonDown(0))//& !AnimatorIsPlaying(animator, Sword_Swing_Punch))
        {
            Debug.Log("Swing");
            animator.Play(Sword_Swing_Punch, -1, 0f);
        }

        

        
    }

    /*internal static bool AnimatorIsPlaying(Animator animator, string name)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(name) & animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }*/

    /*internal static AnimationClip GetAnimationClipFromAnimatorByName(Animator animator, string name)
        {
            //can't get data if no animator
            if (animator == null)
                return null;
    
            //favor for above foreach due to performance issues
            for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                if (animator.runtimeAnimatorController.animationClips [i].name == name)
                    return animator.runtimeAnimatorController.animationClips [i];
            }
    
            Debug.LogError ("Animation clip: " +name + " not found");
            return null;
        }*/
}