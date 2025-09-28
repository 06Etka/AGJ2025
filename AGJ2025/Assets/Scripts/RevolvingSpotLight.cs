using UnityEngine;

public class RevolvingSpotLight : MonoBehaviour
{
    private const float fZero = 0f;

    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float maxAngle = 180f;
    [SerializeField] float cycleDuration = 2f;

    private float cycleTimer = fZero; 
    private float startTime;
    private int direction = 1;
    private float targetAngle = fZero;
    private float currentAngle = fZero;
    private float easing = 0.1f;

    private void Start()
    {
        startTime = Time.time;
        RandomizeValues();
        targetAngle = maxAngle *Mathf.Sin((Time.time - startTime) * rotationSpeed * direction);
        currentAngle = targetAngle;
    }

    void RandomizeValues()
    {
        direction = Random.value > 0.5f ? 1 : -1;
        maxAngle = Random.Range(90f, 180f);
        rotationSpeed = Random.Range(0.5f, 2f);
    }

    void Update()
    {
        cycleTimer += Time.deltaTime;
        targetAngle = maxAngle * Mathf.Sin((Time.time - startTime) * rotationSpeed * direction);
        currentAngle = Mathf.Lerp(currentAngle, targetAngle, easing);


        transform.localRotation = Quaternion.Euler(currentAngle, currentAngle, currentAngle);

        if (cycleTimer >= cycleDuration)
        {
            cycleTimer = fZero;
            startTime = Time.time;
            RandomizeValues();
        }
    }

}
