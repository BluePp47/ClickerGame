using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour
{
    EnemyData enemyData;
    public PlayerData playerData;
    public WeaponData weaponData;

    public int AutoAttacklevel = 0;// 자동공격
    public int CriticalLevel = 1;
    public float TouchAttackCoolDown = 0.2f;//터치 쿨다운
    public float LastAtkTouch;
    public bool IsAttackTouch = true;

    private Coroutine AutoAttackCoroutine;

    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(AutoAttackRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        LastAtkTouch += Time.deltaTime;
        Touch();
    }

    public void Touch()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; // UI 클릭이면 무시
        }
        //Input.GetMouseButtonDown(0)가 안에 있으면 의미가 없다.
        if (IsAttackTouch && Input.GetMouseButtonDown(0) && (LastAtkTouch > TouchAttackCoolDown))
        {
            enemyData.enemyHealth -= (playerData.attack + weaponData.baseDamage); // 보너스데미지 수정해서 바꿔야됩니다.
        }
    }


    public void AutoAttack()
    {
        if (AutoAttackCoroutine != null)
        {
            StopCoroutine(AutoAttackCoroutine);
        }

        AutoAttackCoroutine = StartCoroutine(AutoAttackRoutine());
    }
    IEnumerator AutoAttackRoutine()
    {
        while (true)
        {
            // 공격시 데미지 계산 추가
            float delay = GetAutoAttackDelay();
            yield return new WaitForSeconds(delay);
        }
    }
    float GetAutoAttackDelay()
    {
        return Mathf.Max(0.2f, 2.0f - 0.1f * AutoAttacklevel);
    }


    void AttackEnemy()
    {
        int damage = IsCriticalAtk(int.Parse("0.5")) ? playerData.attack * CriticalLevel  : playerData.attack;
        enemyData.enemyHealth -= (playerData.attack + weaponData.baseDamage) *damage;  // 보너스데미지 수정해서 바꿔야됩니다.
    }

    bool IsCriticalAtk(float criticPer)
    {
        float number = Random.value;
        //Random.Range(0, 100);
        return (number >= criticPer); //true false 에 따라처리
    }
    // 치명타 확률, 치명타배율
}

