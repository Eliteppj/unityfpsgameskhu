using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gsm;
    public GameObject drawhands;

    public GameObject tmpx;
    [SerializeField]
    private float walkspeed;

    [SerializeField]
    private float runspeed;


    [SerializeField]
    private float crouchspeed;


    private float applyspeed;

    [SerializeField]
    private float jumpforce;

    //상태 변수
    private bool isrun = false;
    private bool isground = true;
    private bool iscrouch = false;
    private bool isExit = false;


    //얼마나 앉을 것인가
    [SerializeField]
    private float crouchposy;
    private float originposy;
    private float applycrouchposy;

    //땅 착지 여부
    private CapsuleCollider capsuleCollider;

    // 민감도
    [SerializeField]
    private float lookSensitivity;

    // 카메라 한계
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    // 필요한 컴포넌트  
    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
        applyspeed = walkspeed;
        originposy = theCamera.transform.localPosition.y;
        applycrouchposy = originposy;
        WeaponManager.ischangeweapon = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (gsm.GetComponent<GameStatusManager>().canmove == true)
        {
            IsExit();
            IsGround();
            TryJump();
            TryRun();
            TryCrouch();
            Move();
            Drawhands();
        }

        if (gsm.GetComponent<GameStatusManager>().canmove == true && !InventoryController.InventoryActivated) //좌측은 구식 스크립트의 변수
        {
            CameraRotation();
            CharacterRotation();

        }


    }

    private void Drawhands()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            drawhands.GetComponent<WeaponManager>().MasterChanger("Melee", "barehand");
        }

    }

    private void IsExit()
    {
        RaycastHit exithit;
       if (Physics.Raycast(transform.position, Vector3.down, out exithit, capsuleCollider.bounds.extents.y + 0.1f))
        {
           if(exithit.collider.tag=="SR")
            {
                tmpx.GetComponent<PlayerStatus>().GameSet();
            }
        }
    }

    private void TryCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }

    }
    private void Crouch()
    {
        iscrouch = !iscrouch;

        if (iscrouch)
        {
            applyspeed = crouchspeed;
            applycrouchposy = crouchposy;
        }
        else
        {
            applyspeed = walkspeed;
            applycrouchposy = originposy;
        }
        StartCoroutine(CrouchCoroutine());

    }


    IEnumerator CrouchCoroutine()
    {
        float _posY = theCamera.transform.localPosition.y;
        int count = 0;

        while (_posY != applycrouchposy)
        {
            count++;
            _posY = Mathf.Lerp(_posY, applycrouchposy, 0.1f);
            theCamera.transform.localPosition = new Vector3(0, _posY, 0);
            if (count > 60)
                break;

            yield return null;
        }
        theCamera.transform.localPosition = new Vector3(0, applycrouchposy, 0f);

    }

    private void IsGround()
    {
        isground = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);

    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            Jump();

        }

    }


    private void Jump()
    {
        if (iscrouch)
            Crouch();

        myRigid.velocity = transform.up * jumpforce;
    }


    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();


        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancel();
        }

    }


    private void Running()
    {
        if (iscrouch)
            Crouch();

        isrun = true;
        applyspeed = runspeed;



    }

    private void RunningCancel()
    {
        isrun = false;
        applyspeed = walkspeed;

    }


    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applyspeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    


    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);

    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }



}