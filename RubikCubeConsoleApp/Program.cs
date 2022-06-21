using CubeLibrary;
using System;

namespace RubikCubeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var SuperCube = new RubikCube();
            PrintCube(SuperCube);
            Console.ReadLine();
            Console.Clear();
            TestFaceRotation(SuperCube);
            Console.ReadLine();



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
