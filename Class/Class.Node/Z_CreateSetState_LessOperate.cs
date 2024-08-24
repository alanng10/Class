namespace Class.Node;

public class LessOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        LessOperate node;
        node = (LessOperate)arg.Node;
        node.Lite = (Operate)k.Field00;
        node.Rite = (Operate)k.Field01;
        return true;
    }
}