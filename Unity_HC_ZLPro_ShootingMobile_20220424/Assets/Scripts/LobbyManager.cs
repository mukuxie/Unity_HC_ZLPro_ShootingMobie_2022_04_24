using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;       // �ޥ� Photon Pun API
using Photon.Realtime;  // �ޥ� Photon �Y�� API

/// <summary>
/// �j�U�޲z��
/// ���a���U��ԫ��s��}�l�ǰt�ж�
/// </summary>
// MonoBehaviourPunCallbacks �s�u�\��^�I���O
// �Ҧp�G�n�J�j�U��^�I�A���w���{��
public class LobbyManager : MonoBehaviourPunCallbacks
{
    // GameObject �C������G�s�� Unity �������Ҧ�����
    // SerializeField �N�p�H�����ܦb�ݩʭ��O�W
    // Heder ���D�A�b�ݩʭ��O�W��ܲ���r���D
    [SerializeField, Header("�s�u���e��")]
    private GameObject goConnectView;
    [SerializeField, Header("��ԫ��s")]
    private Button btnBattle;
    [SerializeField, Header("�s�u�H��")]
    private Text textCountPlayer;

    // ����ƥ�G����C���ɰ���@���A��l�Ƴ]�w
    private void Awake()
    {
        // Photon �s�u �� �s�u�ϥγ]�w
        PhotonNetwork.ConnectUsingSettings();
    }

    // override ���\�Ƽg�~�Ӫ������O����
    // �s�u�ܱ���x�A�b ConnectUsingSettings �����|�۰ʳs�u
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print("<color=yellow>1. �w�g�i�J����x</color>");

        // Photon �s�u.�[�J�j�U
        PhotonNetwork.JoinLobby();
    }

    // �s�u�ܤj�U���\��|���榹��k
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("<color=yellow>2. �w�g�i�J�j�U</color>");

        // ��ԫ��s.���� = �Ұ�
        btnBattle.interactable = true;
    }

    // ���ѡG����
    // �����s��{�����q���y�{
    // 1. ���Ѥ��}����k Public Method
    // 2. ���s�b�I�� On Click ��]�w�I�s����k

    // �}�l�s�u���
    public void StartConnect()
    {
        print("<color=yellow>3. �}�l�s�u</color>");

        // �C������.�Ұʳ]�w�]���L�ȡ^- true ��ܡAfalse ����
        goConnectView.SetActive(true);

        // Photon �s�u �� �[�J�H���ж�
        PhotonNetwork.JoinRandomRoom();
    }

    // �[�J�H���ж�����
    // 1. �s�u�~��t�ɭP����
    // 2. �٨S���ж�
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        print("<color=red>4. �[�J�H���ж�����</color>");

        RoomOptions ro = new RoomOptions();     // �s�W�ж��]�w����
        ro.MaxPlayers = 5;                      // ���w�ж��̤j�H��
        PhotonNetwork.CreateRoom("", ro);       // �إߩж��õ����ж�����
    }

    // �[�J�ж�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("<color=yellow>5. �}�Ъ̶i�J�ж�</color>");
        int currentCount = PhotonNetwork.CurrentRoom.PlayerCount;   // ���e�ж��H��
        int maxCount = PhotonNetwork.CurrentRoom.MaxPlayers;        // ���e�ж��̤j�H��

        textCountPlayer.text = "�s�u�H�� " + currentCount + " / " + maxCount;
    }

    // ��L���a�i�J�ж�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print("<color=yellow>6. ���a�i�J�ж�</color>");
        int currentCount = PhotonNetwork.CurrentRoom.PlayerCount;   // ���e�ж��H��
        int maxCount = PhotonNetwork.CurrentRoom.MaxPlayers;        // ���e�ж��̤j�H��

        textCountPlayer.text = "�s�u�H�� " + currentCount + " / " + maxCount;
    }
}