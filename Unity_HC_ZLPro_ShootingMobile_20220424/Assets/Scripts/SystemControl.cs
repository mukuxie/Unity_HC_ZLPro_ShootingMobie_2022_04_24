using UnityEngine;

namespace Ken
{ 
    /// <summary>
    /// ����t�� : ��ð�
    /// �����n�챱��Ⲿ��
    /// </summary>
public class SystemControl : MonoBehaviour
{
        [SerializeField, Header("�����n��")]
        private Joystick joystick ;
        [SerializeField, Header("���ʳt��"),Range(0,300)]
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
            print("<color=yellow>����:" + joystick.Horizontal + "</color>");
            
        }

        private void Move()
        {
            rig.velocity = new Vector3(-joystick.Horizontal, 0, 0)*speed;
        }
    }


}