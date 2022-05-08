
using UnityEngine;
namespace KEN
{ 
public class PlayerUIFOLLOW : MonoBehaviour
{

        [SerializeField, Header("¦ì²¾")]
        private Vector3 v30ffset;
        public string namePlayer = "¾Ô¤h";
        private Transform traPlayer;

        private void Awake()
        {
            traPlayer = GameObject.Find(namePlayer).transform;
        }

        private void Update()
        {
            Follow();
        }

        private void Follow()
        {
            transform.position = traPlayer.position + v30ffset;
        }
    }
}