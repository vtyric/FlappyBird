using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover mover;
    private int score;

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

    public void Die()
    {
        Debug.Log("DIE");
        Time.timeScale = 0;
    }
}