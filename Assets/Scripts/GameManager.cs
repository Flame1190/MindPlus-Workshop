using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Main;

    bool _gameStarted;

    int _score;
    public TMP_Text ScoreText;
    public TMP_Text TimerText;

    public GameObject TargetTemplate;
    public List<GameObject> Targets = new List<GameObject>();

    private void Awake()
    {
        Main = this;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (!_gameStarted)
            {
                StartGame();
            }
            else EndGame();
        }
    }

    public void StartGame()
    {
        _gameStarted = true;

        _score = 0;
        AddScore(0);

        for (int i = 0; i < 7; i++)
        {
            SpawnTarget();
        }

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        int timer = 30;

        while (timer > 0)
        {
            timer--;

            yield return new WaitForSeconds(1);

            TimerText.text = "Timer: " + timer;
        }

        EndGame();
    }

    void EndGame()
    {
        _gameStarted = false;

        StopAllCoroutines();

        foreach (GameObject target in Targets)
        {
            Destroy(target);
        }
        Targets.Clear();
    }

    public void SpawnTarget()
    {
        Vector2 position2D = Random.insideUnitCircle.normalized * Random.Range(3,12);
        Vector3 floorOffset = new Vector3(0, TargetTemplate.transform.position.y, 0);

        RaycastHit hit;
        Physics.Raycast(new Vector3(position2D.x, 10, position2D.y), Vector3.down, out hit, Mathf.Infinity);

        GameObject target = Instantiate(TargetTemplate, hit.point + floorOffset, Quaternion.identity);
        target.SetActive(true);

        Targets.Add(target);
    }

    public void AddScore(int addition = 1)
    {
        _score += addition;
        ScoreText.text = "Score: " + _score;
    }
}
