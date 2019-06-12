using UnityEngine;

public class Cards
{
    #region 欄位宣告
    private int _number;
    private int _xPosition;
    private Sprite _picture;
    #endregion

    #region 屬性設定
    public int number { get { return _number; } }
    public int xPosition { get { return _xPosition; } set { _xPosition = value; } }
    public Sprite picture { get { return _picture; } }
    #endregion

    #region 建構方法
    /// <summary>
    /// Cards建構子
    /// </summary>
    /// <param name="number">數字</param>
    /// <param name="xPosition">水平位置</param>
    /// <param name="picture">圖片</param>
    public Cards ( int number, int xPosition, Sprite picture)
    {
        _number = number;
        _xPosition = xPosition;
        _picture = picture;
    }
    #endregion
}
