using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlingShot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform centerPos;
    public Transform IdlePos;

    public float throwForce = 3f;

    bool MousePressed = false;
    public static bool BirdReleased = false;
    Vector3 currentPos;
    public float offset;
    public GameObject[] BirdPrefabs;
    Rigidbody2D Bird;
    Collider2D BirdCollider;

    private int birdsLaunched = 0; 
    private int maxBirds = 5;

    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        SpawnNewBird();
    }

    // Update is called once per frame
    void Update()
    {
        if(MousePressed) 
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            currentPos = mousePos =Camera.main.ScreenToWorldPoint(mousePos);

            SetPos(currentPos);


            if (BirdCollider)
            {
                BirdCollider.enabled = true;
            }
        }
        else
        {
            ResetPosition();
        }
    }
    private void OnMouseDown()
    {
        MousePressed = true;
    }
    private void OnMouseUp()
    {
        MousePressed = false;
        BirdReleased = true;
        Shoot();
    }
    void ResetPosition()
    {
        currentPos = IdlePos.position;
        SetPos(currentPos);
    }
    void SetPos(Vector3 Position)
    {
        lineRenderers[0].SetPosition(1, Position);
        lineRenderers[1].SetPosition(1, Position);
        if (Bird)
        {
            Vector3 dir = Position - centerPos.position;
            Bird.transform.position = Position + dir.normalized*offset;
            Bird.transform.right = -dir.normalized;
        }
    }
    void Shoot()
    {
        if (Bird != null)
        {
            manager.DecreaseBirdText();

            Bird.isKinematic = false;
            Vector3 birdForce = (currentPos - centerPos.position) * throwForce * -1;
            Bird.velocity = birdForce;

            birdsLaunched++;
            Bird = null;
            BirdCollider = null;
            if (birdsLaunched < maxBirds)
            {
                Invoke(nameof(SpawnNewBird), 2);
            }
        }
    }
    void SpawnNewBird()
    {
        if (birdsLaunched < maxBirds)
        {
            int randomIndex = Random.Range(0, BirdPrefabs.Length);
            GameObject selectedBirdPrefab = BirdPrefabs[randomIndex];

            Bird = Instantiate(selectedBirdPrefab).GetComponent<Rigidbody2D>();
            BirdCollider = Bird.GetComponent<Collider2D>();
            BirdCollider.enabled = false;
            Bird.isKinematic = true;

            ResetPosition();
        }
    }
}
