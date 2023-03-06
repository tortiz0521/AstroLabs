﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //This class should be placed on anything enemy related! Or anything that the player can damage
    public int maxHealth = 100;

    public int currentHealth;

    public PlayerController pc;

    [Header("If creating AudioSource obj, name it EnemyHurtSource")]
    public bool useExistingAudios = false;

    [Header("Place .wav file here")]
    public AudioClip HurtAudioClip;
    public bool loopHurt = false;
    [HideInInspector]public AudioSource HurtAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        InitAudio();
        currentHealth = maxHealth;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    public void DecreaseHealth(int value)
    {
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out DamageDealer damageValues))
        {
            if (damageValues.damageType == DamageDealer.DamageType.Player && pc.charging)
            {
                if (!pc.freezePlayer) {
                    HurtAudioSource.Play();
                }
                else {
                    HurtAudioSource.Stop();
                }
                DecreaseHealth(damageValues.DamageValue);
                if (currentHealth == 0)
                {
                    Destroy(this.gameObject);//If this enemy reaches 0 health, they are straight up destroyed. 
                    //If you want something fancy like an animation or the like, you can try to implement it here
                }
            }
        }
    }
    void InitAudio() {
        if (useExistingAudios) {
            HurtAudioSource = GameObject.Find("EnemyHurtSource").GetComponent<AudioSource>();
        }
        else {
            GameObject HurtGameObject = new GameObject("HurtAudioSource");
            
            //AssignParent(HurtGameObject);

            HurtAudioSource = HurtGameObject.AddComponent<AudioSource>();

            HurtAudioSource.clip = HurtAudioClip;   

            // can create option to add volume

            HurtAudioSource.loop = loopHurt;
        }
    }
    void AssignParent(GameObject obj)
    {
        obj.transform.parent = transform;
    }
}
