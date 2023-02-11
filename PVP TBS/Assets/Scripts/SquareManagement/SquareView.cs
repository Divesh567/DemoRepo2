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

    public Color _color;
    public string _name;
    public Vector3 _scale;

    private void Start()
    {
        _controller = new SquareController(); // creates Controller of square and has acess to it by _controlller
        _controller.Init(); 
    }
    public void OnRedButtonPressed() 
    {
        _controller.PlayerColor = new Color(217, 56, 56, 255); //updates model "Square" through controller
    }
    public void OnBlueButtonPressed()
    {
        _controller.PlayerColor = new Color(56, 56, 217, 255);
    }
    public void OnGreenButtonPressed()
    {
        _controller.PlayerColor = new Color(56, 217, 56, 255);
    }

    public void OnPlayerNameChanged(string name)
    {
        _controller.PlayerName = name;
    }
    public void CreatePlayer() // provides details of square from model/Controller
    {
        _color = _controller.PlayerColor;
        _scale = _controller.PlayerScale;
        _name = _controller.PlayerName;
    }
}
