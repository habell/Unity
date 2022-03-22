using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    private float Timer = 0.5f;
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = 0.5f;
            var v = GameObject.FindGameObjectsWithTag("Enemy");
            gameObject.GetComponent<Text>().text = v.Length.ToString();
            if (v.Length <= 0)
            {
                Application.Quit();
                print("���� ��������!");
            }
        }
    }
}