/// <summary>
/// The 'Receiver' class - this handles what a move command actually does
/// </summary>

using UnityEngine;

    class MoveCommandReceiver
    {
        public void MoveOperation(GameObject gameObjectToMove, MoveDirection direction, float distance)
        {
            switch (direction)
            {
                case MoveDirection.up:
                    MoveY(gameObjectToMove, distance);
                    break;
                case MoveDirection.down:
                    MoveY(gameObjectToMove, -distance);
                    break;
                case MoveDirection.left:
                    MoveX(gameObjectToMove, -distance);
                    break;
                case MoveDirection.right:
                    MoveX(gameObjectToMove, distance);
                    break;
            }
        }

        private void MoveY(GameObject gameObjectToMove, float distance)
        {
            Vector3 newPos = gameObjectToMove.transform.position;
            newPos.y += distance;
            gameObjectToMove.transform.position = newPos;
        }

        private void MoveX(GameObject gameObjectToMove, float distance)
        {
            Vector3 newPos = gameObjectToMove.transform.position;
            newPos.x += distance;
            gameObjectToMove.transform.position = newPos;
        }
    }

