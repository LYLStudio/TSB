using System;

namespace TSB.Models
{
    /// <summary>
    /// 泛型Callback整合物件介面
    /// </summary>
    /// <typeparam name="T">泛型Callback參數</typeparam>
    public interface IAnything<T>
    {
        T Parameter { get; set; }
        Action<T> Callback { get; set; }
    }

    /// <summary>
    /// 泛型Callback整合物件
    /// </summary>
    /// <typeparam name="T">泛型Callback參數</typeparam>
    public class Anything<T> : IAnything<T>
    {
        public T Parameter { get; set; }
        public Action<T> Callback { get; set; }
    }

    /// <summary>
    /// 動態型別Callback整合物件
    /// </summary>
    public class AnythingDynamic : Anything<dynamic>
    {
    }
}
