using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary.Commands
{
    /// <summary>
    /// AUTHOR: Harry Jacob Jones
    /// VERSION: 0.1
    /// CREATION DATE: 31/08/2020
    /// CLASS PURPOSE: The purpose of this class is to create a series of generic commands
    /// which will all be used to call different methods, which accept different parameters
    /// </summary>
    public class Command : ICommand
    {
        private Action _action;

        public Command(Action action) 
        {
            _action = action;
        }

        public void Execute() 
        {
            _action();
        }
    }

    /// <summary>
    /// Variation of the previous class, accepting a type parameter which will be passed as 
    /// parameter to an action
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T> : ICommand
    {
        // Action variable, accepts T parameters
        private Action<T> _action;
        // Variable of type T
        private T _data;

        // CONSTRUCTOR
        public Command(Action<T> action, T data) 
        {
            _action = action;

            _data = data;
        }

        public void Execute() 
        {
            // CALL to action delegate, passing in T parameter/variable
            _action(_data);
        }
    }

    /// <summary>
    /// Variation of the previous class, accepting a type parameter which will be passed as 
    /// parameter to an action
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="S"></typeparam>
    public class Command<T, S> : ICommand
    {
        // Action variable, accepts T parameters
        private Action<T, S> _action;
        // Variable of type T
        private T _data;
        // Variable of type S
        private S _dataS;

        // CONSTRUCTOR
        public Command(Action<T, S> action, T data, S dataS)
        {
            _action = action;

            _data = data;

            _dataS = dataS;
        }

        public void Execute()
        {
            // CALL to action delegate, passing in T parameter/variable
            _action(_data, _dataS);
        }
    }
}
