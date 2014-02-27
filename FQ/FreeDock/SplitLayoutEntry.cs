namespace FQ.FreeDock
{
    struct SplitLayoutEntry
    {
        public SplitLayoutSystem SplitLayoutSystem;
        public int Index;
        public SplitLayoutEntry(SplitLayoutSystem splitLayout, int index)
        {
            this.SplitLayoutSystem = splitLayout;
            this.Index = index;
        }
    }
}
