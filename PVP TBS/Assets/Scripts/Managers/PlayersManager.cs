using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayersManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    void Start()
    {
        SquareView.Instance.CreatePlayer();
        Color _playerColor = SquareView.Instance._color;
        Debug.Log(_playerColor);
        var _player =  PhotonNetwork.Instantiate(_playerPrefab.name, transform.position, Quaternion.identity);
        _player.transform.GetChild(0).GetComponent<Renderer>().material.color = _playerColor;
        
    }

}
