using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EisChanger
{
    internal class DelegateCommand : ICommand
    {
        #region コンストラクタ

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="execute">コマンド内容を指定します。</param>
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="execute">コマンド内容を指定します。</param>
        /// <param name="canExecute">コマンドの実行可能判別処理を指定します。</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this._execute = execute;
            this._canExecute = canExecute;
        }

        #endregion コンストラクタ

        /// <summary>
        /// コマンド内容をデリゲートとして保持します。
        /// </summary>
        private Action<object> _execute;

        /// <summary>
        /// コマンドの実行可能判別処理をデリゲートとして保持します。
        /// </summary>
        private Func<object, bool> _canExecute;

        #region ICommand のメンバ

        /// <summary>
        /// コマンド実行可能判別結果が変更されたときに発生します。
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// コマンドが実行可能かどうかを判別します。
        /// </summary>
        /// <param name="parameter">判別処理に必要なパラメータを指定します。</param>
        /// <returns>コマンドが実行可能な場合に true を返します。</returns>
        public bool CanExecute(object parameter)
        {
            return this._canExecute != null ? this._canExecute(parameter) : true;
        }

        /// <summary>
        /// コマンドを実行します。
        /// </summary>
        /// <param name="parameter">必要なパラメータを指定します。</param>
        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        #endregion ICommand のメンバ

        /// <summary>
        /// CanExecuteChanged イベントを発行します。
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var h = this.CanExecuteChanged;
            if (h != null) h(this, EventArgs.Empty);
        }
    }
}
