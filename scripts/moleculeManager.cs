using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moleculeManager : MonoBehaviour
{
    Slider molSlider;

    public GameObject moleculeParent;

    public bool defaultAnimation;

    // Start is called before the first frame update
    void Start()
    {
        molSlider = this.gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Automatically rotates the molecule until we interact with the slider
        if (defaultAnimation == true)
        {
            molSlider.value += Time.deltaTime * 20;
        }    
        
        molSlider.value = moleculeParent.transform.localRotation.eulerAngles.y; 
    }

    public void rotateMolecule()
    {        
        moleculeParent.transform.rotation = Quaternion.Euler(346.8f, molSlider.value, 264.5f);
    }

    public void togglTurnTable()
    {
        // We stop the default turn-table rotation once the player interacts with the slider
        if (defaultAnimation) { defaultAnimation = false; }
        
        // Or resume it if we click the button again
        else { defaultAnimation = true; }
    }
}
