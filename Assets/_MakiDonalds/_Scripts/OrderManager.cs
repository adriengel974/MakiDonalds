using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    int[] _orderPosition;

    GameObject[] _orders;

    int _nextOrderId = 1;

    [SerializeField]
    GameObject endGame;

    [SerializeField]
    GameObject _scoreTextGO;

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
        _orderPosition = new int[_orderPlaces.Length];
        for (int i = 0; i < _orderPosition.Length; i++)
            _orderPosition[i] = 0;

        _orders = new GameObject[_orderPlaces.Length];
    }

    public void DespawnOrder(int orderId)
    {
        for(int i = 0; i < _orderPosition.Length; i++)
        {
            if (_orderPosition[i] == orderId)
            {
                Destroy(_orders[i]);
                _orderPosition[i] = 0;
                break;
            }
        }
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

            if(_orderPosition[_orderPosition.Length - 1] == 0)
            {
                _orders[_orders.Length - 1] = Instantiate(_orderPrefabs[Random.Range(0, _orderPrefabs.Length)], transform);

                _orders[_orders.Length - 1].GetComponentInChildren<OrderValue>().orderId = _nextOrderId;

                _orderPosition[_orders.Length - 1] = _nextOrderId;

                StartCoroutine(OrderMovingToNextAvailablePlaceCoroutine(_orders[_orders.Length - 1], _nextOrderId));

                _nextOrderId += 1;
            }
            else
            {
                Debug.Log("Perdu");

                StartManager.Instance.gameStartStatus = false;

                endGame.SetActive(true);

                TMP_Text text = _scoreTextGO.GetComponent<TMP_Text>();

                text.text = ValidateFood.Instance.score.ToString();

                break;
            }
        }
    }

    IEnumerator OrderMovingToNextAvailablePlaceCoroutine(GameObject newOrder, int orderId)
    {
        int currentPlaceIndex = _orderPosition.Length - 1;
        _orderPosition[currentPlaceIndex] = orderId;
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

                if(_orderPosition[currentPlaceIndex - 1] == 0)
                {
                    animationRunning = true;

                    previousPosition = _orderPlaces[currentPlaceIndex].position;

                    _orderPosition[currentPlaceIndex] = 0;
                    _orderPosition[currentPlaceIndex - 1] = orderId;
                    _orders[currentPlaceIndex] = null;
                    _orders[currentPlaceIndex - 1] = newOrder;

                    currentPlaceIndex -= 1;

                    currentLerpTime = frequencyUpdate;
                }
            }

            yield return new WaitForSeconds(frequencyUpdate);
        }

        yield return null;
    }
}
