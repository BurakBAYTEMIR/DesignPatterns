﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    /// <summary>
    /// Bir nesnenin dahili durumu değiştiğinde davranışını değiştirmesine izin verir. Nesne sınıfını değiştirmiş gibi görünür.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            ModifiedState modifiedState = new ModifiedState();
            modifiedState.DoAction(context);
            Console.WriteLine(context.GetState().ToString());

            DeletedState deletedState = new DeletedState();
            deletedState.DoAction(context);
            Console.WriteLine(context.GetState().ToString());

            AddedState addedState = new AddedState();
            addedState.DoAction(context);
            Console.WriteLine(context.GetState().ToString());

            Console.ReadLine();
        }
    }

    interface IState
    {
        void DoAction(Context context);
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified";
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Deleted";
        }
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Added";
        }
    }

    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }

    }
}
