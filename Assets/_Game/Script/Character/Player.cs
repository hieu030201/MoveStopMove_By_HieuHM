using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    #region MOVING
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    private Vector3 _moveVector;
    #endregion
    WeaponType weaponType = WeaponType.W_Candy_1;

    private FloatingJoystick Joystick
    {
        get
        {
            if (floatingJoystick == null)
            {
                floatingJoystick = FindObjectOfType<FloatingJoystick>();
            }
            return floatingJoystick;
        }
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeWeapon(weaponType);
    }
    public override void Update()
    {
        base.Update();
        Move();
    }

    private void Move()
    {
        if (!isDead)
        {
            _moveVector = Vector3.zero;
            _moveVector.x = Joystick.Horizontal * moveSpeed * Time.deltaTime;
            _moveVector.z = Joystick.Vertical * moveSpeed * Time.deltaTime;

            if (Joystick.Horizontal != 0 || Joystick.Vertical != 0)
            {
                isMove = true;
                Vector3 direction = Vector3.RotateTowards(TF.forward, _moveVector, rotateSpeed * Time.deltaTime, 0.0f);
                TF.rotation = Quaternion.LookRotation(direction);
                ChangeAnim(Constant.ANIM_RUN);
            }
            else if (Joystick.Horizontal == 0 && Joystick.Vertical == 0)
            {
                isMove = false;
                Stop();
            }
            this.TF.position += _moveVector;
        }

    }

    public override void Stop()
    {
        base.Stop();
        ChangeAnim(Constant.ANIM_IDLE);
    }
    public void ChangeWeapon(WeaponType weaponType)
    {
        currentWeapon = SimplePool.Spawn<Weapon>((PoolType)weaponType, rightHand);
    }
}
