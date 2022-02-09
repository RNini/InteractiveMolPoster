using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;                // Need this in order to change any Text Mesh Pro components

public class FlipBoardManager : MonoBehaviour
{
    public Animator[] animators;              // Local animator attached to this gameObject
        public int[] stateIndex;      // Used to store current animation state,
                                    // and manually set in scene for different instances

    // Variables for handing text in spinner text boxes
    public TextMeshPro[] spinnerTextBox;  
        [TextArea]                                  // Needed for easy text manipulation
        public string[] spinnerText;

    public GameObject[] spinnerPanels;

    public int textIndex;

    // Temp variables for text setting
    public TextMeshPro topPanel;
    public TextMeshPro bottomPanel;
    public TextMeshPro backPanel;

    // Start is called before the first frame update
    void Start()
    {
        textIndex = 0;
        activateAnimState();    // Ensures all the players are in place

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Functions for setting animation states
    public void activateAnimState()
    {
        for (int i = 0; i < 3; i++)
        {
            // Cycle to the next index
            if (stateIndex[i] == 2) { stateIndex[i] = 0; }

                else { stateIndex[i]++; }

            // Sets the animation state to start animation
            if (stateIndex[i] == 0)
            {
                animators[i].SetBool("LoadIn", true);
                    animators[i].SetBool("FlipDown", false);
                    animators[i].SetBool("FlipBack", false);
            }

            else if (stateIndex[i] == 1)
            {
                animators[i].SetBool("FlipDown", true);
                    animators[i].SetBool("LoadIn", false);
                    animators[i].SetBool("FlipBack", false);
            }

            else if (stateIndex[i] == 2)
            {
                animators[i].SetBool("FlipBack", true);
                    animators[i].SetBool("LoadIn", false);
                    animators[i].SetBool("FlipDown", false);
            }


        }     

    }

        // Functions for animation event triggers
        public void resetLoadIn()
        {
            
        }

        public void resetFlipDown()
        {
            
        }

        public void resetFlipBack()
        {
            
        }

     

    // Functions for setting text
    public void setFC()
    {
        textIndex = 1;
            panelSolver(textIndex);
    }

        public void setFAB()
        {
            textIndex = 2;
                panelSolver(textIndex);
        }

        public void setAntigen()
        {
            textIndex = 3;
                panelSolver(textIndex);
        }

        public void setIsotype()
        {
            textIndex = 4;
                panelSolver(textIndex);
        }

            public void panelSolver(int Index)
            {
                // Temporary variables for our panels
                /*TextMeshPro topPanel;
                    TextMeshPro bottomPanel;
                    TextMeshPro backPanel;*/
        
                    // Cycles through the panels to determine their order and assign to temp variables
                    for (int i = 0; i < stateIndex.Length; i++)
                    {
                        // Checks the stateIndex of the current game object
                        int currState = stateIndex[i];
                            

                        if (currState == 0)
                        {
                            bottomPanel = spinnerTextBox[(i * 2) +1];
                                setText(spinnerText[Index * 2 + 1], bottomPanel);
                        }

                            else if (currState == 1)
                            {
                                backPanel = spinnerTextBox[(i * 2)];
                                //setText(spinnerText[Index*2], backPanel);
                            }

                            else if (currState == 2)
                            {
                                topPanel = spinnerTextBox[(i * 2)];
                                setText(spinnerText[Index*2], topPanel);
                            }
                    }
            }

                public void setText(string text, TextMeshPro textPanel)
                {
                    textPanel.text = text;
                }
}
