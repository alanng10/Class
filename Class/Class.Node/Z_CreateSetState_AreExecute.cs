namespace Class.Node;

public class AreExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        AreExecute node;
        node = (AreExecute)arg.Node;
        node.Target = (Target)k.Field00;
        node.Value = (Operate)k.Field01;
        return true;
    }
}