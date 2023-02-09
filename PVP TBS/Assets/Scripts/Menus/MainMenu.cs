using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class MainMenu : Menu<MainMenu>
{
    private TextMeshProUGUI _connectionText;
    private GameObject _colorButtons;
    private GameObject _hostButton;
    private GameObject _joinButton;
    private GameObject _helpButton;


    private void Start()
    {
        _connectionText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        _hostButton = transform.GetChild(1).gameObject;
        _joinButton = transform.GetChild(2).gameObject;
        _helpButton = transform.GetChild(3).gameObject;
        _colorButtons = transform.GetChild(4).gameObject;
    }

    public override void MenuOpen()
    {
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            _connectionText.text = "Connecting to server...Please Wait";
        }
        else
        {
            _connectionText.gameObject.SetActive(false);
            _hostButton.SetActive(true);
            _joinButton.SetActive(true);
            _helpButton.SetActive(true);
            _colorButtons.SetActive(true);
        }
    }

    public override void MenuClose()
    {
        base.MenuClose();
        _connectionText.gameObject.SetActive(false);
        _hostButton.SetActive(false);
        _joinButton.SetActive(false);
        _helpButton.SetActive(false);
        _colorButtons.SetActive(false);
    }

    public void UpdateConnectionStatus(bool status)
    {
        MenuOpen();
    }

    public void OnHostButtonPressed()
    {
        ServerController.Instance.CreateRoom();
    }

    public void OnJoinButtonPressed()
    {
        ServerController.Instance.JoinRoom();
    }

    public void OnHelpButtonPressed()
    {
        _helpButton.transform.GetChild(1).gameObject.SetActive(true);
        _helpButton.transform.GetChild(2).gameObject.SetActive(true);
        _joinButton.SetActive(false);
        _hostButton.SetActive(false);
    }

    public void OnHelpCloseButtonPressed()
    {
        _helpButton.transform.GetChild(1).gameObject.SetActive(false);
        _helpButton.transform.GetChild(2).gameObject.SetActive(false);
        _hostButton.SetActive(true);
        _joinButton.SetActive(true);
    }


}
