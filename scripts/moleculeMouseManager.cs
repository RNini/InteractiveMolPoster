using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleculeMouseManager : MonoBehaviour
{

    public Animator[] activeAnimators;
        public Animator[] inactiveAnimators;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void OnMouseEnter()
    {
        // Only activates the glow animation for relevant objects
        activateGlow(activeAnimators); 
    }

    public void OnMouseExit()
    {
        // Turns off all glow effects
        deactivateGlow(activeAnimators);            
    }

    public void activateGlow(Animator[] animators)
    {
        for (int i = 0; i<animators.Length; i++)
        {
            animators[i].Play("GlowActivate");
        }
    }

    public void deactivateGlow(Animator[] animators)
    {
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].Play("GlowDeactivate");
        }
    }

    public void buttonActivation()
    {
        StartCoroutine(highlightStructure());
    }

    IEnumerator highlightStructure()
    {
        // Turns on glow animations
        for (int i = 0; i < activeAnimators.Length; i++)
        {
            activeAnimators[i].Play("GlowActivate");
        }

            // Turns off any miscelaneous glow animations currently happening
            for (int i = 0; i < inactiveAnimators.Length; i++)
            {
                inactiveAnimators[i].Play("GlowOff");
            }

        yield return new WaitForSeconds(5);

        // After 5 seconds, turns off glow animations
        for (int i = 0; i < activeAnimators.Length; i++)
        {
            activeAnimators[i].Play("GlowDeactivate");
        }
    }
}
