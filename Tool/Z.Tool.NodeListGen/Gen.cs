namespace Z.Tool.NodeListGen;

public class Gen : Any
{
    public virtual long Execute()
    {
        Read read;
        read = this.CreateRead();
        int oo;
        oo = read.Execute();
        if (!(oo == 0))
        {
            return oo;
        }

        Table classTable;
        classTable = read.ClassTable;

        NodeGen nodeGen;
        nodeGen = new NodeGen();
        nodeGen.Init();
        nodeGen.ClassTable = classTable;
        nodeGen.Execute();

        NewStateGen newStateGen;
        newStateGen = new NewStateGen();
        newStateGen.Init();
        newStateGen.ClassTable = classTable;
        newStateGen.Execute();

        NodeStateGen nodeStateGen;
        nodeStateGen = new NodeStateGen();
        nodeStateGen.Init();
        nodeStateGen.ClassTable = classTable;
        nodeStateGen.Execute();

        CreateSetStateGen createSetStateGen;
        createSetStateGen = new CreateSetStateGen();
        createSetStateGen.Init();
        createSetStateGen.ClassTable = classTable;
        createSetStateGen.Execute();

        NodeKindListGen nodeKindListGen;
        nodeKindListGen = new NodeKindListGen();
        nodeKindListGen.Init();
        nodeKindListGen.ClassTable = classTable;
        nodeKindListGen.Execute();

        TravelGen travelGen;
        travelGen = new TravelGen();
        travelGen.Init();
        travelGen.ClassTable = classTable;
        travelGen.Execute();

        TravelClassPathGen travelClassPathGen;
        travelClassPathGen = new TravelClassPathGen();
        travelClassPathGen.Init();
        travelClassPathGen.ClassTable = classTable;
        travelClassPathGen.Execute();
        return 0;
    }

    protected virtual Read CreateRead()
    {
        Read a;
        a = new Read();
        a.Init();
        return a;
    }
}