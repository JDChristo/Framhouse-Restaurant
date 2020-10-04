using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode leftKey;

    [SerializeField] private KeyCode pickUpKey;
    [SerializeField] private KeyCode dropDownKey;
    [SerializeField] private KeyCode changePlayerKey;

    public float PlayerSpeed { get => playerSpeed; }
    public LayerMask WallLayer { get => wallLayer; }

    public KeyCode UpKey { get => upKey;          }
    public KeyCode DownKey { get => downKey;        }
    public KeyCode RightKey { get => rightKey;       }
    public KeyCode LeftKey { get => leftKey;        }

    public KeyCode PickUpKey { get => pickUpKey;      }
    public KeyCode DropDownKey { get => dropDownKey;    }
    public KeyCode ChangePlayerKey { get => changePlayerKey;}
}                                  
