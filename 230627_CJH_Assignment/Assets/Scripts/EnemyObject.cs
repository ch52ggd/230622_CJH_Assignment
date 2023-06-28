using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyObject : MonoBehaviour{
    [SerializeField] private Sprite[] enemyImg;
    [SerializeField] private Slider hpbar;

    Enemy enemy = null;

    public void SetEnemy(Enemy e)
    {
        this.enemy = e;
        this.hpbar.maxValue = enemy.Hp;
        this.hpbar.value = enemy.Hp;
    }


    private void Start()
    {
       // SetEnemy(new Enemy(Enemy.EnemyType.Basic, 100, 10, 3.0f));
    }




    private void Update()
    {
        if (enemy == null) return;
        MoveEnemy();

        //아래로 내려가면 파괴
        if(this.transform.position.y < -5)
        {
            this.hpbar.value -= 0.05f; //HP 줄어들기

            if(this.transform.position.y < -10)
            {
                Destroy(this.gameObject); //파괴
            }
        }

        //HP 다 줄어들면 파괴
        if (this.hpbar.value <= 0)
        {
            Destroy(this.gameObject); //파괴
        }
    }


    private void MoveEnemy()
    {

        if (this.transform.position.y <= -10) return;

        this.transform.position -= new Vector3(0, enemy.Speed * Time.deltaTime, 0);
    }





}
