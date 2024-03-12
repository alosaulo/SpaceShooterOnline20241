using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : NetworkBehaviour
{
    [SyncVar(hook = nameof(SetColor))]
    Color playerColor = Color.white;

    public override void OnStartServer()
    {
        base.OnStartServer();
        playerColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); ;
    }

    void SetColor(Color oldColor, Color newColor)
    {
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }
}
