﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    EnemyData enemyData;
    public PlayerData playerData;
    public WeaponData weaponData;
    public Enemy enemy;
    public StatCalculator statCalculator;

    Camera cam;

    public int AutoAttacklevel = 1;// 자동공격
    public int CriticalLevel = 1;
    public float TouchAttackCoolDown = 0.2f;//터치 쿨다운
    public float LastAtkTouch;
    public bool IsAttackTouch = true;
    private float criticalValue;
    private float autoAtkValue;

    private Coroutine AutoAttackCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        criticalValue = GameManager.Instance.playerUpgradeHandler.GetCriticalValue();
        autoAtkValue = GameManager.Instance.playerUpgradeHandler.GetAutoAtkValue();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        AutoAttack();
    }

    // Update is called once per frame
    Vector3 mousePositionWorld;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("sss");
            Vector3 mousePositionScreen = Input.mousePosition;
            mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
            Touch();
        }
        LastAtkTouch += Time.deltaTime;
    }

    //public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam)
    //{
    //    Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
    //            Input.mousePosition.y, -Camera.main.transform.position.z)); 
    //}

    public void Touch()
    {
        Debug.Log("do");
        //input.getmousebuttondown(0)가 안에 있으면 의미가 없다.
        if (IsAttackTouch && (LastAtkTouch > TouchAttackCoolDown))
        {
            float MinY = -0.2f;
            float MaxY = 2.6f;

            Vector3 mousePos = mousePositionWorld;
            Debug.Log($"{MinY}  {MaxY}  {mousePos}");
            if (mousePos.y >= MinY && mousePos.y <= MaxY)
            {
                Debug.Log("ooo");
                TotalAtk();
                LastAtkTouch = Time.time;
            }
        }
    }

    public void SetEnemy(Enemy enemy)
    {
        this.enemy = enemy;
    }


    public void TotalAtk()
    {
        if (enemy != null)
        {
            if (criticalValue > 0)
            {
                int addDmg = (int)((criticalValue / 100) * statCalculator.GetTotalDamage());
                enemy.TakeDamage(statCalculator.GetTotalDamage() + addDmg);
                Debug.Log($"addDmg = {addDmg}");

            }
            else
            {
                enemy.TakeDamage(statCalculator.GetTotalDamage());
            }

        }

    }
    //null 예외처리
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
        while (true)//pupghandler 정보 갖고와서 lvl 0보다 클때만 호출
        {
            if (autoAtkValue > 0)
            {
                TotalAtk();

            }
            // 공격시 데미지 계산 추가
            float delay = GetAutoAttackDelay();
            yield return new WaitForSeconds(delay);
        }
    }

    //자동공격 딜레이
    float GetAutoAttackDelay()
    {
        if (autoAtkValue > 0)
        {
            return 1 / autoAtkValue;
        }
        else
        {
            return 0.1f;
        }
        //return Mathf.Max(0.2f, 2.0f - 0.05f * autoAtkValue);
    }

    public void SetCriticalStat(float value)
    {
        criticalValue = value;
    }
    public void SetAutoAtkStat(float value)
    {
        autoAtkValue = value;
    }
}

