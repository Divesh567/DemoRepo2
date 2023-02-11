using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView _photonView;
    private bool _isMoving;
    private Vector3 _currentPos;
    private Vector3 _targetPos;
    [SerializeField]
    private float _moveSpeed = 0.05f;
    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (!myGameManager.StartGame) // Check if game has started
        {
            return;
        }
        if (!PhotonNetwork.IsMasterClient && _photonView.IsMine) // check if its your turn
        {
            return;
        }
        if (_isMoving) //Check if input has been provided and player is moving
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.W)) // if it is your turn and player is not moving wait for input and move
        {
            StartCoroutine(MovePlayer(Vector3.forward));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
   
    }

    IEnumerator MovePlayer(Vector3 _movePos)
    {
        _isMoving = true;
        float elaspedTime = 0f;
        _currentPos = transform.position;
        _targetPos = _currentPos + _movePos;
        while (elaspedTime < _moveSpeed)
        {
            transform.position = Vector3.Lerp(_currentPos, _targetPos, elaspedTime / _moveSpeed);
            elaspedTime += Time.deltaTime;
        }
        transform.position = _targetPos;
        _isMoving = false;
        yield return null;
        SwitchMasterClient();
    }

    public void SwitchMasterClient()
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.MasterClient.GetNext());
        GameMenu.Instance.UpdatePlayerTurnChange();
    }
}
