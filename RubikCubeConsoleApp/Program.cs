using CubeLibrary;
using System;
using System.Collections.Generic;

namespace RubikCubeConsoleApp
{
    internal class Program
    {

        public  static Dictionary<string, Direction> NotationDictionary { get; private set; }

        static void Main(string[] args)
        {
            BuildDictionaryNotation();

            var SuperCube = new RubikCube();
            PrintCube(SuperCube);
            Console.ReadLine();
            Console.Clear();
            //TestFaceRotation(SuperCube);
            FaceRotationWithNotation(SuperCube);
            //Console.ReadLine();



        }

        private static  void BuildDictionaryNotation()
        {
            NotationDictionary = new Dictionary<string, Direction>();

            //Face rotations
            NotationDictionary.Add("F", Direction.FrontFace);
            NotationDictionary.Add("F'", Direction.FrontFaceInverse);
            NotationDictionary.Add("R", Direction.RightFace);
            NotationDictionary.Add("R'", Direction.RightFaceInverse);
            NotationDictionary.Add("L", Direction.LeftFace);
            NotationDictionary.Add("L'", Direction.LeftFaceInverse);
            NotationDictionary.Add("U", Direction.TopFace);
            NotationDictionary.Add("U'", Direction.TopFaceInverse);
            NotationDictionary.Add("D", Direction.BottomFace);
            NotationDictionary.Add("D'", Direction.BottomFaceInverse);
            NotationDictionary.Add("B", Direction.BackFace);
            NotationDictionary.Add("B'", Direction.BackFaceInverse);

            //Two layers at the same time
            NotationDictionary.Add("u", Direction.DoubleUp);
            NotationDictionary.Add("u'", Direction.DoubleUpInverse);
            NotationDictionary.Add("r", Direction.DoubleRight);
            NotationDictionary.Add("r'", Direction.DoubleRightInverse);
            NotationDictionary.Add("f", Direction.DoubleFront);
            NotationDictionary.Add("f'", Direction.DoubleFrontInverse);
            NotationDictionary.Add("d", Direction.DoubleDown);
            NotationDictionary.Add("d'", Direction.DoubleDownInverse);
            NotationDictionary.Add("l", Direction.DoubleLeft);
            NotationDictionary.Add("l'", Direction.DoubleLeftInverse);
            NotationDictionary.Add("b", Direction.DoubleBack);
            NotationDictionary.Add("b'", Direction.DoubleBackInverse);

            //Slices Turns
            NotationDictionary.Add("M", Direction.FrontMiddleDown);
            NotationDictionary.Add("M'", Direction.FrontMiddleUp);
            NotationDictionary.Add("E", Direction.FrontMiddleRight);
            NotationDictionary.Add("E'", Direction.FrontMiddleLeft);
            NotationDictionary.Add("S", Direction.TopMiddleRight);
            NotationDictionary.Add("S'", Direction.TopMiddleLeft);

            //Whole Cube Reorientation


        }

        private static void FaceRotationWithNotation(RubikCube cube)
        {
            string movement;
            while (Console.ReadLine() != "end")
            {
                Console.WriteLine("Insert movement");
                movement = Console.ReadLine();
                Console.WriteLine("Making move notation {0}", movement);
                cube.MovementDictionary[NotationDictionary[movement]].Invoke();
                PrintCube(cube);


            }
        }
        private static void TestFaceRotation(RubikCube Cube)
        {
            var TestCube = Cube;
            char Face = 'a';
            char Direction = 'a';
            while (Face != 'e')
            {
                Console.Write("Insert face to rotate: ");
                Face = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                Console.Write("Insert the direction that the Face will be rotating: ");
                Direction = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                Console.WriteLine("Rotating Face {0} to the {1}", Face, Direction);
                TestCube.RotateFace((Faces)Face, (Direction)Direction);
                PrintCube(TestCube);
            }

        }

        private static void PrintCubeFace(CubeFace cubeFace)
        {
            char[,] face;
            face = cubeFace.GetFace();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("-------");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|" + face[i, j]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("-------");
            return;
        }

        private static void PrintFloattingFace(CubeFace FloattingFace)
        {
            char[,] face = FloattingFace.GetFace();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("       -------");
                Console.Write("       ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|" + face[i, j]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("       -------");
        }

        private static void PrintAdyacentFaces(CubeFace Face1, CubeFace Face2, CubeFace Face3)
        {
            char[,] RightFace = Face1.GetFace();
            char[,] FrontFace = Face2.GetFace();
            char[,] LeftFace = Face3.GetFace();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("---------------------");
                for (int r = 0; r < 3; r++)
                {
                    Console.Write("|" + RightFace[i, r]);
                }
                Console.Write("|");
                for (int f = 0; f < 3; f++)
                {
                    Console.Write("|" + FrontFace[i, f]);
                }
                Console.Write("|");
                for (int l = 0; l < 3; l++)
                {
                    Console.Write("|" + LeftFace[i, l]);
                }
                Console.WriteLine("|");
                Console.WriteLine("---------------------");
            }
        }

        private static void PrintCube(RubikCube FullCube)
        {
            var Cube = FullCube.Get();
            PrintFloattingFace(Cube[0]);
            PrintAdyacentFaces(Cube[1], Cube[2], Cube[3]);
            PrintFloattingFace(Cube[4]);
            PrintFloattingFace(Cube[5]);
        }
    }
}
