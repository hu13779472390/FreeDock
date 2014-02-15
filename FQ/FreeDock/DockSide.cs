namespace FQ.FreeDock
{
    /// <summary>
    /// A side of a DockControl to potentially dock an object to.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// When None is used, the object is docked alongside the DockControl with tabs displayed to choose between them.
    /// </para>
    /// 
    /// </remarks>
    public enum DockSide
    {
        Top,
        Bottom,
        Left,
        Right,
        None,
    }
}
