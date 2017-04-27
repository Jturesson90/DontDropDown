using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Player : MonoBehaviour, IRestartableCommand
{
    private PlayerStartTransform _playerStartPos;
    public readonly static string PLAYER_TAG = "Player";

    [SerializeField]
    float MinSpeed = 1.2f;
    [SerializeField]
    float MaxSpeed = 8f;
    [SerializeField]
    float IncreasingSpeedDuration = 60f;
    float MoveSpeed = 1f;
    [SerializeField]
    Vector3 Angle = new Vector3(0, -47, 0);

    int speedTweenId = -1;
    bool _running = false;

    AnimalChooser _animalChooser;
    Rigidbody _rigidbody;
    SphereCollider _collider;
    private void Start()
    {
        _animalChooser.ChooseRandomAnimal();
    }

    internal void HitByObject(MonoBehaviour monoBehaviour)
    {
        throw new NotImplementedException();
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animalChooser = GetComponent<AnimalChooser>();
        _collider = GetComponent<SphereCollider>();

        var startPos = GameObject.Find("Player Start");
        if (startPos) _playerStartPos = new PlayerStartTransform(startPos.transform);
        else _playerStartPos = new PlayerStartTransform(transform);
        _playerStartPos.UpdateTransform(transform);
    }
    internal void Move(Vector3 move, bool rotate)
    {
        if (!_running) return;

        var newVelocity = move * MoveSpeed;
        _animalChooser.CurrentAnimal.SetAnimatorSpeed(newVelocity.magnitude);
        newVelocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = newVelocity;


        var input = rotate ? 1 : 0;

        var deltaRotation = Quaternion.Euler(Angle * MoveSpeed * input * Time.deltaTime) * _rigidbody.rotation;
        _rigidbody.MoveRotation(deltaRotation);

        var targetRotation = GetTargetRotationQuaternion().eulerAngles;
        var lerpedRotation = Mathf.LerpAngle(_animalChooser.CurrentAnimal.transform.localEulerAngles.x, targetRotation.x, Time.deltaTime * 10f);
        float y = _animalChooser.CurrentAnimal.transform.localEulerAngles.y;
        float z = _animalChooser.CurrentAnimal.transform.localEulerAngles.z;
        _animalChooser.CurrentAnimal.transform.localEulerAngles = new Vector3(lerpedRotation, y, z);

    }


    private void OnGameStateChanged()
    {
        switch (GameController.Instance.GameState)
        {
            case GameState.Playing:
                Begin();
                break;
            case GameState.GameOver:
                GameOver();
                break;
        }
    }

    void Begin()
    {
        _running = true; speedTweenId = LeanTween.value(gameObject, MinSpeed, MaxSpeed, IncreasingSpeedDuration).setOnUpdate((float speed) =>
        {
            MoveSpeed = speed;
        }).id;
    }
    private void GameOver()
    {
        _running = false;
        _rigidbody.velocity = _rigidbody.velocity * 0.5f;
        LeanTween.cancel(speedTweenId);
    }
    private void OnEnable()
    {
        GameController.OnGameStateChanged += OnGameStateChanged;
    }
    void OnDisable()
    {
        GameController.OnGameStateChanged -= OnGameStateChanged;
    }
    void OnRestart()
    {
        _running = false;
        _playerStartPos.UpdateTransform(transform);
        _animalChooser.ChooseRandomAnimal();
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
    public void ExecuteRestart()
    {
        OnRestart();
    }
    readonly Vector3 VECTOR3_DOWN = Vector3.down;
    readonly Vector3 VECTOR3_UP = Vector3.up;
    Quaternion GetTargetRotationQuaternion()
    {
        Ray ray = GetRay(_collider.transform.position + (transform.forward * _collider.radius), VECTOR3_DOWN);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f, 1 << LayerMask.NameToLayer("Island")))
        {
            var targetRotation = Quaternion.FromToRotation(_rigidbody.transform.up, hit.normal) * _rigidbody.rotation;
            return targetRotation;
        }
        return _rigidbody.rotation;
    }
    Vector3 GetTargetRotation()
    {
        Ray ray = GetRay(_collider.transform.position + (transform.forward * _collider.radius), VECTOR3_DOWN);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f, 1 << LayerMask.NameToLayer("Island")))
        {
            var modelTransform = _animalChooser.CurrentAnimal.transform;
            var targetRotation = hit.normal;
            return targetRotation;
        }
        return _rigidbody.transform.localEulerAngles;
    }

    private Ray GetRay(Vector3 startPos, Vector3 dir)
    {
        var ray = new Ray(startPos, dir);
        Debug.DrawRay(startPos, dir, Color.red);
        return ray;
    }

    struct PlayerStartTransform
    {
        Vector3 _pos;
        Vector3 _localScale;
        Quaternion _rotation;

        public PlayerStartTransform(Transform t)
        {
            _pos = t.localPosition;
            _localScale = t.localScale;
            _rotation = t.localRotation;
        }

        public void UpdateTransform(Transform t)
        {
            t.localPosition = _pos;
            t.localScale = _localScale;
            t.localRotation = _rotation;
        }

    }
}
