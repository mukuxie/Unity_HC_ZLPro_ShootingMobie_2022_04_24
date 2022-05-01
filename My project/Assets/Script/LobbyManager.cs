using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    [SerializeField, Header("連線中畫面")]
    private GameObject goConnectView;
    [SerializeField, Header("對戰按鈕")]
    private Button btnBattle;
    [SerializeField, Header("連線人數")]
    private Text textCountPlayer;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() // override 允許複寫的副類別
    {
        base.OnConnectedToMaster(); // 連線至控制台
        print("<color=yellow>已經進入控制台</color>");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("<color=yellow>已經進入大廳</color>");

        btnBattle.interactable = true;
    }


    public void StartConnect()
    {
        print("<color=yellow> 開始連線</color>");

        goConnectView.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        print("<color=red> 加入隨機房間失敗</color>");
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 5;
        PhotonNetwork.CreateRoom("", ro);
        
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("<color=yellow> 開房者進入房間</color>");
        int currentCount = PhotonNetwork.CurrentRoom.PlayerCount;
        int maxCount = PhotonNetwork.CurrentRoom.MaxPlayers;

        textCountPlayer.text = "連線人數" + currentCount + " / " + maxCount;
    
   }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print("<color=yellow> 玩家進入房間</color>");
        int currentCount = PhotonNetwork.CurrentRoom.PlayerCount;
        int maxCount = PhotonNetwork.CurrentRoom.MaxPlayers;

        textCountPlayer.text = "連線人數" + currentCount + " / " + maxCount;
    }


}
