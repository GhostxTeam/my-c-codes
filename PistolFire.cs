using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolFire: MonoBehaviour
{
    public float reloadcooldown;
    public float AmmoInGun;
    public float AmmoInPacket;
    public float AmmoMax;
    float AddableAmmo;
    float reloadtimer;
    public Text AmmoCounter;
    public Text PocketAmmoCounter;
    public AudioClip YenilemeSesi;
    public GameObject Untagged;
    public GameObject DuvarEfekti;
    public GameObject MetalEfekti;
    public GameObject TahtaEfekti;
    RaycastHit hit;
    public GameObject RayPoint;

    public bool CanFire;
    Animator GunAnimset;
    float GunTimer;
    public float guncooldown;
    public CharacterController karakter;
    public ParticleSystem MuzzleFlash;

    AudioSource Ses;
    public AudioClip AteşSesi;
    public float range;
    void Start()
    {
        Ses = GetComponent<AudioSource>();
        GunAnimset = GetComponent<Animator>();
    }

   
    void Update()
    {
        GunAnimset.SetFloat("hız",karakter.velocity.magnitude);


        AmmoCounter.text = AmmoInGun.ToString();
        PocketAmmoCounter.text = AmmoInPacket.ToString();

        AddableAmmo = AmmoMax - AmmoInGun;


        if(AddableAmmo > AmmoInPacket)
        {
            AddableAmmo = AmmoInPacket;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && CanFire == true && Time.time > GunTimer && AmmoInGun > 0)
        {
            Fire();
            GunTimer = Time.time + guncooldown;
            

            if (hit.transform.tag == "TahtaEfekti")
            {
                Instantiate(TahtaEfekti, hit.point, Quaternion.LookRotation(hit.normal));
            }

            if (hit.transform.tag == "MetalEfekti")
            {
                Instantiate(MetalEfekti, hit.point, Quaternion.LookRotation(hit.normal));
            }

            if (hit.transform.tag == "DuvarEfekti")
            {
                Instantiate(DuvarEfekti, hit.point, Quaternion.LookRotation(hit.normal));
            }

        }    

        if(Input.GetKeyDown(KeyCode.R) && AddableAmmo > 0 && AmmoInPacket > 0)
        {
            if(Time.time > reloadtimer)
            {
                StartCoroutine(Reload());
                reloadtimer = Time.time + reloadcooldown;
            }

        }




    }

   
    void Fire()
    {
        
        if(Physics.Raycast(RayPoint.transform.position, RayPoint.transform.forward, out hit, range))
        {
            AmmoInGun--;
            MuzzleFlash.Play();
            Ses.Play();

            Ses.clip = AteşSesi;

            GunAnimset.Play("fire", -1,0f);

            Debug.Log(hit.transform.name);

            if (hit.transform.tag == "Untagged")
            {
                Instantiate(Untagged, hit.point, Quaternion.LookRotation(hit.normal));
            }


        }
    }


    IEnumerator Reload()
    {
        
        GunAnimset.SetBool("isReloading", true);
        CanFire = false;

        Ses.clip = YenilemeSesi;
        Ses.Play();

        yield return new WaitForSeconds(0.3f);
        GunAnimset.SetBool("isReloading", false);

        yield return new WaitForSeconds(1.4f);
        AmmoInGun = AmmoInGun + AddableAmmo;
        AmmoInPacket = AmmoInPacket - AddableAmmo;
        CanFire = true;
        
    }




}
