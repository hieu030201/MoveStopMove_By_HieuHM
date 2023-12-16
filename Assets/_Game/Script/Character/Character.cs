using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : GameUnit 
{
    public Animator anim;
    private string animName;
    [SerializeField] public Transform rightHand;

    public RangeAtt attackRange;

    public float rotationSpeed = 3.0f;


    public bool isDead;
    public bool isMove = false;
    [SerializeField] public GameObject cicleSelect;

    public Weapon currentWeapon;
    public Weapon Weapon => currentWeapon;
    [SerializeField] BulletType bulletType;

    public void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {

    }
    public virtual void Update()
    {
        SelectNearEnemy();

    }
    public void ChangeAnim(string animName)
    {
        if(this.animName != animName)
        {
            anim.ResetTrigger(this.animName);
            this.animName = animName;
            anim.SetTrigger(this.animName);
        }
    }
    public void ResetAnim()
    {
        animName = "";
    }

    public virtual void Stop()
    {
        
    }

    public void DirectAttack(Vector3 enemyPos)
    {
        if (enemyPos == null) return;
        
        Vector3 directionToTarget = enemyPos - TF.position;
        directionToTarget.y = 0;
        Quaternion rotation = Quaternion.LookRotation(directionToTarget);
        Quaternion begin = Quaternion.Euler(0, TF.eulerAngles.y, 0);
        Quaternion target = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
        if (!isMove) 
        {
            TF.rotation = Quaternion.Slerp(begin, target, rotationSpeed * Time.fixedDeltaTime);
        }
    }
    public void SelectNearEnemy()
    {
        Character nearestEnemy = attackRange.GetNearestEnemy();
        if (nearestEnemy != null)
        {
            Vector3 targetEnemy = nearestEnemy.TF.position;
            DirectAttack(targetEnemy);
        }

    }

    //public void Attack()
    //{
    //    if (!isMove)
    //    {
    //        Throw();
    //    }
    //}
    //public void Throw()
    //{
    //    Bullet bullet = SimplePool.Spawn<Bullet>((PoolType)bulletType, TF.position, Quaternion.identity);
    //}

}
