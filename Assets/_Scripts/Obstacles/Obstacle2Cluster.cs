using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Position
{
    public float yMin;
    public float yMax;
}

public class Obstacle2Cluster : MonoBehaviour {

    public Position position;

    public GameObject Left;
    public GameObject Rigth;

    void Start ()
    {
        VerticalSpawn();
        RandomSide();
    }

    void VerticalSpawn()
    {
        var posLeft = Left.gameObject.transform.position;
        var posRigth = Rigth.gameObject.transform.position;

        posLeft.x = GameController.screenLeft;
        posRigth.x = GameController.screenRight;

        posLeft.y = Random.Range(position.yMin, position.yMax);
        posRigth.y = Random.Range(position.yMin, position.yMax);

        Left.gameObject.transform.position += posLeft;
        Rigth.gameObject.transform.position += posRigth;
    }

    void RandomSide()
    {
        int side = Random.Range(0, 2);

        var getLeft = Left.gameObject.GetComponent<Obstacle2>();
        var getRigth = Rigth.gameObject.GetComponent<Obstacle2>();
        
        if (side == 0) {
            getLeft.reverse = true;
        } else {
            getRigth.reverse = true;
        }
    }
}
