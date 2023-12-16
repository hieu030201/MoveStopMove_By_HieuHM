using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class Weapon : GameUnit
{
    [SerializeField] GameObject child;
    [SerializeField] BulletType bulletType;

    public void SetActive(bool active)
    {
        child.SetActive(active);
    }
    public void Throw(Character character, Action<Character, Character> onHit)
    {
        Bullet bullet = SimplePool.Spawn<Bullet>((PoolType)bulletType, TF.position, Quaternion.identity);
        bullet.OnInit(character, onHit);
    }
}
