using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsBehaviour : MonoBehaviour
{
    public AudioClip fireSound;
    public AudioSource fireSourse;

    void Start() {
        fireSourse.clip=fireSound;
    }
    void Update(){
        Fire();
    }

    private void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            if(fireSourse.isPlaying==false)
            {
                fireSourse.Play();
            }
            
        }
    }
}
