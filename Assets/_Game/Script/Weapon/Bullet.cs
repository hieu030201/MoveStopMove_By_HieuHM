using System;
using UnityEngine;

public class Bullet : GameUnit
{
    protected Character attacker;
    protected Action<Character, Character> onHit;
    // set bullet data for bullet
    public virtual void OnInit(Character attacker, Action<Character, Character> onHit)
    {
        this.attacker = attacker;
        this.onHit = onHit;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            Character victim = Cache.GetCollectCharacter(other);
            onHit?.Invoke(attacker, victim);
        }
    }
}
