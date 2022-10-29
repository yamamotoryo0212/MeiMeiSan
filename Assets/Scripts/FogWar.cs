using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogWar : MonoBehaviour
{
    [SerializeField]
    private Texture2D _transparentTexture = null;
    [SerializeField]
    private SpriteMask _spriteMask = null;

    private Vector2 _worldScale = Vector2.zero;
    private Vector2Int _pixelScale = Vector2Int.zero;

    private void Awake()
    {
        _pixelScale.x = _transparentTexture.width;
        _pixelScale.y = _transparentTexture.height;

        _worldScale.x = _pixelScale.x / 100.0f * transform.localScale.x;
        _worldScale.y = _pixelScale.y / 100.0f * transform.localScale.y;

        for (int i = 0; i < _pixelScale.x; i++)
        {
            for (int j = 0; j < _pixelScale.y; j++)
            {
                _transparentTexture.SetPixel(i, j, Color.clear);
            }
        }
    }

    private Vector2Int WorldToPixel(Vector2 position)
    {
        Vector2Int pixelPosition = Vector2Int.zero;

        float x = position.x - transform.position.x;
        float y = position.y - transform.position.y;

        pixelPosition.x = Mathf.RoundToInt(0.5f * _pixelScale.x + x * (_pixelScale.x / _worldScale.x));
        pixelPosition.y = Mathf.RoundToInt(0.5f * _pixelScale.y + y * (_pixelScale.y / _worldScale.y));

        return pixelPosition;
    }

    private void CreateSprite()
    {
        _spriteMask.sprite = Sprite.Create(_transparentTexture, new Rect(0, 0, _transparentTexture.width, _transparentTexture.height), Vector2.one * 0.5f, 100);
    }

    public void MakeHole(Vector2 position, float holeRadius)
    {
        Vector2Int pixelPosition = WorldToPixel(position);
        int radius = Mathf.RoundToInt(holeRadius * _pixelScale.x / _worldScale.x);
        int px, nx, py, ny, distance;

        for (int i = 0; i < radius; i++)
        {
            distance = Mathf.RoundToInt(Mathf.Sqrt(radius * radius - i * i));
            for (int j = 0; j < distance; j++)
            {
                px = Mathf.Clamp(pixelPosition.x + i, 0, _pixelScale.x);
                nx = Mathf.Clamp(pixelPosition.x - i, 0, _pixelScale.x);
                py = Mathf.Clamp(pixelPosition.y + j, 0, _pixelScale.y);
                ny = Mathf.Clamp(pixelPosition.y - j, 0, _pixelScale.y);

                _transparentTexture.SetPixel(px, py, Color.black);
                _transparentTexture.SetPixel(nx, py, Color.black);
                _transparentTexture.SetPixel(px, ny, Color.black);
                _transparentTexture.SetPixel(nx, ny, Color.black);
            }
        }

        _transparentTexture.Apply();
        CreateSprite();
    }
}
