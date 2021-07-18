#pragma warning disable IDE0090 // 'new(...)' 사용
using UnityEngine;

static class Constants
{
    public static readonly Vector2 BLOCKSIZE = new Vector2(200, 75);
    public static readonly Vector2 BLOCKGAP = new Vector2(10, 10);

    public static readonly Vector2 ARMORSIZE = new Vector2(2, 2);
    public static readonly Vector2 SHIELDSIZE = new Vector2(1, 2);
    public static readonly Vector2 SHOESIZE = new Vector2(2, 1);
    public static readonly Vector2 SWORDSIZE = new Vector2(1, 3);
    public static readonly Vector2 RINGSIZE = new Vector2(1, 1);
    public static readonly Vector2 MAPSIZE = new Vector2(4, 9);

    public static readonly Vector2 ARMORMAX = new Vector2(MAPSIZE.x - ARMORSIZE.x + 1, MAPSIZE.y - ARMORSIZE.y + 1);
    public static readonly Vector2 SHIELDMAX = new Vector2(MAPSIZE.x - SHIELDSIZE.x + 1, MAPSIZE.y - SHIELDSIZE.y + 1);
    public static readonly Vector2 SHOEMAX = new Vector2(MAPSIZE.x - SHOESIZE.x + 1, MAPSIZE.y - SHOESIZE.y + 1);
    public static readonly Vector2 SWORDMAX = new Vector2(MAPSIZE.x - SWORDSIZE.x + 1, MAPSIZE.y - SWORDSIZE.y + 1);
    public static readonly Vector2 RINGMAX = new Vector2(MAPSIZE.x - RINGSIZE.x + 1, MAPSIZE.y - RINGSIZE.y + 1);
}

