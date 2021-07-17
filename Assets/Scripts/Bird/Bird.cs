using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover mover;
    private int score;

    public event UnityAction GameOver;

    private void Start()
    {
        mover = GetComponent<BirdMover>();
    }

    public void IncreaseScore() => score++;

    public void RestartGame()
    {
        score = 0;
        mover.RestartBird();
    }

    public void Die() => GameOver?.Invoke();
}