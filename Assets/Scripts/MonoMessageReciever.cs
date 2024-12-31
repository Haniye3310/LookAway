using UnityEngine;

public class MonoMessageReciever : MonoBehaviour
{
    [SerializeField] private DataRepo _dataRepo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SystemFunction.Start(_dataRepo);
    }

    // Update is called once per frame
    void Update()
    {
        SystemFunction.Update(_dataRepo);
    }
}
