using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAndShooting : MonoBehaviour
{
    [Header("Projectile Prefab")]
    public GameObject prefabHat;
    [Header("Spawner Point fot Hat")]
    public Transform spawnerHat;
    [Header("Projectile Prefab")]
    public GameObject prefabShotEffect;
    [Header("Spawner Point fot Hat")]
    public Transform spawnerShotEffect;
    GameObject hatGameObject;
    GameObject shotEffectGameObject;
    //private PlayerSoundManager psm;

    public void ThrowHat()
    {
        hatGameObject = Instantiate(prefabHat, spawnerHat.position, spawnerHat.rotation);
        StartCoroutine(DestroyHat(1));
    }

    // Destory hat when it goes forward and backward in scene
    IEnumerator DestroyHat(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(hatGameObject);
    }

    public void ShootGun()
    {
        shotEffectGameObject = Instantiate(prefabShotEffect, spawnerShotEffect.position, spawnerShotEffect.rotation);
        StartCoroutine(DestroyShootEffect(0.3f));
    }

    // Destory hat when it goes forward and backward in scene
    IEnumerator DestroyShootEffect(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(shotEffectGameObject);
    }
}
