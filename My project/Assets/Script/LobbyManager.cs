using UnityEngine;
using Photon.Pun;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    [SerializeField, Header("�s�u���e��")]
    private GameObject goConnectView;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() // override ���\�Ƽg�������O
    {
        base.OnConnectedToMaster(); // �s�u�ܱ���x
        print("�H�s�u�ܱ���x");
    }



    public void StartConnect()
    {
        print("�}�l�s�u...");

        goConnectView.SetActive(true);
    }
}
