using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Trying to connect....");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined a Room");

        // if(!photonView.IsMine)
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
    }

    // public override void OnPlayerEnteredRoom(Player newPlayer)
    // {
    //     base.OnPlayerEnteredRoom(newPlayer);
    //     Debug.Log("a new player joined");
    // }
}
