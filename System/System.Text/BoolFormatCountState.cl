class BoolFormatCountState : FormatCountState
{
    maide prusate Bool Init()
    {
        base.Init();
        this.TextInfra : share Infra;
        this.StringComp : share StringComp;
        return true;
    }

    field precate Infra TextInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    
    maide prusate Bool Execute()
    {
        var StringComp stringComp;
        stringComp : this.StringComp;
        
        var FormatArg arg;
        arg : cast FormatArg(this.Arg);
    }
}