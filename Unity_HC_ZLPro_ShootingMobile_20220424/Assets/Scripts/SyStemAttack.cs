using UnityEngine;
using UnityEngine.UI;

public class SyStemAttack : MonoBehaviour
{
    [SerializeField, Header("發射按鈕")]
    private Button btnFire;
    [SerializeField, Header("子彈")]
    private GameObject goBullet;
    [SerializeField, Header("子彈最大數量")]
    private int bullectContMax = 3;
    [SerializeField, Header("子彈生成位置")]
    private Transform traFire;
    [SerializeField, Header("子彈發射速度"),Range(0,3000)]
    private int speedFire = 500;

    private int bullectCountCurrent;


}
