using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    public Animator animator;
    // Choose between the two options of defending an atttack
    public string[] defenseChoosing = new string[] { "Defense1", "Defense2" };
    public string defenseChosen;

    public void DefenseChoosing()
    {
        // When Blue Ghost is defending, there will be two animations to choose
        defenseChosen = defenseChoosing[Random.Range(0, 1)];
        if (defenseChosen == "Defense1")
        {
            //Defense1();
            Defense1();
        }
        else
        {
            Defense2();
        }
    }

    public void Damage()
    {
        animator.SetBool("Damage", true);
        StartCoroutine(DamageEnds(2));
    }

    IEnumerator DamageEnds(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Damage", false);
    }

    // Enemies only have a defense animation
    public void Defense()
    {
        animator.SetBool("Defense", true);
        StartCoroutine(DefenseEnds(2));
    }

    IEnumerator DefenseEnds(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Defense", false);
    }

    // Blue Ghost has two defense animations
    public void Defense1()
    {
        animator.SetBool("Defense1", true);
        StartCoroutine(Defense1Ends(2));
    }

    IEnumerator Defense1Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Defense1", false);
    }

    public void Defense2()
    {
        animator.SetBool("Defense2", true);
        StartCoroutine(Defense2Ends(2));
    }

    IEnumerator Defense2Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Defense2", false);
    }

    public void Died()
    {
        animator.SetBool("Dead", true);
        StartCoroutine(DiedEnds(3));
    }

    IEnumerator DiedEnds(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Dead", false);
    }
    public void Melee1()
    {
        animator.SetBool("Fist", true);
        StartCoroutine(Melee1Ends(2));
    }

    IEnumerator Melee1Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Fist", false);
    }

    public void Melee2()
    {
        animator.SetBool("Kick", true);
        StartCoroutine(Melee2Ends(2));
    }

    IEnumerator Melee2Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Kick", false);
    }

    public void Range1()
    {
        animator.SetBool("Throw", true);
        StartCoroutine(Range1Ends(2));
    }

    IEnumerator Range1Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Throw", false);
    }

    public void Range2()
    {
        animator.SetBool("Shoot", true);
        StartCoroutine(Range2Ends(2));
    }

    IEnumerator Range2Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Shoot", false);
    }
}
