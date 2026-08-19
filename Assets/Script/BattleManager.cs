using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Skill SetSkill;
    public Player player;
    public List<Enemy> Enemys = new List<Enemy>();

    public bool IsPlayerTurn = false;
    public bool IsTarget = false;
    public bool ExtraAction = false;


    // 전투 준비
    public void StartBattle()
    {
        StopAllCoroutines();

        IsPlayerTurn = false;
        IsTarget = false;

        Enemys.Clear();

        StartCoroutine(FindEnemy());
    }


    // 현재 씬의 몬스터 찾기
    private IEnumerator FindEnemy()
    {
        // Enemy의 Start가 실행될 시간
        yield return null;

        Enemy[] enemys = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        foreach (Enemy enemy in enemys)
        {
            Enemys.Add(enemy);
        }

        Debug.Log("전투 시작!");

        StartCoroutine(BattleRoutine());
    }


    // 전투 전체 진행
    private IEnumerator BattleRoutine()
    {
        while (true)
        {
            // 죽은 몬스터 리스트에서 제거
            Enemys.RemoveAll(enemy => enemy == null || enemy.IsDie);


            // 몬스터 전멸
            if (Enemys.Count == 0)
            {
                Debug.Log("승리!");
                yield break;
            }

            // 플레이어 사망
            if (player.IsDid)
            {
                Debug.Log("플레이어 사망");
                yield break;
            }

            // 1. 플레이어보다 빠른 몬스터
            foreach (Enemy enemy in Enemys)
            {
                if (enemy == null || enemy.IsDie)
                {
                    continue;
                }

                if (enemy.EnemySpeed > player.speed)
                {
                    yield return StartCoroutine(EnemyTurn(enemy));

                    if (player.IsDid)
                    {
                        Debug.Log("플레이어 사망");
                        yield break;
                    }
                }
            }


            // 2. 플레이어 턴
            yield return StartCoroutine(PlayerTurn());


            // 3. 플레이어보다 느리거나 같은 몬스터
            foreach (Enemy enemy in Enemys)
            {
                if (enemy == null || enemy.IsDie)
                {
                    continue;
                }

                if (enemy.EnemySpeed <= player.speed)
                {
                    yield return StartCoroutine(EnemyTurn(enemy));

                    if (player.IsDid)
                    {
                        Debug.Log("플레이어 사망");
                        yield break;
                    }
                }
            }
        }
    }


    // 플레이어 턴
    private IEnumerator PlayerTurn()
    {
        IsPlayerTurn = true;
        IsTarget = false;

        Debug.Log("플레이어 턴");


        // 플레이어가 행동할 때까지 기다림
        yield return new WaitUntil(() => IsPlayerTurn == false);

        yield return new WaitForSeconds(1f);
    }


    // 몬스터 클릭
    public void SelectEnemy(Enemy enemy)
    {
        if (!IsPlayerTurn)
        {
            return;
        }

        if (!IsTarget)
        {
            return;
        }

        if (enemy == null || enemy.IsDie)
        {
            return;
        }

        SetSkill.Use(enemy);


        EndPlayerTurn();
    }


    // 플레이어 턴 끝
    public void EndPlayerTurn()
    {
        IsTarget = false;
        SetSkill = null;

        // 두개의 심장 추가 행동
        if (ExtraAction)
        {
            ExtraAction = false;
            Debug.Log("한 번 더 행동 가능!");
            return;
        }

        IsPlayerTurn = false;
        player.TurnDown();
    }


    // 몬스터 턴
    private IEnumerator EnemyTurn(Enemy enemy)
    {
        if (enemy == null || enemy.IsDie)
        {
            yield break;
        }

        Debug.Log(enemy.Name + "의 턴");

        yield return new WaitForSeconds(1f);

        enemy.Attack(player);

        enemy.TurnDown();

        yield return new WaitForSeconds(1f);
    }

    public void SelectSkill(Skill sk)
    {
        if (IsTarget || !IsPlayerTurn)
        {
            return;
        }

        SetSkill = sk;
        IsTarget = true;

        Debug.Log(sk.SkillName + " 선택!");
        Debug.Log("공격할 몬스터를 선택하세요");
    }


    // 치트용 - 나중에 F6
    public void AllKillEnemy()
    {
        foreach (Enemy enemy in Enemys)
        {
            if (enemy != null && !enemy.IsDie)
            {
                enemy.Damage(999999);
            }
        }

        IsPlayerTurn = false;
        IsTarget = false;
    }
}