using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangeAtt : MonoBehaviour
{
    [SerializeField] private Character parent;
    public Character enemyTarget;

    public List<Character> enemyList = new List<Character>();

    private void OnTriggerEnter(Collider other)
    {
        Character c = Cache.GetCollectCharacter(other);
        if (other.CompareTag(Constant.TAG_CHARACTER) && parent != c & !c.isDead)
        {
            enemyList.Add(c);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Character c = Cache.GetCollectCharacter(other);
        if (other.CompareTag(Constant.TAG_CHARACTER) && parent != c)
        {
            enemyList.Remove(c);
            c.cicleSelect.SetActive(false);
        }

    }
    public Character GetNearestEnemy()
    {
        // Loại bỏ những kẻ chết khỏi danh sách
        enemyList.RemoveAll(enemy => enemy.isDead);

        // Sắp xếp danh sách dựa trên khoảng cách tới cha
        enemyList = enemyList.OrderBy(enemy => Vector3.Distance(parent.transform.position, enemy.transform.position)).ToList();

        // Lấy phần tử đầu tiên (gần nhất)
        if (enemyList.Count > 0)
        {   
            if (enemyList[0] is Enemy && parent is Player)
            {
                enemyList[0].cicleSelect.SetActive(true);
            }
           
            for (int i = 1; i < enemyList.Count; i++)
            {
                enemyList[i].cicleSelect.SetActive(false);
            }

            this.enemyTarget = enemyList[0];
            return enemyTarget;
        }

        return null; // Trả về null nếu danh sách rỗng
    }

}
