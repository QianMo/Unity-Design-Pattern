/// <summary>
/// A simple example of a class inheriting from a command pattern
/// This handles execution of the command as well as unexecution of the command
/// </summary>

using UnityEngine;

    // A basic enum to describe our movement
    public enum MoveDirection { up, down, left, right };

    class MoveCommand : Command
    {
        private MoveDirection _direction;
        private MoveCommandReceiver _receiver;
        private float _distance;
        private GameObject _gameObject;


        //Constructor
        public MoveCommand(MoveCommandReceiver reciever, MoveDirection direction, float distance, GameObject gameObjectToMove)
        {
            this._receiver = reciever;
            this._direction = direction;
            this._distance = distance;
            this._gameObject = gameObjectToMove;
        }


        //Execute new command
        public void Execute()
        {
            _receiver.MoveOperation(_gameObject, _direction, _distance);
        }


        //Undo last command
        public void UnExecute()
        {
            _receiver.MoveOperation(_gameObject, InverseDirection(_direction), _distance);
        }


        //invert the direction for undo
        private MoveDirection InverseDirection(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.up:
                    return MoveDirection.down;
                case MoveDirection.down:
                    return MoveDirection.up;
                case MoveDirection.left:
                    return MoveDirection.right;
                case MoveDirection.right:
                    return MoveDirection.left;
                default:
                    Debug.LogError("Unknown MoveDirection");
                    return MoveDirection.up;
            }
        }


        //So we can show this command in debug output easily
        public override string ToString()
        {
            return _gameObject.name + " : " + MoveDirectionString(_direction) + " : " + _distance.ToString();
        }


        //Convert the MoveDirection enum to a string for debug
        public string MoveDirectionString(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.up:
                    return "up";
                case MoveDirection.down:
                    return "down";
                case MoveDirection.left:
                    return "left";
                case MoveDirection.right:
                    return "right";
                default:
                    return "unkown";
            }
        }
    }
