using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class SquareView : MonoBehaviour
{
    private static SquareView _instance;

    public static SquareView Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private SquareController _controller;
    [SerializeField]
    private GameObject _square;

    public Color _color { get; private set; }
    public string _name { get; private set; }
    public Vector3 _scale { get; private set; }

    private void Start()
    {
        _controller = new SquareController();
        _controller.Init(this);
    }

    public void ShowPlayerTurn(string _turn)
    {
        GameMenu.Instance.ShowPlayerTurn(_turn);
    }

    public void OnRedButtonPressed()
    {
        _controller.PlayerColor = new Color(217, 56, 56, 255);
    }

    public void OnBlueButtonPressed()
    {
        _controller.PlayerColor = new Color(56, 56, 217, 255);
    }

    public void OnGreenButtonPressed()
    {
        _controller.PlayerColor = new Color(56, 217, 56, 255);
    }

    public void CreatePlayer()
    {
        _color = _controller.PlayerColor;
        _scale = _controller.PlayerScale;
        _name = _controller.PlayerName;
    }
}
