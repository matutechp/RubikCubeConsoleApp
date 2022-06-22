using System;
using System.Collections.Generic;


namespace CubeLibrary
{
    public class RubikCube
    {

        public CubeFace Front { get; private set; }
        public CubeFace Back { get; private set; }
        public CubeFace Top { get; private set; }
        public CubeFace Bottom { get; private set; }
        public CubeFace Left { get; private set; }
        public CubeFace Right { get; private set; }
        public Dictionary<Direction, Action> MovementDictionary { get; private set; }

        public RubikCube(char F, char B, char U, char D, char L, char R)
        {
            Front = new CubeFace(F);
            Back = new CubeFace(B);
            Top = new CubeFace(U);
            Bottom = new CubeFace(D);
            Left = new CubeFace(L);
            Right = new CubeFace(R);
        }
        public RubikCube()
        {
            Front = new CubeFace('R');
            Back = new CubeFace('O');
            Top = new CubeFace('Y');
            Bottom = new CubeFace('W');
            Left = new CubeFace('B');
            Right = new CubeFace('G');

            BuildDictionaryDirection();

        }


        private void BuildDictionaryDirection()
        {
            MovementDictionary = new Dictionary<Direction, Action>();
            MovementDictionary.Add(Direction.CubeRight, MoveCubeRight);
            MovementDictionary.Add(Direction.CubeLeft, MoveCubeLeft);
            MovementDictionary.Add(Direction.CubeTop, MoveCubeTop);
            MovementDictionary.Add(Direction.CubeBottom, MoveCubeBottom);

            MovementDictionary.Add(Direction.FrontFace, FrontFace);
            MovementDictionary.Add(Direction.FrontFaceInverse, FrontFaceInverse);

            MovementDictionary.Add(Direction.BackFace, BackFace);
            MovementDictionary.Add(Direction.BackFaceInverse, BackFaceInverse);

            MovementDictionary.Add(Direction.TopFace, TopFace);
            MovementDictionary.Add(Direction.TopFaceInverse, TopFaceInverse);

            MovementDictionary.Add(Direction.BottomFace, BottomFace);
            MovementDictionary.Add(Direction.BottomFaceInverse, BottomFaceInverse);

            MovementDictionary.Add(Direction.RightFace, RightFace);
            MovementDictionary.Add(Direction.RightFaceInverse, RightFaceInverse);

            MovementDictionary.Add(Direction.LeftFace, LeftFace);
            MovementDictionary.Add(Direction.LeftFaceInverse, LeftFaceInverse);

            MovementDictionary.Add(Direction.FrontMiddleDown, FrontMiddleDown);
            MovementDictionary.Add(Direction.FrontMiddleUp, FrontMiddleUp);

            MovementDictionary.Add(Direction.FrontMiddleLeft, FrontMiddleLeft);
            MovementDictionary.Add(Direction.FrontMiddleRight, FrontMiddleRight);

            MovementDictionary.Add(Direction.TopMiddleLeft, TopMiddleRight);
            MovementDictionary.Add(Direction.TopMiddleRight, TopMiddleLeft);

            MovementDictionary.Add(Direction.DoubleUp, DoubleUp);
            MovementDictionary.Add(Direction.DoubleUpInverse, DoubleUpInverse);

            MovementDictionary.Add(Direction.DoubleDown, DoubleDown);
            MovementDictionary.Add(Direction.DoubleDownInverse, DoubleDownInverse);

            MovementDictionary.Add(Direction.DoubleRight, DobleRight);
            MovementDictionary.Add(Direction.DoubleRightInverse, DoubleRightInverse);

            MovementDictionary.Add(Direction.DoubleLeft, DoubleLeft);
            MovementDictionary.Add(Direction.DoubleLeftInverse, DoubleLeftInverse);





        }

        private void DoubleLeftInverse()
        {
            RightFaceInverse();
            MoveCubeTop();
        }

        private void DoubleLeft()
        {
            RightFace();
            MoveCubeBottom();
        }

        private void DoubleRightInverse()
        {
            LeftFaceInverse();
            MoveCubeBottom();
        }

        private void DobleRight()
        {
            LeftFace();
            MoveCubeTop();
        }

        private void DoubleDownInverse()
        {
            TopFace();
            MoveCubeLeft();
        }

        private void DoubleDown()
        {
            TopFaceInverse();
            MoveCubeRight();
        }

        private void DoubleUpInverse()
        {
            BottomFace();
            MoveCubeLeft();
        }

        private void DoubleUp()
        {
            BottomFaceInverse();
            MoveCubeRight();
        }

        private void TopMiddleLeft()
        {
            FrontFace();
            BackFaceInverse();
            MoveCubeLeft();
            MoveCubeTop();
            MoveCubeRight();
        }

        private void TopMiddleRight()
        {
            FrontFaceInverse();
            BackFace();
            MoveCubeLeft();
            MoveCubeBottom();
            MoveCubeRight();

        }

        private void FrontMiddleRight()
        {
            TopFaceInverse();
            BottomFaceInverse();
            MoveCubeRight();
        }

        private void FrontMiddleLeft()
        {
            TopFace();
            BottomFace();
            MoveCubeLeft();
        }

        private void FrontMiddleUp()
        {
            RightFaceInverse();
            LeftFace();
            MoveCubeTop();
        }

        private void FrontMiddleDown()
        {
            RightFace();
            LeftFaceInverse();
            MoveCubeBottom();
        }

        private void LeftFaceInverse()
        {
            char[] TempArray = new char[3];
            Left.RotateFace('l');
            Top.GetEdge('l').CopyTo(TempArray, 0);
            Top.CopyToEdge(Front.GetEdge('l'), 'l');
            Front.CopyToEdgeReverse(Bottom.GetEdge('r'), 'l');
            Bottom.CopyToEdge(Back.GetEdge('r'), 'r');
            Back.CopyToEdgeReverse(TempArray, 'r');
        }

        private void LeftFace()
        {
            char[] TempArray = new char[3];
            Left.RotateFace('r');
            Top.GetEdge('l').CopyTo(TempArray, 0);
            Top.CopyToEdgeReverse(Back.GetEdge('r'), 'l');
            Back.CopyToEdge(Bottom.GetEdge('r'), 'r');
            Bottom.CopyToEdgeReverse(Front.GetEdge('l'), 'r');
            Front.CopyToEdge(TempArray, 'l');
        }

        private void RightFaceInverse()
        {
            char[] TempArray = new char[3];
            Right.RotateFace('l');
            Top.GetEdge('r').CopyTo(TempArray, 0);
            Top.CopyToEdgeReverse(Back.GetEdge('l'), 'r');
            Back.CopyToEdge(Bottom.GetEdge('l'), 'l');
            Bottom.CopyToEdgeReverse(Front.GetEdge('r'), 'l');
            Front.CopyToEdge(TempArray, 'r');
        }

        private void RightFace()
        {
            char[] TempArray = new char[3];
            Right.RotateFace('r');
            Top.GetEdge('r').CopyTo(TempArray, 0);
            Top.CopyToEdge(Front.GetEdge('r'), 'r');
            Front.CopyToEdgeReverse(Bottom.GetEdge('l'), 'r');
            Bottom.CopyToEdge(Back.GetEdge('l'), 'l');
            Back.CopyToEdgeReverse(TempArray, 'l');
        }

        private void BottomFaceInverse()
        {
            char[] TempArray = new char[3];
            Bottom.RotateFace('l');
            Back.GetEdge('d').CopyTo(TempArray, 0);
            Back.CopyToEdge(Left.GetEdge('d'), 'd');
            Left.CopyToEdge(Front.GetEdge('d'), 'd');
            Front.CopyToEdge(Right.GetEdge('d'), 'd');
            Right.CopyToEdge(TempArray, 'd');
        }

        private void BottomFace()
        {
            char[] TempArray = new char[3];
            Bottom.RotateFace('r');
            Back.GetEdge('d').CopyTo(TempArray, 0);
            Back.CopyToEdge(Right.GetEdge('d'), 'd');
            Right.CopyToEdge(Front.GetEdge('d'), 'd');
            Front.CopyToEdge(Left.GetEdge('d'), 'd');
            Left.CopyToEdge(TempArray, 'd');
        }

        private void TopFaceInverse()
        {
            char[] TempArray = new char[3];
            Top.RotateFace('l');
            Back.GetEdge('u').CopyTo(TempArray, 0);
            Back.CopyToEdge(Right.GetEdge('u'), 'u');
            Right.CopyToEdge(Front.GetEdge('u'), 'u');
            Front.CopyToEdge(Left.GetEdge('u'), 'u');
            Left.CopyToEdge(TempArray, 'u');
        }

        private void TopFace()
        {
            char[] TempArray = new char[3];
            Top.RotateFace('r');
            Back.GetEdge('u').CopyTo(TempArray, 0);
            Back.CopyToEdge(Left.GetEdge('u'), 'u');
            Left.CopyToEdge(Front.GetEdge('u'), 'u');
            Front.CopyToEdge(Right.GetEdge('u'), 'u');
            Right.CopyToEdge(TempArray, 'u');
        }

        private void BackFaceInverse()
        {
            char[] TempArray = new char[3];
            Back.RotateFace('l');
            Top.GetEdge('u').CopyTo(TempArray, 0);
            Top.CopyToEdgeReverse(Left.GetEdge('l'), 'u');
            Left.CopyToEdgeReverse(Bottom.GetEdge('u'), 'l');
            Bottom.CopyToEdge(Right.GetEdge('r'), 'u');
            Right.CopyToEdge(TempArray, 'r');
        }

        private void BackFace()
        {
            char[] TempArray = new char[3];
            Back.RotateFace('r');
            Top.GetEdge('u').CopyTo(TempArray, 0);
            Top.CopyToEdge(Right.GetEdge('r'), 'u');
            Right.CopyToEdge(Bottom.GetEdge('u'), 'r');
            Bottom.CopyToEdgeReverse(Left.GetEdge('l'), 'u');
            Left.CopyToEdgeReverse(TempArray, 'l');
        }

        private void MoveCubeRight()
        {
            var temp = Top;
            Top = Left.GetRotatedFace('r');
            Left = Bottom.GetRotatedFace('l');
            Bottom = Right.GetRotatedFace('r');
            Right = temp.GetRotatedFace('r');
            Front.RotateFace('r');
            Back.RotateFace('l');
        }
        private void MoveCubeLeft()
        {
            var temp = Top;
            Top = Right.GetRotatedFace('l');
            Right = Bottom.GetRotatedFace('r');
            Bottom = Left.GetRotatedFace('l');
            Left = temp.GetRotatedFace('l');
            Front.RotateFace('l');
            Back.RotateFace('r');
        }

        private void MoveCubeTop()
        {
            var temp = Back;
            Back = Top.Reverse();
            Top = Front;
            Front = Bottom.Reverse();
            Bottom = temp;
            Right.RotateFace('r');
            Left.RotateFace('l');
        }

        private void MoveCubeBottom()
        {
            var temp = Back;
            Back = Bottom;
            Bottom = Front.Reverse();
            Front = Top;
            Top = temp.Reverse();
            Right.RotateFace('l');
            Left.RotateFace('r');
        }

        private void FrontFace()
        {
            char[] TempArray = new char[3];
            Front.RotateFace('r');
            Top.GetEdge('u').CopyTo(TempArray, 0);
            Top.CopyToEdgeReverse(Left.GetEdge('r'), 'd');
            Left.CopyToEdgeReverse(Bottom.GetEdge('d'), 'r');
            Bottom.CopyToEdge(Right.GetEdge('l'), 'd');
            Right.CopyToEdge(TempArray, 'l');
        }

        private void FrontFaceInverse()
        {
            var TempArray = new char[3];
            Front.RotateFace('l');
            Top.GetEdge('d').CopyTo(TempArray, 0);
            Top.CopyToEdge(Right.GetEdge('l'), 'd');
            Right.CopyToEdge(Bottom.GetEdge('d'), 'l');
            Bottom.CopyToEdgeReverse(Left.GetEdge('r'), 'd');
            Left.CopyToEdgeReverse(TempArray, 'r');
        }




        /// <summary>
        /// Returns an array of bi-dimensional arrays where every elements is the content of the Faces
        /// </summary>
        public List<CubeFace> Get()
        {
            var list = new List<CubeFace>();
            list.Add(Top);
            list.Add(Left);
            list.Add(Front);
            list.Add(Right);
            list.Add(Bottom.GetReverse());
            list.Add(Back.GetReverse());
            return list;
        }


        /// <summary>
        /// Rotate a face of the cube with his adjacent edges
        ///
        /// </summary>
        /// <param name="Face">f = Front, b = Back, u = Top, d = Bottom, r = Right, l = Left</param>
        /// <param name="direction">r = Right, l = Left</param>
        public void RotateFace(Faces Face, Direction direction)
        {
            char[] TempArray = new char[3];


            //MovementDictionary[direction].Invoke(1);

            //Rotation to the right
            //first, it will rotate the face calling the RotateFace Method from the CubeFace class,
            //then it will rotate the edges that are adjacent to the cube
            if (direction == Direction.FaceRight)
            {



                switch (Face)
                {
                    // Front Face Rotation
                    case Faces.Front:
                        {
                            //Done
                            Front.RotateFace('r');
                            Top.GetEdge('u').CopyTo(TempArray, 0);
                            Top.CopyToEdgeReverse(Left.GetEdge('r'), 'd');
                            Left.CopyToEdgeReverse(Bottom.GetEdge('d'), 'r');
                            Bottom.CopyToEdge(Right.GetEdge('l'), 'd');
                            Right.CopyToEdge(TempArray, 'l');
                            break;
                        }
                    //Back Face Rotation
                    case Faces.Back:
                        {
                            //Done
                            Back.RotateFace('r');
                            Top.GetEdge('u').CopyTo(TempArray, 0);
                            Top.CopyToEdge(Right.GetEdge('r'), 'u');
                            Right.CopyToEdge(Bottom.GetEdge('u'), 'r');
                            Bottom.CopyToEdgeReverse(Left.GetEdge('l'), 'u');
                            Left.CopyToEdgeReverse(TempArray, 'l');
                            break;
                        }
                    //Top Face Rotation
                    case Faces.Top:
                        {
                            //done
                            Top.RotateFace('r');
                            Back.GetEdge('u').CopyTo(TempArray, 0);
                            Back.CopyToEdge(Left.GetEdge('u'), 'u');
                            Left.CopyToEdge(Front.GetEdge('u'), 'u');
                            Front.CopyToEdge(Right.GetEdge('u'), 'u');
                            Right.CopyToEdge(TempArray, 'u');
                            break;
                        }
                    //Bottom Face Rotation
                    case Faces.Bottom:
                        {
                            //done
                            Bottom.RotateFace('r');
                            Back.GetEdge('d').CopyTo(TempArray, 0);
                            Back.CopyToEdge(Right.GetEdge('d'), 'd');
                            Right.CopyToEdge(Front.GetEdge('d'), 'd');
                            Front.CopyToEdge(Left.GetEdge('d'), 'd');
                            Left.CopyToEdge(TempArray, 'd');
                            break;

                        }
                    //Right Face Rotation
                    case Faces.Right:
                        {
                            //done
                            Right.RotateFace('r');
                            Top.GetEdge('r').CopyTo(TempArray, 0);
                            Top.CopyToEdge(Front.GetEdge('r'), 'r');
                            Front.CopyToEdgeReverse(Bottom.GetEdge('l'), 'r');
                            Bottom.CopyToEdge(Back.GetEdge('l'), 'l');
                            Back.CopyToEdgeReverse(TempArray, 'l');
                            break;
                        }
                    //Left Face Rotation
                    case Faces.Left:
                        {
                            //done
                            Left.RotateFace('r');
                            Top.GetEdge('l').CopyTo(TempArray, 0);
                            Top.CopyToEdgeReverse(Back.GetEdge('r'), 'l');
                            Back.CopyToEdge(Bottom.GetEdge('r'), 'r');
                            Bottom.CopyToEdgeReverse(Front.GetEdge('l'), 'r');
                            Front.CopyToEdge(TempArray, 'l');
                            break;
                        }
                    //Wrong input
                    default:
                        {
                            Console.WriteLine("Not a valid Movement");
                            break;
                        }
                }
            }
            //Rotation to the left
            //first, it will rotate the face calling the RotateFace Method from the CubeFace class,
            //then it will rotate the edges that are adjacent to the cube
            else if (direction == Direction.FaceLeft)
            {
                switch (Face)
                {
                    //Front Face Rotation
                    case Faces.Front:
                        {
                            Front.RotateFace('l');
                            Top.GetEdge('d').CopyTo(TempArray, 0);
                            Top.CopyToEdge(Right.GetEdge('l'), 'd');
                            Right.CopyToEdge(Bottom.GetEdge('d'), 'l');
                            Bottom.CopyToEdgeReverse(Left.GetEdge('r'), 'd');
                            Left.CopyToEdgeReverse(TempArray, 'r');
                            break;
                        }
                    //Back Face Rotation
                    case Faces.Back:
                        {
                            Back.RotateFace('l');
                            Top.GetEdge('u').CopyTo(TempArray, 0);
                            Top.CopyToEdgeReverse(Left.GetEdge('l'), 'u');
                            Left.CopyToEdgeReverse(Bottom.GetEdge('u'), 'l');
                            Bottom.CopyToEdge(Right.GetEdge('r'), 'u');
                            Right.CopyToEdge(TempArray, 'r');

                            break;
                        }
                    //Top Face Rotation
                    case Faces.Top:
                        {
                            Top.RotateFace('l');
                            Back.GetEdge('u').CopyTo(TempArray, 0);
                            Back.CopyToEdge(Right.GetEdge('u'), 'u');
                            Right.CopyToEdge(Front.GetEdge('u'), 'u');
                            Front.CopyToEdge(Left.GetEdge('u'), 'u');
                            Left.CopyToEdge(TempArray, 'u');
                            break;
                        }
                    //Bottom Face Rotation
                    case Faces.Bottom:
                        {
                            Bottom.RotateFace('l');
                            Back.GetEdge('d').CopyTo(TempArray, 0);
                            Back.CopyToEdge(Left.GetEdge('d'), 'd');
                            Left.CopyToEdge(Front.GetEdge('d'), 'd');
                            Front.CopyToEdge(Right.GetEdge('d'), 'd');
                            Right.CopyToEdge(TempArray, 'd');
                            break;

                        }
                    //Right Face Rotation
                    case Faces.Right:
                        {
                            Right.RotateFace('l');
                            Top.GetEdge('r').CopyTo(TempArray, 0);
                            Top.CopyToEdgeReverse(Back.GetEdge('l'), 'r');
                            Back.CopyToEdge(Bottom.GetEdge('l'), 'l');
                            Bottom.CopyToEdgeReverse(Front.GetEdge('r'), 'l');
                            Front.CopyToEdge(TempArray, 'r');
                            break;
                        }
                    //Left Face Rotation
                    case Faces.Left:
                        {
                            Left.RotateFace('l');
                            Top.GetEdge('l').CopyTo(TempArray, 0);
                            Top.CopyToEdge(Front.GetEdge('l'), 'l');
                            Front.CopyToEdgeReverse(Bottom.GetEdge('r'), 'l');
                            Bottom.CopyToEdge(Back.GetEdge('r'), 'r');
                            Back.CopyToEdgeReverse(TempArray, 'r');
                            break;
                        }
                    //Wrong input
                    default:
                        {
                            Console.WriteLine("Not a valid movement");
                            break;
                        }
                }

            }
            //Wrong input
            else
                Console.Write("Invalid movement");

        }
        ///// <summary>
        /// Rotate the cube to set a new face as a front face
        /// </summary>
        /// <param name="direction"></param>
        public void RotateCube(char direction)
        {
            //What happen to the faces when the cube rotates? 
            //Does the edges also change? (most probably yes),
            //How make the uotput understanable without 
            switch (direction)
            {
                //Cube Rotation up
                case 'u':
                    {
                        var temp = Back;
                        Back = Top.Reverse();
                        Top = Front;
                        Front = Bottom.Reverse();
                        Bottom = temp;
                        Right.RotateFace('r');
                        Left.RotateFace('l');
                        break;
                    }
                //Cube Rotation Down
                case 'd':
                    {
                        var temp = Back;
                        Back = Bottom;
                        Bottom = Front.Reverse();
                        Front = Top;
                        Top = temp.Reverse();
                        Right.RotateFace('l');
                        Left.RotateFace('r');
                        break;
                    }
                //Cube Rotation Left
                case 'l':
                    {
                        var temp = Top;
                        Top = Right.GetRotatedFace('l');
                        Right = Bottom.GetRotatedFace('r');
                        Bottom = Left.GetRotatedFace('l');
                        Left = temp.GetRotatedFace('l');
                        Front.RotateFace('l');
                        Back.RotateFace('r');
                        break;

                    }
                //Cube Rotation Right
                case 'r':
                    {
                        var temp = Top;
                        Top = Left.GetRotatedFace('r');
                        Left = Bottom.GetRotatedFace('l');
                        Bottom = Right.GetRotatedFace('r');
                        Right = temp.GetRotatedFace('r');
                        Front.RotateFace('r');
                        Back.RotateFace('l');
                        break;
                    }
                //Wrong input
                default:
                    {
                        break;
                    }
            }
        }

    }


}
//This method was replaced by CubeFace.Reverse()

///// <summary>
///// Returns a Cube face Upside down
///// </summary>
///// <param name="original">Cube face to be reverted</param>
///// <returns>original CubeFace Upside down</returns>
//public CubeFace ReverseFace(CubeFace original)
//{
//    var result = new CubeFace('t');
//    var temporal1 = new char[3];
//    var temporal2 = new char[3];
//    Array.Copy(original.GetEdge('u'), temporal1, original.GetEdge('u').Length);
//    Array.Copy(original.GetEdge('d'), temporal2, original.GetEdge('d').Length);
//    Array.Reverse(temporal1);
//    Array.Reverse(temporal2);
//    Array.Copy(temporal1, result.GetEdge('d'), result.GetEdge('d').Length);
//    Array.Copy(temporal2, result.GetEdge('u'), result.GetEdge('u').Length);
//    Array.Copy(original.GetEdge('r'), temporal1, original.GetEdge('r').Length);
//    Array.Copy(original.GetEdge('l'), temporal2, original.GetEdge('l').Length);
//    Array.Reverse(temporal1);
//    Array.Reverse(temporal2);
//    Array.Copy(temporal1, result.GetEdge('l'), result.GetEdge('l').Length);
//    Array.Copy(temporal2, result.GetEdge('r'), result.GetEdge('r').Length);
//    result.FaceColor = original.FaceColor;
//    return result;
//}
