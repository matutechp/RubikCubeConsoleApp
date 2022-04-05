using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLibrary
{
    public class RubikCube
    {
       
        public CubeFace Front { get; }
        public CubeFace Back { get; }
        public CubeFace Top { get; }
        public CubeFace Bottom { get; }
        public CubeFace Left { get; }
        public CubeFace Right { get; }

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
            list.Add(Bottom);
            list.Add(Back);
            return list;
        }


        /// <summary>
        /// Rotate a face of the cube with his adjacent edges
        ///
        /// </summary>
        /// <param name="Face">f = Front, b = Back, u = Top, d = Bottom, r = Right, l = Left</param>
        /// <param name="direction">r = Right, l = Left</param>
        public void RotateFace(char Face, char direction)
        {
            char[] TempArray = new char[3];
            //Rotation to the right
            //first, it will rotate the face calling the RotateFace Method from the CubeFace class,
            //then it will rotate the edges that are adjacent to the cube
            if (direction == 'r')
            {
                switch (Face)
                {
                    // Front Face Rotation
                    case 'f':
                        {
                            Front.RotateFace('r');
                            Array.Copy(Top.GetEdge('d'), TempArray, Top.GetEdge('d').Length);
                            Top.CopyToEdgeReverse(Left.GetEdge('r'), 'd');
                            Left.CopyToEdgeReverse(Bottom.GetEdge('d'), 'r');
                            Bottom.CopyToEdge(Right.GetEdge('l'), 'd');
                            Right.CopyToEdge(TempArray,'l');
                            break;
                        }
                    //Back Face Rotation
                    case 'b':
                        {
                            Back.RotateFace('r');
                            Array.Copy(Top.GetEdge('u'), TempArray, Top.GetEdge('u').Length);
                            Top.CopyToEdge(Right.GetEdge('r'), 'u');
                            Right.CopyToEdge(Bottom.GetEdge('u'), 'r');
                            Bottom.CopyToEdgeReverse(Left.GetEdge('l'), 'u');
                            Left.CopyToEdgeReverse(TempArray, 'l');
                            break;
                        }
                    //Top Face Rotation
                    case 'u':
                        {
                            Top.RotateFace('r');
                            Array.Copy(Back.GetEdge('u'), TempArray, Back.GetEdge('u').Length);
                            Back.CopyToEdge(Left.GetEdge('u'), 'u');
                            Left.CopyToEdge(Front.GetEdge('u'), 'u');
                            Front.CopyToEdge(Right.GetEdge('u'), 'u');
                            Right.CopyToEdge(TempArray, 'u');
                            break;
                        }
                    //Bottom Face Rotation
                    case 'd':
                        {
                            Bottom.RotateFace('r');
                            Array.Copy(Back.GetEdge('d'), TempArray, Back.GetEdge('d').Length);
                            Back.CopyToEdge(Right.GetEdge('d'), 'd');
                            Right.CopyToEdge(Front.GetEdge('d'), 'd');
                            Front.CopyToEdge(Left.GetEdge('d'), 'd');
                            Left.CopyToEdge(TempArray, 'd');
                            break;

                        }
                    //Right Face Rotation
                    case 'r':
                        {
                            Right.RotateFace('r');
                            Array.Copy(Top.GetEdge('r'), TempArray, Top.GetEdge('r').Length);
                            Top.CopyToEdge(Front.GetEdge('r'), 'r');
                            Front.CopyToEdgeReverse(Bottom.GetEdge('l'), 'r');
                            Bottom.CopyToEdge(Back.GetEdge('l'), 'l');
                            Back.CopyToEdgeReverse(TempArray,'r');
                            break;
                        }
                    //Left Face Rotation
                    case 'l':
                        {
                            Left.RotateFace('r');
                            Array.Copy(Top.GetEdge('l'), TempArray, Top.GetEdge('l').Length);
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
            else if (direction == 'l')
            {
                switch (Face)
                {
                    //Front Face Rotation
                    case 'f':
                        {
                            Front.RotateFace('l');
                            Array.Copy(Top.GetEdge('u'), TempArray, Top.GetEdge('u').Length);
                            Top.CopyToEdge(Right.GetEdge('l'), 'd');
                            Right.CopyToEdge(Bottom.GetEdge('u'), 'l');
                            Bottom.CopyToEdgeReverse(Left.GetEdge('r'), 'd');
                            Left.CopyToEdgeReverse(TempArray, 'r');
                            break;
                        }
                    //Back Face Rotation
                    case 'b':
                        {
                            Back.RotateFace ('l');
                            Array.Copy(Top.GetEdge('u'), TempArray, Top.GetEdge('u').Length);
                            Top.CopyToEdgeReverse(Left.GetEdge('l'), 'u');
                            Left.CopyToEdgeReverse(Bottom.GetEdge('u'), 'r');
                            Bottom.CopyToEdge(Right.GetEdge('r'), 'u');
                            Right.CopyToEdge(TempArray, 'r');

                            break;
                        }
                    //Top Face Rotation
                    case 'u':
                        {
                            Top.RotateFace('l');
                            Array.Copy(Back.GetEdge('u'), TempArray, Back.GetEdge('u').Length);
                            Back.CopyToEdge(Right.GetEdge('u'), 'u');
                            Right.CopyToEdge(Front.GetEdge('u'), 'u');
                            Front.CopyToEdge(Left.GetEdge('u'), 'u');
                            Left.CopyToEdge(TempArray, 'u');
                            break;
                        }
                    //Bottom Face Rotation
                    case 'd':
                        {
                            Bottom.RotateFace ('l');
                            Array.Copy(Back.GetEdge('d'), TempArray, Back.GetEdge('d').Length);
                            Back.CopyToEdge(Left.GetEdge('d'), 'd');
                            Left.CopyToEdge(Front.GetEdge('d'), 'd');
                            Front.CopyToEdge(Right.GetEdge('d'), 'd');
                            Right.CopyToEdge(TempArray, 'd');
                            break;

                        }
                    //Right Face Rotation
                    case 'r':
                        {
                            Right.RotateFace('l');
                            Array.Copy(Top.GetEdge('r'), TempArray, Top.GetEdge('r').Length);
                            Top.CopyToEdgeReverse(Back.GetEdge('l'), 'r');
                            Back.CopyToEdge(Bottom.GetEdge('l'), 'l');
                            Bottom.CopyToEdgeReverse(Front.GetEdge('r'), 'l');
                            Front.CopyToEdge(TempArray, 'r');
                            break;
                        }
                    //Left Face Rotation
                    case 'l':
                        {
                            Left.RotateFace('l');
                            Array.Copy(Top.GetEdge('l'), TempArray, Top.GetEdge('l').Length);
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
        /// <summary>
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
                        break;
                    }
                //Cube Rotation Down
                case 'd':
                    {
                        break;
                    }
                //Cube Rotation Left
                case 'l':
                    {
                        break;;

                    }
                //Cube Rotation Right
                case 'r':
                    {
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
