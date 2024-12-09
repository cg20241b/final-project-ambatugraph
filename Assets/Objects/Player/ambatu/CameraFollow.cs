using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _cameraPositionRaw;
    public Transform targetTransform;
    //[Range(0.1f, 5f)]
    [SerializeField] private float _cameraDistance = 1.25f;
    //[Range(1, 10)]
    [SerializeField] private float _followSpeed = 2;
    //[Range(1, 10)]
    [SerializeField] private float _lookSpeed = 5;
    private Vector3 _initialCameraPosition;


    private void Awake()
    {
        _cameraPositionRaw = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        _initialCameraPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        _initialCameraPosition = new Vector3(_cameraPositionRaw.x * _cameraDistance, _cameraPositionRaw.y * _cameraDistance, _cameraPositionRaw.z * _cameraDistance);

        //Look at car
        Vector3 _lookDirection = (new Vector3(targetTransform.position.x, targetTransform.position.y, targetTransform.position.z)) - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, _lookSpeed * deltaTime);

        //Move to car
        Vector3 _targetPos = _initialCameraPosition + targetTransform.transform.position;
        transform.position = Vector3.Lerp(transform.position, _targetPos, _followSpeed * deltaTime);
    }
}
