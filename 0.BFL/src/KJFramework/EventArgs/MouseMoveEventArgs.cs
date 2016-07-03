namespace KJFramework.EventArgs
{
    /// <summary>
    ///     鼠标移动事件
    /// </summary>
    public class MouseMoveEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     鼠标移动事件
        /// </summary>
        /// <param name="x">X轴坐标</param>
        /// <param name="y">Y轴坐标</param>
        public MouseMoveEventArgs(double x, double y)
        {
            Y = y;
            X = x;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     X轴坐标
        /// </summary>
        public double X { get; set; }
        /// <summary>
        ///     Y轴坐标
        /// </summary>
        public double Y { get; set; }

        #endregion

    }
}