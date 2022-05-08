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
        [SerializeField, Header("�����V�ϥ�")]
        private Transform traDirectionIcon;      
        private float rangeDirectionIcon = 2.5f;
        [SerializeField, Header("�������t��"), Range(0, 100)]
  
        private float speedTurn = 1.5f;

        private Rigidbody rig;

        
        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
        }


        private void Update()
        {
            GetJoystickValue();
            UpdateDirectionIconPos();
            LookDirectionIcon();

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
            rig.velocity = new Vector3(-joystick.Horizontal, 0, -joystick.Horizontal) *speed;


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
            //���⪺�کԨ��� = �T���V�q(0,�쥻���کԨ���

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }


    }



}