using UnityEngine;
using UnityEngine.UI;

public class SyStemAttack : MonoBehaviour
{
    [SerializeField, Header("�o�g���s")]
    private Button btnFire;
    [SerializeField, Header("�l�u")]
    private GameObject goBullet;
    [SerializeField, Header("�l�u�̤j�ƶq")]
    private int bullectContMax = 3;
    [SerializeField, Header("�l�u�ͦ���m")]
    private Transform traFire;
    [SerializeField, Header("�l�u�o�g�t��"),Range(0,3000)]
    private int speedFire = 500;

    private int bullectCountCurrent;


}
