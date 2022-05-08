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
        private Rigidbody rig;

        
        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
        }


        private void Update()
        {
            GetJoystickValue();

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
            rig.velocity = new Vector3(-joystick.Horizontal, 0, 0)*speed;
        }
    }


}