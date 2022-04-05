using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLibrary
{
    public class CubeFace
    {
        char FaceColor;
        char[] UpEdge = new char[3];
        char[] DownEdge = new char[3];
        char[] RightEdge = new char[3];
        char[] LeftEdge = new char[3];

        /// <summary>
        /// Generate a Face of the cube full with only one color 
        /// Color is represented by one character
        /// </summary>
        /// <param name="faceColor"></param>
        public CubeFace(char faceColor)
        {
            FaceColor = faceColor;
            for (int i = 0; i < 3; i++)
            {
                UpEdge[i] = FaceColor;
                DownEdge[i] = FaceColor;
                RightEdge[i] = FaceColor;
                LeftEdge[i] = FaceColor;
            }
            //Assinging values to check the movement of the faces

            //FaceColor = '5';
            //upedge[0] = '1';
            //upedge[1] = '2';
            //upedge[2] = '3';
            //leftedge[0] = '1';
            //leftedge[1] = '4';
            //leftedge[2] = '7';
            //rightedge[0] = '3';
            //rightedge[1] = '6';
            //rightedge[2] = '9';
            //downedge[0] = '7';
            //downedge[1] = '8';
            //downedge[2] = '9';

        }
        /// <summary>
        /// Array[3,3] that represent the face
        /// </summary>
        /// <returns>result</returns>
        public char[,] GetFace()
        {
            var result = new char[3,3];
            for (int i = 0; i < 3; i++)
            {
                result[0, i] = UpEdge[i];
                result[2, i] = DownEdge[i];
            }
            result[1,0] = LeftEdge[1];
            result[1,1] = FaceColor;
            result[1,2] = RightEdge[1];
            return result;

        }
        /// <summary>
        /// Return a char[3] with the content of the Edge that is specify
        /// </summary>
        /// <param name="Edge"></param>
        /// <returns>u = Up, r = Right, l = left, d = Down</returns>
        public char[] GetEdge(char Edge)
        {
            switch (Edge)
            {
                case 'u':
                    return UpEdge;
                case 'r':
                    return RightEdge;
                case 'l':
                    return LeftEdge;
                case 'd':
                    return DownEdge;
                default:
                    return null;
            }
        }
        /// <summary>
        /// Copy the SourceArray on the face.Edge array and update values in the rest of the Edges arrays
        /// </summary>
        /// <param name="SourceArray">Source Array</param>
        /// <param name="Edge">u = Up, d = Down, l = Left, r = Right</param>
        public void CopyToEdge(char[] SourceArray, char Edge)
        {
            switch(Edge)
            {
                case 'u':
                    {
                        Array.Copy(SourceArray, UpEdge, SourceArray.Length);
                        LeftEdge[0] = UpEdge[0];
                        RightEdge[0] = UpEdge[2];
                        break;   
                    }
                case 'd':
                    {
                        Array.Copy(SourceArray, DownEdge, SourceArray.Length);
                        LeftEdge[2] = DownEdge[0];
                        RightEdge[2] = DownEdge[2];
                        
                        break;   
                    }
                case 'l':
                    {
                        Array.Copy(SourceArray, LeftEdge, SourceArray.Length);
                        UpEdge[0] = LeftEdge[0];
                        DownEdge[0] = LeftEdge[2];

                        break;   
                    }
                case 'r':
                    {
                        Array.Copy(SourceArray, RightEdge, SourceArray.Length);
                        UpEdge[2] = RightEdge[0];
                        DownEdge[2] = RightEdge[2];

                        break;   
                    }
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
        }
        /// <summary>
        /// Copy the SourceArray on the face.Edge array
        /// </summary>
        /// <param name="SourceArray"></param>
        /// <param name="Edge">u = Up, d = Down, l = Left, r = Right</param>

        public void CopyToEdgeReverse(char[] SourceArray, char Edge)
        {
            Array.Reverse(SourceArray);
            CopyToEdge(SourceArray, Edge);
        }

        /// <summary>
        /// Rotare the face in a direction
        /// </summary>
        /// <param name="Direction">l = Left, r = Right</param>
        public void RotateFace(char Direction)
        {
            char[] TempArray = new char[3];
            Array.Copy(UpEdge, TempArray, UpEdge.Length);
            switch (Direction)
            {
                //Direction = 'r' to rotate to the right
                //some arrays need to be reversed to match the rotation motion from the face
                case 'r':
                    {
                        Array.Reverse(LeftEdge);
                        Array.Copy(LeftEdge, UpEdge, LeftEdge.Length);
                        Array.Copy(DownEdge, LeftEdge, DownEdge.Length);
                        Array.Reverse(RightEdge);
                        Array.Copy(RightEdge, DownEdge, RightEdge.Length);
                        Array.Copy(TempArray, RightEdge, TempArray.Length);
                        break;
                    }
                //Direction = 'l' to rotate to the left
                //Some arrays need to be reversed to match the rotation motion from the face
                case 'l':
                    {
                       Array.Copy(RightEdge,UpEdge, RightEdge.Length);
                       Array.Reverse(DownEdge);
                       Array.Copy(DownEdge,RightEdge, DownEdge.Length);
                       Array.Copy(LeftEdge,DownEdge, LeftEdge.Length);
                       Array.Reverse(TempArray);
                       Array.Copy(TempArray,LeftEdge, TempArray.Length);
                       break;
                    }
            }
                

        }
    }
}
