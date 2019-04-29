using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Thankyou Electronic Brain for the script. It adds sounds to the hover of a button
 * https://www.youtube.com/watch?v=MjH5rsmYmQY&list=WL&index=70&t=0s */

public class BtnFX : MonoBehaviour {

    public AudioSource myFx; //Reference to the AudioSource
    public AudioClip hoverFx; //Sound effect for the hover over the button
   


    public void HoverSound() //Plays a sound effect when the mouse hovers over the button
    {
        myFx.PlayOneShot(hoverFx);
    }

}
