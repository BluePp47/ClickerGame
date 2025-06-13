using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour
{
    public EnemyData enemyData;
    public PlayerData playerData;
    public WeaponData weaponData;





    public int AutoAttacklevel = 0;// 자동공격

    public float TouchAttackCoolDown = 0.2f;//터치 쿨다운
    public float LastAtkTouch;
    public bool IsAttackTouch = true;

    private Coroutine AutoAttackCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LastAtkTouch += Time.deltaTime;
        Touch();
    }

    public void Touch()
    {
        //Input.GetMouseButtonDown(0)가 안에 있으면 의미가 없다.
        if (IsAttackTouch && Input.GetMouseButtonDown(0) && (LastAtkTouch > TouchAttackCoolDown))
        {
            enemyData.enemyHealth -= (playerData.attack + weaponData.bonusDamage);
            LastAtkTouch = 0;
        }
    }
}
