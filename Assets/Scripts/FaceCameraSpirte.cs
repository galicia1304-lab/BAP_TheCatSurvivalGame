using UnityEngine;

public class FaceCameraSpirte : MonoBehaviour
{
    //late update is fram update after default update (this might lighten the load of framebyframe)
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }
}
