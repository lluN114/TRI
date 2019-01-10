using UnityEngine;

public interface BlockMaster
{

    /// <summary>
    /// 対象のElectricを取得
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    Electric GetElectric(GameObject obj);

    /// <summary>
    /// 各ブロックのアクションを発動
    /// </summary>
    void BlockAction();

    /// <summary>
    /// 消滅時の機能
    /// </summary>
    void DestroyState();

    

}
