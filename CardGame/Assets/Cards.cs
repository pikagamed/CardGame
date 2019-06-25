using UnityEngine;

[System.Serializable]
public class Cards
{
    #region 欄位宣告
    private int _number;
    private int _xPosition;
    private Sprite _picture;
    private string _objectName;
    private GameObject _gameObject;
    #endregion

    #region 屬性設定
    //public int xPosition { get => _xPosition; set =>_xPosition = value;  }

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
    public Cards ( int number, int xPosition, Sprite picture, string objectName)
    {
        _number = number;
        _xPosition = xPosition;
        _picture = picture;

        _gameObject = new GameObject(objectName);   //Unity API 新增遊戲物件(名稱)
        _gameObject.AddComponent<SpriteRenderer>();            //添加元件 泛型方法<類型> 
        _gameObject.GetComponent<SpriteRenderer>().sprite = picture; //取得元件 圖片 = 屬性 - 圖片
        _gameObject.GetComponent<Transform>().position = new Vector2(xPosition, 0);    //取得元件 變形 座標 = 新二維向量
    }
    #endregion
}
