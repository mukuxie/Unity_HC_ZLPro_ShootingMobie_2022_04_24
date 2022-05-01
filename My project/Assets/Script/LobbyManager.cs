using UnityEngine;
using Photon.Pun;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    [SerializeField, Header("連線中畫面")]
    private GameObject goConnectView;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() // override 允許複寫的副類別
    {
        base.OnConnectedToMaster(); // 連線至控制台
        print("以連線至控制台");
    }



    public void StartConnect()
    {
        print("開始連線...");

        goConnectView.SetActive(true);
    }
}
