using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavFire : MonoBehaviour
{
    public AudioClip fireSound;
    public AudioSource fireSourse;
    public GameObject barrel;
    private Animator anim;

    void Start() {
        fireSourse.clip=fireSound;
        anim=barrel.GetComponent<Animator>();

    }
    void Update(){
        Fired();
    }

    private void Fired()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {   
            PlaySound();
            PlayAnim();
        }
    }

    public void PlaySound(){
        if(!fireSourse.isPlaying)
            {
                fireSourse.Play();
            }   
    }

    public void PlayAnim(){
        //TODO: add condition: play only if not being played already
        anim.Play("FireAnim");
    }
   
}
