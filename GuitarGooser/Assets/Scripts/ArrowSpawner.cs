using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public enum ArrowDirection
    {
        Left,
        Down,
        Up,
        Right
    }

    public float bpm = 120f;
    public float startDelay = 0f;

    public Transform leftSpawnPoint;
    public Transform downSpawnPoint;
    public Transform upSpawnPoint;
    public Transform rightSpawnPoint;

    public GameObject arrowPrefab; // Single arrow prefab
    public Transform arrowParent;  // Parent transform (optional)

    private float beatInterval;
    private float timer;
    private float arrowTravelTime;

    public float arrowSpeed = 5f;
    public float targetYPosition = 0f;

    void Start()
    {
        beatInterval = 60f / bpm;
        bpm /= 60f;
        timer = -startDelay;

        // Calculate arrow travel time
        float distance = Mathf.Abs(targetYPosition - transform.position.y);
        arrowTravelTime = distance / arrowSpeed;
    }

    void Update()
    {
        if (GameManager.instance.startPlaying && !GameManager.instance.gameOver)
        {

            timer += Time.deltaTime;

            if (timer >= beatInterval - arrowTravelTime)
            {
                // Randomly select a direction
                ArrowDirection randomDirection = (ArrowDirection)Random.Range(0, 4);
                SpawnArrow(randomDirection);
                timer -= beatInterval;
            }
        }
    }

    void SpawnArrow(ArrowDirection direction)
    {
        Transform spawnPoint = null;
        Quaternion rotation = Quaternion.identity;

        switch (direction)
        {
            case ArrowDirection.Left:
                spawnPoint = leftSpawnPoint;
                rotation = Quaternion.Euler(0, 0, 180); // Rotate to face left
                break;
            case ArrowDirection.Down:
                spawnPoint = downSpawnPoint;
                rotation = Quaternion.Euler(0, 0, -90); // Rotate to face down
                break;
            case ArrowDirection.Up:
                spawnPoint = upSpawnPoint;
                rotation = Quaternion.Euler(0, 0, 90); // Rotate to face up
                break;
            case ArrowDirection.Right:
                spawnPoint = rightSpawnPoint;
                rotation = Quaternion.Euler(0, 0, 0); // Face right (default)
                break;
        }

        if (arrowPrefab != null && spawnPoint != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, rotation);

            if (arrowParent != null)
            {
                arrow.transform.SetParent(arrowParent, worldPositionStays: true);
            }

            // Set the KeyCode in NoteObject based on the direction
            NoteObject noteObject = arrow.GetComponent<NoteObject>();
            if (noteObject != null)
            {
                switch (direction)
                {
                    case ArrowDirection.Left:
                        noteObject.keyToPress = KeyCode.LeftArrow;
                        noteObject.ArrowDirection = (int)ArrowDirection.Left;
                        break;
                    case ArrowDirection.Down:
                        noteObject.keyToPress = KeyCode.DownArrow;
                        noteObject.ArrowDirection = (int)ArrowDirection.Down;
                        break;
                    case ArrowDirection.Up:
                        noteObject.keyToPress = KeyCode.UpArrow;
                        noteObject.ArrowDirection = (int)ArrowDirection.Up;
                        break;
                    case ArrowDirection.Right:
                        noteObject.keyToPress = KeyCode.RightArrow;
                        noteObject.ArrowDirection = (int)ArrowDirection.Right;
                        break;
                }
            }
            else
            {
                Debug.LogError("NoteObject component not found on arrow prefab.");
            }
        }
        else
        {
            Debug.LogError("Arrow Prefab or Spawn Point is not assigned for direction: " + direction);
        }
    }
}
