using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float lengthGroundCheck=10f;
    [SerializeField] private Vector3 offSetToGround;
    [SerializeField] private StackController _stackController;
    private bool isMoving=false;
    public bool NewDirec = false;
    public Vector3 direc;
    private GameInputs.PlayerActions _playerActions;
    public  Vector3 inputDirec=Vector3.zero;


    private void OnEnable()
    {
        _playerActions = GameInputManager.Singleton.GameInputs.Player;
        _playerActions.Enable();
    }
    
    
    private void Update()
    {
        if(GameStateManager.Singleton.GameState!=GameState.Playing) return; 
        
        if (NewDirec)
        {
            if (!isMoving)
            {
                isMoving = true;
                /*
                StartCoroutine(MoveInDirec(direc));
                */
                StartCoroutine(MoveInDirecReCode(direc));
                NewDirec = false;
            }
           
        }
        else
        {
            var moveInput = _playerActions.Move.ReadValue<Vector2>();

            if (inputDirec != Vector3.zero)
            {
                if (isMoving == false)
                {
                    direc = inputDirec;
                    StartCoroutine(MoveInDirecReCode(direc));
                    inputDirec=Vector3.zero;
                    
                }
            }
            
            if (moveInput.x*moveInput.y==0&&moveInput!=Vector2.zero)
            {
                
            }
        }
    }
    
    private void TakeStack(RaycastHit hit)
    {
        var takeablecomponent = hit.transform.GetComponent<ITakeable>();
        if (takeablecomponent != null)
        {
            _stackController.AddStack(hit.transform.gameObject);
        }
    }

    private void RemoveStack(RaycastHit hit)
    {
        var removeablecomponent = hit.transform.GetComponent<GroundNeedStack>();
        if (removeablecomponent != null)
        {
            _stackController.RemoveStack(hit.transform.parent);
        }
    }

    private bool CanWalk(Transform target)
    {
        if (target.GetComponent<IWalkable>() != null)
        {
            if (target.GetComponent<INeedStack>() != null && _stackController.stacks.Count == 0)
            {
                return false;
            }
            return true;
        }

        return false;
    }

    private bool NeedStack(Transform target)
    {
        if (target.GetComponent<INeedStack>() != null)
        {
            return true;
        }

        return false;
    }

    private bool moveToTarget = false;

    public bool G()
    {
        return !moveToTarget;
    }
    IEnumerator MoveInDirecReCode(Vector3 direction)
    {
        
        // normalized direcction
        direction = direction.normalized;
        
        // set player moving state
        isMoving = true;
        do
        {
            var localCast=Physics.Raycast(transform.position + Vector3.up * 5, Vector3.down, out var hitInfoLocal, 100f);
            if (localCast)
            {
                TakeStack(hitInfoLocal);
                RemoveStack(hitInfoLocal);
            }
            
            // if direc has collider
            var direcCast=Physics.Raycast(transform.position + Vector3.up * 5 + direction, Vector3.down, out var hitInfoDirec, 100f);

            if (direcCast)
            {
                if (CanWalk(hitInfoDirec.transform))
                {
                    /*StartCoroutine(Move1(hitInfoDirec.transform));
                    moveToTarget = true;

                    yield return new WaitUntil(G);*/
                    Move(hitInfoDirec.transform);/**/
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
            
            
            
            
            yield return null;
        } while (isMoving&&NewDirec==false);
        isMoving = false;
    }

    private void Move(Transform target)
    {
        var targetPosiion = target.position;
        targetPosiion.y = 3;
        transform.position = targetPosiion;
    }


    IEnumerator Move1(Transform target)
    {
        var targetPosiion = target.position;
        targetPosiion.y = 3;


        while (transform.position!=targetPosiion)
        {
            transform.position=Vector3.MoveTowards(transform.position,targetPosiion,1f);
            yield return null;
        }

        moveToTarget = false;
    }
}

