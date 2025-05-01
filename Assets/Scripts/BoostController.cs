using System.Collections;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    private float normalSpeed;
    private float boostSpeed;
    private Coroutine _currentBoost;

    private void Start()
    {
        normalSpeed = Player.Instance.speed;
        boostSpeed = Player.Instance.speed * 2;
    }

    public void Boost()
    {
        if (_currentBoost != null)
            StopCoroutine(_currentBoost);
        
        Player.Instance.speed = boostSpeed;
        _currentBoost = StartCoroutine(ResetSpeed(3f));
    }

    private IEnumerator ResetSpeed(float delay)
    {
        yield return new WaitForSeconds(delay);
        Player.Instance.speed = normalSpeed;
    }
}