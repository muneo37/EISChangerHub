using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisChanger
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// INotifyPropertyChanged インターフェースを実装した抽象クラスを表します。
    /// </summary>
    internal abstract class NotificationObject : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged のメンバ

        /// <summary>
        /// プロパティ値が変更されたときに発生します。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged のメンバ

        /// <summary>
        /// PropertyChanged イベントを発行します。
        /// </summary>
        /// <param name="propertyName">値が変更されたプロパティ名を指定します。</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }
        ///<summary>///プロパティ値を変更するヘルパです
        ///</summary>
        ///<typeparamname="T">プロパティの型を表します。</typeparam>
        ///<paramname="target">変更するプロパティの実態をref 指定します。</param>
        ///<paramname="value">変更後の値を指定します。</param>
        ///<paramname="propertyName">プロパティ名を指定します。</param>
        ///<returns>プロパティ値に変更があった場合にtrue を返します。</returns>
        protected bool SetProperty<T>(ref T target, T value, [CallerMemberName]string propertyName= null)
        {
            if (Equals(target, value))
                return false;
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
