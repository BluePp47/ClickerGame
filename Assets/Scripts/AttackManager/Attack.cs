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
    public Enemy enemy;
    public StatCalculator statCalculator;

    public int AutoAttacklevel = 1;// 자동공격
    public int CriticalLevel = 1;
    public float TouchAttackCoolDown = 0.2f;//터치 쿨다운
    public float LastAtkTouch;
    public bool IsAttackTouch = true;

    private Coroutine AutoAttackCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        AutoAttack();
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
            TotalAtk();
        }
    }

    public void FindEnemy()
    {
        if (enemy == null)
        {
            enemy = enemy.GetComponent<Enemy>();
        }
    }


    public void TotalAtk()
    {
        enemy.TakeDamage(statCalculator.GetTotalDamage());
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
            TotalAtk();
            float delay = GetAutoAttackDelay();
            yield return new WaitForSeconds(delay);
        }
    }

    //자동공격 딜레이
    float GetAutoAttackDelay()
    {
        return Mathf.Max(0.2f, 2.0f - 0.05f * AutoAttacklevel);
    }
}

