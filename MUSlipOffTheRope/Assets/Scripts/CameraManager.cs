using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject prefabPlayer;

    void FollowCam()
    {
        gameObject.transform.position = new Vector3(0, prefabPlayer.transform.position.y + 3.5f, 10f);
    }

    private void LateUpdate()
    {
        FollowCam();
    }

}
