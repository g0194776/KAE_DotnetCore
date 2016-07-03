namespace KJFramework.EventArgs
{
    /// <summary>
    ///     ����ƶ��¼�
    /// </summary>
    public class MouseMoveEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     ����ƶ��¼�
        /// </summary>
        /// <param name="x">X������</param>
        /// <param name="y">Y������</param>
        public MouseMoveEventArgs(double x, double y)
        {
            Y = y;
            X = x;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     X������
        /// </summary>
        public double X { get; set; }
        /// <summary>
        ///     Y������
        /// </summary>
        public double Y { get; set; }

        #endregion

    }
}