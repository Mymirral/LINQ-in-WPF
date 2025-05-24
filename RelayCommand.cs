using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    //通用写法
    public class RelayCommand : ICommand    //继承自 ICommand 接口
    {
        private readonly Action _execute;   //执行的方法
        private readonly Func<bool> _canExecute;    //是否能执行


        //构造函数，传入执行的方法和是否能执行的方法
        //如果没有传入是否能执行的方法，则默认可以执行
        //如果传入了，则使用传入的方法，判断能否执行
        public RelayCommand(Action execute, Func<bool> canExecute = null) 
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        //解释
        //CanExecute 方法用于判断命令是否可以执行
        //Execute 方法用于执行命令
        //CanExecute 方法会在命令的状态发生变化时被调用
        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;      // ?? 表示如果 _canExecute 为 null，则返回 true
        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
