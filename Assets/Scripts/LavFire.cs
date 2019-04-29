using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavFire : MonoBehaviour
{
    public AudioClip fireSound;
    public AudioSource fireSourse;
    public GameObject barrel;
    private Animator anim;
    public float damage=10f;
    public float range=100f;
    public float impactForce=30f;
    public Camera gunnerCam;
    public ParticleSystem muzzleSmoke;
    public GameObject impactEffect;
    public GameObject shellPrefab;
    public Transform shellSpawner;

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
            Shoot();
        }
    }

    public void Shoot(){
        if(!fireSourse.isPlaying)
            {
                fireSourse.Play();
                 anim.Play("FireAnim");
                 CastRay();
                 SpawnShell();
            }   
    }
     
    public void CastRay()
    {
        muzzleSmoke.Play();
        RaycastHit hit;

        if (Physics.Raycast(gunnerCam.transform.position, gunnerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TargetBehaviour target = hit.transform.GetComponent<TargetBehaviour>();
            if (target!=null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody!=null)
            {
                hit.rigidbody.AddForce(hit.normal*impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    private void SpawnShell()
    {
        GameObject shellInstance=Instantiate(shellPrefab, shellSpawner.position, shellSpawner.rotation);
    }
}
