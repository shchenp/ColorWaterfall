using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public void StartChangeColor(Color color, float colorizingTime)
    {
        StartCoroutine(ChangeColor(color, colorizingTime));
    }
    
    private IEnumerator ChangeColor(Color color, float colorizingTime)
    {
        var currentTime = 0f;
        var currentColor = _renderer.material.color;

        while (currentTime < colorizingTime)
        {
            _renderer.material.color = Color.Lerp(currentColor, color, currentTime / colorizingTime);
            currentTime += Time.deltaTime;
            
            yield return null;
        }

    }
}
