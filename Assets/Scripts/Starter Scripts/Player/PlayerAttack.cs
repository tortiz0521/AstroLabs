using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject meleeWeapon;

    //public GameObject playerReference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !meleeWeapon.activeSelf)
        {
            StartCoroutine(meleeAttack());
        }
    }

    private IEnumerator meleeAttack()
    {
        if (TryGetComponent(out PlayerAudio audio))
        {
            audio.AttackSource.Play();
        }
        meleeWeapon.SetActive(true);
        float time = meleeWeapon.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        yield return new WaitForSeconds(time);
        meleeWeapon.SetActive(false);
    }
}
