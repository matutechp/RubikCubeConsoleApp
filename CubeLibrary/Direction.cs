public enum Direction
{
    //Face Rotation
    FrontFaceInverse, 
    FrontFace, 
    BackFace,
    BackFaceInverse,
    TopFace,
    TopFaceInverse,
    RightFace,
    RightFaceInverse,
    LeftFace,
    LeftFaceInverse,
    BottomFace,
    BottomFaceInverse,


    //Two Layers at the same time
    DoubleUp,
    DoubleUpInverse,
    DoubleDown,
    DoubleDownInverse,
    DoubleLeft,
    DoubleLeftInverse,
    DoubleRight,
    DoubleRightInverse,
    DoubleFront,
    DoubleFrontInverse,
    DoubleBack,
    DoubleBackInverse,

    //Slices Turns
    FrontMiddleDown,
    FrontMiddleUp,
    FrontMiddleLeft,
    FrontMiddleRight,
    TopMiddleRight,
    TopMiddleLeft,

    //Whole Cube Reprientation
    CubeLeft,
    CubeRight,
    CubeTop,
    CubeBottom,
    CubeZPlane,
    CubeZPlaneInverse,

    //Cube Face Movement
    FaceLeft = 'l',
    FaceRight = 'r'
}
