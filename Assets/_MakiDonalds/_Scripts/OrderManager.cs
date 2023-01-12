using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    [SerializeField]
    GameObject[] _orderPrefabs;

    [SerializeField][Min(2.0f)]
    float _timeForOrderSpawning = 15.0f;

    [SerializeField]
    Transform[] _orderPlaces;

    [SerializeField]
    bool[] _orderPlacesUsed;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("Multiple instances of OrderManager!");
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _orderPlacesUsed = new bool[_orderPlaces.Length];
        for (int i = 0; i < _orderPlacesUsed.Length; i++)
            _orderPlacesUsed[i] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawn()
    {
        StartCoroutine(OrderSawnerCoroutine());
    }

    IEnumerator OrderSawnerCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(_timeForOrderSpawning);

            if(!_orderPlacesUsed[_orderPlacesUsed.Length - 1])
            {
                GameObject newOrder = Instantiate(_orderPrefabs[Random.Range(0, _orderPrefabs.Length)], transform);

                StartCoroutine(OrderMovingToNextAvailablePlaceCoroutine(newOrder));
            }
            else
            {
                Debug.Log("Perdu");

                StartManager.Instance.gameStartStatus = false;

                break;
            }
        }
    }

    IEnumerator OrderMovingToNextAvailablePlaceCoroutine(GameObject newOrder)
    {
        int currentPlaceIndex = _orderPlacesUsed.Length - 1;
        _orderPlacesUsed[currentPlaceIndex] = true;
        float currentLerpTime = 0.0f;
        float transitionTime = 1.0f;
        Vector3 previousPosition = newOrder.transform.position;
        float frequencyUpdate = 0.02f;
        bool animationRunning = true;

        while(true)
        {
            if (animationRunning)
            {
                Vector3 computedPosition = Vector3.Lerp(previousPosition, _orderPlaces[currentPlaceIndex].position, currentLerpTime / transitionTime);

                newOrder.transform.position = computedPosition;

                currentLerpTime = currentLerpTime + frequencyUpdate;
            }

            if (currentLerpTime >= transitionTime) // End of animation
            {
                animationRunning = false;
            }

            if (!animationRunning) // Begin of animation
            {
                if (currentPlaceIndex == 0)
                {
                    break;
                }

                if(!_orderPlacesUsed[currentPlaceIndex - 1])
                {
                    animationRunning = true;

                    previousPosition = _orderPlaces[currentPlaceIndex].position;

                    currentPlaceIndex = currentPlaceIndex - 1;

                    _orderPlacesUsed[currentPlaceIndex + 1] = false;
                    _orderPlacesUsed[currentPlaceIndex] = true;

                    currentLerpTime = 0.0f;
                }
            }

            yield return new WaitForSeconds(frequencyUpdate);
        }

        yield return null;
    }
}
