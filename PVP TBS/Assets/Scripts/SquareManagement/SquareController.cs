using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController 
{
    private SquareView _view;
    private SquareModel _squareData;

    public void Init(SquareView view)
    { 
        _view = view;
        _squareData = new SquareModel();
    }

    public string PlayerName
    {
        get {return _squareData.PlayerName; }
        set { _squareData.PlayerName = value; }
    }
    public Color PlayerColor
    {
        get { return _squareData.Color; }
        set { _squareData.Color = value / 100; }
    }

    public Color PlayerShape
    {
        get { return _squareData.Color; }
        set { _squareData.Color = value / 100; }
    }

    public Vector3 PlayerScale
    {
        get { return _squareData.Scale; }
        set { _squareData.Scale = value; }
    }


}
