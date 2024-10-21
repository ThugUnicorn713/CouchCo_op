using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public float minZoom = 5f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    public Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        Vector3 middlePoint = (player1.transform.position + player2.transform.position) / 2;
        transform.position = new Vector3(middlePoint.x, middlePoint.y, transform.position.z);

        float distance = Vector3.Distance(player1.transform.position, player2.transform.position);
        float newZoom = Mathf.Lerp(maxZoom, minZoom, distance / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);

        ClampPlayerInScreen();
    }

    void ClampPlayerInScreen()
    {
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        // Clamp Player 1
        Vector3 player1Pos = player1.transform.position;
        player1Pos.x = Mathf.Clamp(player1Pos.x, transform.position.x - halfWidth, transform.position.x + halfWidth);
        player1Pos.y = Mathf.Clamp(player1Pos.y, transform.position.y - halfHeight, transform.position.y + halfHeight);
        player1.transform.position = player1Pos;

        // Clamp Player 2
        Vector3 player2Pos = player2.transform.position;
        player2Pos.x = Mathf.Clamp(player2Pos.x, transform.position.x - halfWidth, transform.position.x + halfWidth);
        player2Pos.y = Mathf.Clamp(player2Pos.y, transform.position.y - halfHeight, transform.position.y + halfHeight);
        player2.transform.position = player2Pos;
    }

}
