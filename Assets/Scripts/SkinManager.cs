using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public Sprite NormalEmpty;
    public Sprite NormalUp;
    public Sprite NormalLeft;
    public Sprite NormalDown;
    public Sprite NormalRight;
    public Sprite NormalUpLeft;
    public Sprite NormalLeftDown;
    public Sprite NormalDownRight;
    public Sprite NormalUpRight;
    public Sprite NormalUpDown;
    public Sprite NormalLeftRight;
    public Sprite NormalUpLeftDown;
    public Sprite NormalLeftDownRight;
    public Sprite NormalUpDownRight;
    public Sprite NormalUpLeftRight;
    public Sprite NormalUpLeftDownRight;

    public Sprite LockEmpty;
    public Sprite LockUp;
    public Sprite LockLeft;
    public Sprite LockDown;
    public Sprite LockRight;
    public Sprite LockUpLeft;
    public Sprite LockLeftDown;
    public Sprite LockDownRight;
    public Sprite LockUpRight;
    public Sprite LockUpDown;
    public Sprite LockLeftRight;
    public Sprite LockUpLeftDown;
    public Sprite LockLeftDownRight;
    public Sprite LockUpDownRight;
    public Sprite LockUpLeftRight;
    public Sprite LockUpLeftDownRight;

    public Sprite LeftArrow;
    public Sprite RightArrow;

    public Sprite LockedLock;

    public Sprite GetSkin(string id)
    {
        Dictionary<string, Sprite> skins = new Dictionary<string, Sprite>()
        {
            {"N0000", NormalEmpty},
            {"N1000", NormalUp},
            {"N0100", NormalLeft},
            {"N0010", NormalDown},
            {"N0001", NormalRight},
            {"N1100", NormalUpLeft},
            {"N0110", NormalLeftDown},
            {"N0011", NormalDownRight},
            {"N1001", NormalUpRight},
            {"N1010", NormalUpDown},
            {"N0101", NormalLeftRight},
            {"N1110", NormalUpLeftDown},
            {"N0111", NormalLeftDownRight},
            {"N1011", NormalUpDownRight},
            {"N1101", NormalUpLeftRight},
            {"N1111", NormalUpLeftDownRight},

            {"S0000", LockEmpty},
            {"S1000", LockUp},
            {"S0100", LockLeft},
            {"S0010", LockDown},
            {"S0001", LockRight},
            {"S1100", LockUpLeft},
            {"S0110", LockLeftDown},
            {"S0011", LockDownRight},
            {"S1001", LockUpRight},
            {"S1010", LockUpDown},
            {"S0101", LockLeftRight},
            {"S1110", LockUpLeftDown},
            {"S0111", LockLeftDownRight},
            {"S1011", LockUpDownRight},
            {"S1101", LockUpLeftRight},
            {"S1111", LockUpLeftDownRight},

            {"L0000", LeftArrow},
            {"R0000", RightArrow},

            {"XXXXX", LockedLock}
        };

        return skins[id];
    }
}
