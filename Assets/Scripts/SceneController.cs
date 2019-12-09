using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SceneController : MonoBehaviour {

    private BallController ball1, ball2;
    private float time;

    public void Awake() {
        ball1 = GameObject.FindGameObjectsWithTag("FirstBall")[0].GetComponent<BallController>();
        ball2 = GameObject.FindGameObjectsWithTag("SecondBall")[0].GetComponent<BallController>();
        string[] data = File.ReadAllLines("input.txt");
        time = float.Parse(data[0]);
        string[] pos1 = data[1].Split(' ');
        string[] pos2 = data[2].Split(' ');
        string[] vel1 = data[3].Split(' ');
        string[] vel2 = data[4].Split(' ');
        setFirstPosition(new Vector3(float.Parse(pos1[0]), float.Parse(pos1[1]), float.Parse(pos1[2])));
        setSecondPosition(new Vector3(float.Parse(pos2[0]), float.Parse(pos2[1]), float.Parse(pos2[2])));
        ball1.setVelocity(new Vector3(float.Parse(vel1[0]), float.Parse(vel1[1]), float.Parse(vel1[2])));
        ball2.setVelocity(new Vector3(float.Parse(vel2[0]), float.Parse(vel2[1]), float.Parse(vel2[2])));
    }

    public void Pause() {
        ball1.Pause();
        ball2.Pause();
    }

    public void Resume() {
        ball1.Resume();
        ball2.Resume();
    }

    public void setAnswer() {
        Debug.Log("First ball position: " + ball1.transform.position);
        Debug.Log("Second ball posistion: " + ball2.transform.position);
        File.WriteAllLines("output.txt", new List<string> { 
            ball1.transform.position.x.ToString().Replace(",", "."),
            ball1.transform.position.y.ToString().Replace(",", "."),
            ball1.transform.position.z.ToString().Replace(",", "."),
            ball2.transform.position.x.ToString().Replace(",", "."),
            ball2.transform.position.y.ToString().Replace(",", "."),
            ball2.transform.position.z.ToString().Replace(",", "."),
        });
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }

    public Vector3 getFirstBallVelocity() {
        return ball1.getVelocity();
    }

    public Vector3 getSecondBallVelocity() {
        return ball2.getVelocity();
    }

    public Vector3 getFirstBallPosition() {
        return ball1.transform.position;
    }

    public Vector3 getSecondBallPosition() {
        return ball2.transform.position;
    }

    public void setFirstPosition(Vector3 pos) {
        ball1.transform.position = pos;
    }

    public void setSecondPosition(Vector3 pos) {
        ball2.transform.position = pos;
    }
    public float getTime() {
        return time;
    }
}
