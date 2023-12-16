using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour
{
    public const string TAG_CHARACTER = "Character";
    public const string ANIM_IDLE = "idle";
    public const string ANIM_WIN = "win";
    public const string ANIM_RUN = "run";
    public const string ANIM_ATTACK = "attack";
    public const string ANIM_DEAD = "die";
    public const string ANIM_DANCE = "dance";
    public const string ANIM_ULTI = "ulti";
    public const float TIME_WEAPON_RELOAD = 0.5f;

}
public enum BulletType
{
    B_Hammer_1 = PoolType.B_Hammer_1,
    B_Hammer_2 = PoolType.B_Hammer_2,
    B_Hammer_3 = PoolType.B_Hammer_3,
    B_Candy_1 = PoolType.B_Candy_1,
    B_Candy_2 = PoolType.B_Candy_2,
    B_Candy_3 = PoolType.B_Candy_3,
    B_Boomerang_1 = PoolType.B_Boomerang_1,
    B_Boomerang_2 = PoolType.B_Boomerang_2,
    B_Boomerang_3 = PoolType.B_Boomerang_3,
}

public enum WeaponType
{
    W_Hammer_1 = PoolType.W_Hammer_1,
    W_Hammer_2 = PoolType.W_Hammer_2,
    W_Hammer_3 = PoolType.W_Hammer_3,
    W_Candy_1 = PoolType.W_Candy_1,
    W_Candy_2 = PoolType.W_Candy_2,
    W_Candy_3 = PoolType.W_Candy_3,
    W_Boomerang_1 = PoolType.W_Boomerang_1,
    W_Boomerang_2 = PoolType.W_Boomerang_2,
    W_Boomerang_3 = PoolType.W_Boomerang_3,
}
