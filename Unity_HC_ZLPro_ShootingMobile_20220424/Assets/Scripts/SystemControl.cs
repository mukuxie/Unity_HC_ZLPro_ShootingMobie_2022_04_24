using UnityEngine;

namespace Ken
{ 
    /// <summary>
    /// 控制系統 : 荒野亂鬥
    /// 虛擬搖桿控制角色移動
    /// </summary>
public class SystemControl : MonoBehaviour
{
        [SerializeField, Header("虛擬搖桿")]
        private Joystick joystick ;
        [SerializeField, Header("移動速度"),Range(0,300)]
        private float speed = 3.5f;
        [SerializeField, Header("角色方向圖示")]
        private Transform traDirectionIcon;
        [SerializeField, Header("角色方向圖示範圍"),Range(0,5)]
        private float rangeDirectionIcon = 2.5f;
        [SerializeField, Header("角色旋轉速度"), Range(0, 100)]
        private float speedTurn = 1.5f;

        [SerializeField, Header("動畫參數跑步")]
        private string praameterWalk = "開關跑步";

        private Rigidbody rig;
        private Animator ani;

        
        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
            ani = GetComponent<Animator>();
        }


        private void Update()
        {
            //GetJoystickValue();
            UpdateDirectionIconPos();
            LookDirectionIcon();
            UpdateAnimation();
            


        }

        private void FixedUpdate()
        {
            Move();
        }

        private void GetJoystickValue()
        {
            print("<color=yellow>水平:" + joystick.Horizontal + "</color>");
            
        }

        private void Move()
        {
            rig.velocity = new Vector3(-joystick.Horizontal, 0, joystick.Horizontal) *speed;
            rig.velocity = new Vector3(joystick.Vertical, 0, -joystick.Vertical) * speed;


        }

        private void UpdateDirectionIconPos()
        {
            Vector3 pos = transform.position + new Vector3(-joystick.Horizontal, 0.5f, -joystick.Vertical) * rangeDirectionIcon;
            traDirectionIcon.position = pos;
        }

        private void LookDirectionIcon()
        {
            Quaternion look = Quaternion.LookRotation(traDirectionIcon.position - transform.position);           
            transform.rotation = Quaternion.Lerp(transform.rotation, look, speedTurn * Time.deltaTime);
            //角色的歐拉角度 = 三維向量(0,原本的歐拉角度

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        private void UpdateAnimation()
        {
            bool run = joystick.Horizontal != 0 || joystick.Vertical != 0;
            ani.SetBool(praameterWalk, run);
        }


    }



}