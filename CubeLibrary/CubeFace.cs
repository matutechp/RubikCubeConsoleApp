using System;
using System.Collections.Generic;
using System.Linq;

namespace CubeLibrary
{
    public class CubeFace
    {
        private Dictionary<char, Action<char[]>> RotateEdge = new Dictionary<char, Action<char[]>>();

        private char faceColor;

        private char GetFaceColor()
        {
            return faceColor;
        }

        private void SetFaceColor(char value)
        {
            faceColor = value;
        }

        char[] UpEdge = new char[3];
        char[] DownEdge = new char[3];
        char[] RightEdge = new char[3];
        char[] LeftEdge = new char[3];

        public char FaceColor { get { return GetFaceColor(); } set { SetFaceColor(value); } }

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

            BuildRotateEdgeDictionary();

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


        private void BuildRotateEdgeDictionary()
        {
            RotateEdge.Add('r', RotateFaceToTheRight);
            RotateEdge.Add('l', RotateFaceToLeft);
        }

        /// <summary>
        /// Array[3,3] that represent the face
        /// </summary>
        /// <returns>result</returns>
        public char[,] GetFace()
        {
            var result = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                result[0, i] = UpEdge[i];
                result[2, i] = DownEdge[i];
            }
            result[1, 0] = LeftEdge[1];
            result[1, 1] = GetFaceColor();
            result[1, 2] = RightEdge[1];
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
            switch (Edge)
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
            var tempArray = UpEdge;
            RotateEdge[Direction](tempArray);
        }

        public CubeFace GetRotatedFace(char Direction)
        {
            var tempFace = this;
            var tempArray = tempFace.UpEdge;
            tempFace.RotateEdge[Direction](tempArray);
            return tempFace;
        }

        private void RotateFaceToLeft(char[] tempArray)
        {
            UpEdge = RightEdge;
            RightEdge = DownEdge.Reverse().ToArray();
            DownEdge = LeftEdge;
            LeftEdge = tempArray.Reverse().ToArray();
        }

        private void RotateFaceToTheRight(char[] tempArray)
        {
            UpEdge = LeftEdge.Reverse().ToArray();
            LeftEdge = DownEdge;
            DownEdge = RightEdge.Reverse().ToArray();
            RightEdge = tempArray;
        }

        public CubeFace Reverse()
        {
            this.RotateFace('r');
            this.RotateFace('l');
            return this;
        }

       public CubeFace GetReverse()
        {

            var result = new CubeFace('t');
            var temporal1 = new char[3];
            var temporal2 = new char[3];
            Array.Copy(this.GetEdge('u'), temporal1, this.GetEdge('u').Length);
            Array.Copy(this.GetEdge('d'), temporal2, this.GetEdge('d').Length);
            Array.Reverse(temporal1);
            Array.Reverse(temporal2);
            Array.Copy(temporal1, result.GetEdge('d'), result.GetEdge('d').Length);
            Array.Copy(temporal2, result.GetEdge('u'), result.GetEdge('u').Length);
            Array.Copy(this.GetEdge('r'), temporal1, this.GetEdge('r').Length);
            Array.Copy(this.GetEdge('l'), temporal2, this.GetEdge('l').Length);
            Array.Reverse(temporal1);
            Array.Reverse(temporal2);
            Array.Copy(temporal1, result.GetEdge('l'), result.GetEdge('l').Length);
            Array.Copy(temporal2, result.GetEdge('r'), result.GetEdge('r').Length);
            result.FaceColor = this.FaceColor;
            return result;


        }


        ///// <summary>
        ///// Copy the Source Face into the Destination Face
        ///// </summary>
        ///// <param name="SourceCubeFace"></param>
        ///// <param name="DestinationCubeFace"></param>
        //public static CubeFace operator= (CubeFace SourceCubeFace)
        //{
        //    var DestinationCubeFace = new CubeFace('t');
        //    DestinationCubeFace.FaceColor = SourceCubeFace.FaceColor;
        //    for (int i = 0; i < SourceCubeFace.UpEdge.Length; i++)
        //    {
        //        DestinationCubeFace.UpEdge[i] = SourceCubeFace.UpEdge[i];
        //        DestinationCubeFace.RightEdge[i] = SourceCubeFace.RightEdge[i];
        //        DestinationCubeFace.LeftEdge[i] = SourceCubeFace.LeftEdge[i];
        //        DestinationCubeFace.DownEdge[i] = SourceCubeFace.DownEdge[i];
        //        return DestinationCubeFace;

        //    }
        //}
    }
}
