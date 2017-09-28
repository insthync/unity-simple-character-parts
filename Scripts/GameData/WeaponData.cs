using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponData : ItemData
{
    public GameObject rightHandObject;
    public GameObject leftHandObject;
    public GameObject shieldObject;
    [Range(0, 100)]
    public int actionId;
    public float animationDuration;
    public float launchDuration;
    public DamageEntity damagePrefab;

    public void Launch(CharacterEntity attacker, int damage)
    {
        var damageLaunchTransform = attacker.damageLaunchTransform;
        var damageEntity = Instantiate(damagePrefab, damageLaunchTransform.position, damageLaunchTransform.rotation);
        var gameplayManager = GameplayManager.Singleton;
        damageEntity.damage = damage + Mathf.RoundToInt(Random.Range(gameplayManager.minAttackVaryRate, gameplayManager.maxAttackVaryRate) * damage);
        damageEntity.Attacker = attacker;
        damageEntity.gameObject.SetActive(true);
        NetworkServer.Spawn(damageEntity.gameObject);
    }
}
