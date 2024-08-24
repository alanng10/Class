namespace Class.Node;

public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();

        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.Keyword = KeywordList.This;
        this.Delimit = DelimitList.This;
        this.ErrorKind = ErrorKindList.This;
        this.NodeKind = NodeKindList.This;

        this.CountOperate = this.CreateCountCreateOperate();
        this.KindOperate = this.CreateKindCreateOperate();
        this.SetOperate = this.CreateSetCreateOperate();
        this.SetArg = this.CreateCreateSetArg();

        this.CharLess = this.CreateCharLess();
        this.CharForm = this.CreateCharForm();
        this.TextLess = this.CreateTextLess();

        this.NameCheck = this.CreateNameCheck();
        this.StringValueWrite = this.CreateStringValueWrite();
        this.TextIntParse = this.CreateTextIntParse();

        this.RangeA = this.CreateRange();
        this.RangeB = this.CreateRange();
        this.RangeC = this.CreateRange();
        this.RangeD = this.CreateRange();
        this.TokenA = this.CreateToken();
        this.TokenB = this.CreateToken();
        this.TokenC = this.CreateToken();
        this.TokenD = this.CreateToken();
        this.TokenE = this.CreateToken();
        this.TokenF = this.CreateToken();
        this.TokenG = this.CreateToken();
        this.TokenH = this.CreateToken();
        this.TokenI = this.CreateToken();

        this.TextA = this.CreateText();
        this.TextB = this.CreateText();
        this.StringData = this.CreateStringData();

        this.InitListItemState();

        this.InitNodeState();
        return true;
    }

    public virtual Array Source { get; set; }
    public virtual Array Code { get; set; }
    public virtual string Task { get; set; }
    public virtual Result Result { get; set; }

    protected virtual KeywordList Keyword { get; set; }
    protected virtual DelimitList Delimit { get; set; }
    protected virtual ErrorKindList ErrorKind { get; set; }
    protected virtual NodeKindList NodeKind { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }

    public virtual Source SourceItem { get; set; }

    protected virtual Array SourceText { get; set; }
    protected virtual Code CodeItem { get; set; }
    protected virtual Table NodeStateTable { get; set; }
    protected virtual NodeState NodeState { get; set; }

    protected virtual RangeState PartItemRangeState { get; set; }
    protected virtual RangeState StateItemRangeState { get; set; }
    protected virtual RangeState ParamItemRangeState { get; set; }
    protected virtual RangeState ArgueItemRangeState { get; set; }
    protected virtual NodeState PartItemNodeState { get; set; }
    protected virtual NodeState StateItemNodeState { get; set; }
    protected virtual NodeState ParamItemNodeState { get; set; }
    protected virtual NodeState ArgueItemNodeState { get; set; }

    protected virtual Range RangeA { get; set; }
    protected virtual Range RangeB { get; set; }
    protected virtual Range RangeC { get; set; }
    protected virtual Range RangeD { get; set; }
    protected virtual Token TokenA { get; set; }
    protected virtual Token TokenB { get; set; }
    protected virtual Token TokenC { get; set; }
    protected virtual Token TokenD { get; set; }
    protected virtual Token TokenE { get; set; }
    protected virtual Token TokenF { get; set; }
    protected virtual Token TokenG { get; set; }
    protected virtual Token TokenH { get; set; }
    protected virtual Token TokenI { get; set; }

    protected virtual TextLess TextLess { get; set; }
    protected virtual LessInt CharLess { get; set; }
    protected virtual CharForm CharForm { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual Text TextB { get; set; }
    protected virtual StringData StringData { get; set; }
    protected virtual TextIntParse TextIntParse { get; set; }

    public virtual CreateArg Arg { get; set; }
    
    protected virtual CountCreateOperate CountOperate { get; set; }
    protected virtual KindCreateOperate KindOperate { get; set; }
    protected virtual SetCreateOperate SetOperate { get; set; }

    protected virtual NameCheck NameCheck { get; set; }
    public virtual StringValueWrite StringValueWrite { get; set; }

    public virtual CreateOperate Operate { get; set; }
    public virtual CreateSetArg SetArg { get; set; }

    protected virtual LessInt CreateCharLess()
    {
        LessInt a;
        a = new LessInt();
        a.Init();
        return a;
    }

    protected virtual CharForm CreateCharForm()
    {
        CharForm a;
        a = new CharForm();
        a.Init();
        return a;
    }

    protected virtual TextLess CreateTextLess()
    {
        TextLess a;
        a = new TextLess();
        a.CharLess = this.CharLess;
        a.LiteCharForm = this.CharForm;
        a.RiteCharForm = this.CharForm;
        a.Init();
        return a;
    }

    protected virtual NameCheck CreateNameCheck()
    {
        NameCheck a;
        a = new NameCheck();
        a.Init();
        a.TextLess = this.TextLess;
        a.CharLess = this.CharLess;
        a.CharForm = this.CharForm;
        return a;
    }

    protected virtual StringValueWrite CreateStringValueWrite()
    {
        StringValueWrite a;
        a = new StringValueWrite();
        a.Init();
        return a;
    }

    protected virtual TextIntParse CreateTextIntParse()
    {
        TextIntParse a;
        a = new TextIntParse();
        a.Init();
        return a;
    }

    protected virtual CountCreateOperate CreateCountCreateOperate()
    {
        CountCreateOperate a;
        a = new CountCreateOperate();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual KindCreateOperate CreateKindCreateOperate()
    {
        KindCreateOperate a;
        a = new KindCreateOperate();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual SetCreateOperate CreateSetCreateOperate()
    {
        SetCreateOperate a;
        a = new SetCreateOperate();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual CreateSetArg CreateCreateSetArg()
    {
        CreateSetArg a;
        a = new CreateSetArg();
        a.Init();
        return a;
    }

    protected virtual Range CreateRange()
    {
        Range a;
        a = new Range();
        a.Init();
        return a;
    }

    protected virtual Token CreateToken()
    {
        Token a;
        a = new Token();
        a.Init();
        a.Range = new Range();
        a.Range.Init();
        return a;
    }

    protected virtual Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new InfraRange();
        a.Range.Init();
        return a;
    }

    protected virtual StringData CreateStringData()
    {
        StringData a;
        a = new StringData();
        a.Init();
        return a;
    }

    protected virtual bool InitListItemState()
    {
        this.PartItemRangeState = this.RangeStateSet(new PartItemRangeState());
        this.StateItemRangeState = this.RangeStateSet(new StateItemRangeState());
        this.ParamItemRangeState = this.RangeStateSet(new ParamItemRangeState());
        this.ArgueItemRangeState = this.RangeStateSet(new ArgueItemRangeState());

        this.PartItemNodeState = this.NodeStateSet(new PartItemNodeState());
        this.StateItemNodeState = this.NodeStateSet(new StateItemNodeState());
        this.ParamItemNodeState = this.NodeStateSet(new ParamItemNodeState());
        this.ArgueItemNodeState = this.NodeStateSet(new ArgueItemNodeState());
        return true;
    }

    private RangeState RangeStateSet(RangeState state)
    {
        state.Init();
        state.Create = this;

        RangeStateArg k;
        k = new RangeStateArg();
        k.Init();

        state.Arg = k;
        return state;
    }

    private NodeState NodeStateSet(NodeState state)
    {
        state.Init();
        state.Create = this;
        return state;
    }

    protected virtual bool InitNodeState()
    {
        this.NodeStateTable = this.ClassInfra.TableCreateStringLess();

        NodeKindList nodeKind;
        nodeKind = this.NodeKind;

        long count;
        count = nodeKind.Count;
        int i;
        i = 0;
        while (i < count)
        {
            NodeKind kind;
            kind = nodeKind.Get(i);
            this.AddNodeState(kind);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool AddNodeState(NodeKind kind)
    {
        NodeState state;
        state = kind.NodeState;
        state.Create = this;

        this.ListInfra.TableAdd(this.NodeStateTable, kind.Name, state);
        return true;
    }

    public override bool Execute()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        this.Result = new Result();
        this.Result.Init();
        Array rootArray;
        rootArray = new Array();
        rootArray.Count = this.Code.Count;
        rootArray.Init();
        this.Result.Root = rootArray;

        this.NodeState = (NodeState)this.NodeStateTable.Get(this.Task);
        if (this.NodeState == null)
        {
            Array ooo;
            ooo = new Array();
            ooo.Count = 0;
            ooo.Init();
            this.Result.Error = ooo;
            return true;
        }

        CreateArg arg;
        arg = new CreateArg();
        arg.Init();
        this.Arg = arg;

        this.Operate = this.CountOperate;

        this.ExecuteStage();
        this.SetArgClear();

        Data nodeData;
        nodeData = new Data();
        nodeData.Count = arg.NodeIndex;
        nodeData.Init();
        arg.NodeData = nodeData;

        arg.ListData = this.CountDataCreate(arg.ListIndex);
        arg.NameValueCountData = this.CountDataCreate(arg.NameValueIndex);
        arg.NameValueTextData = this.TextDataCreate(arg.NameValueTextIndex);
        arg.StringValueCountData = this.CountDataCreate(arg.StringValueIndex);
        arg.StringValueTextData = this.TextDataCreate(arg.StringValueTextIndex);
        
        this.Operate = this.KindOperate;

        this.ArgClearIndex();
        this.ExecuteStage();
        this.SetArgClear();

        arg.NodeArray = listInfra.ArrayCreate(arg.NodeIndex);
        arg.ListArray = listInfra.ArrayCreate(arg.ListIndex);
        arg.NameValueArray = listInfra.ArrayCreate(arg.NameValueIndex);
        arg.StringValueArray = listInfra.ArrayCreate(arg.StringValueIndex);
        arg.ErrorArray = listInfra.ArrayCreate(arg.ErrorIndex);

        this.ExecuteCreateNode();
        this.ExecuteCreateList();
        this.ExecuteCreateNameValue();
        this.ExecuteCreateStringValue();
        this.ExecuteCreateError();

        this.Operate = this.SetOperate;

        this.ArgClearIndex();
        this.ExecuteStage();
        this.SetArgClear();

        this.Result.Error = arg.ErrorArray;

        this.Arg = null;
        return true;
    }
    
    protected virtual bool ArgClearIndex()
    {
        CreateArg arg;
        arg = this.Arg;

        arg.NodeIndex = 0;
        arg.ListIndex = 0;
        arg.NameValueIndex = 0;
        arg.NameValueTextIndex = 0;
        arg.StringValueIndex = 0;
        arg.StringValueTextIndex = 0;
        arg.ErrorIndex = 0;
        return true;
    }

    protected virtual bool SetArgClear()
    {
        CreateSetArg a;
        a = this.SetArg;
        a.Kind = null;
        a.Field00 = null;
        a.Field01 = null;
        a.Field02 = null;
        a.Field03 = null;
        a.Field04 = null;
        a.FieldBool = false;
        a.FieldInt = 0;
        a.Start = 0;
        a.End = 0;
        return true;
    }

    protected virtual Data CountDataCreate(long count)
    {
        long o;
        o = count;
        o = o * sizeof(ulong);
        Data a;
        a = new Data();
        a.Count = o;
        a.Init();
        return a;
    }

    protected virtual Data TextDataCreate(long count)
    {
        long o;
        o = count;
        o = o * sizeof(uint);
        Data a;
        a = new Data();
        a.Count = o;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteCreateNode()
    {
        CreateArg arg;
        arg = this.Arg;

        Array array;
        array = arg.NodeArray;

        Data data;
        data = arg.NodeData;

        NodeKindList nodeKind;
        nodeKind = this.NodeKind;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long oa;
            oa = data.Get(i);
            NodeKind kind;
            kind = nodeKind.Get(oa);

            InfraState newState;
            newState = kind.NewState;
            newState.Execute();

            object o;
            o = newState.Result;
            newState.Result = null;

            Node node;
            node = (Node)o;
            node.Init();
            node.Range = this.CreateRange();
            array.SetAt(i, node);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateList()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        CreateArg arg;
        arg = this.Arg;
        
        Data data;
        data = arg.ListData;

        Array array;
        array = arg.ListArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i;
            index = index * sizeof(ulong);
            ulong u;
            u = this.InfraInfra.DataIntGet(data, index);
            long oa;
            oa = (long)u;

            Array a;
            a = listInfra.ArrayCreate(oa);

            array.SetAt(i, a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateError()
    {
        Array array;
        array = this.Arg.ErrorArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Error error;
            error = new Error();
            error.Init();
            error.Stage = this.Stage;
            error.Range = this.CreateRange();

            array.SetAt(i, error);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateNameValue()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;

        CreateArg arg;
        arg = this.Arg;

        Array array;
        array = arg.NameValueArray;

        Data data;
        data = arg.NameValueCountData;

        Text text;
        text = this.TextA;
        text.Data = arg.NameValueTextData;
        InfraRange range;
        range = text.Range;
        range.Index = 0;
        range.Count = 0;

        long total;
        total = 0;

        long count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i;
            index = index * sizeof(ulong);

            ulong u;
            u = infraInfra.DataIntGet(data, index);
            long oa;
            oa = (long)u;

            range.Index = total;
            range.Count = oa;

            String a;
            a = textInfra.StringCreate(text);

            array.SetAt(i, a);

            total = total + oa;

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateStringValue()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;

        CreateArg arg;
        arg = this.Arg;

        Array array;
        array = arg.StringValueArray;

        Data data;
        data = arg.StringValueCountData;

        Text text;
        text = this.TextA;
        text.Data = arg.StringValueTextData;
        InfraRange range;
        range = text.Range;
        range.Index = 0;
        range.Count = 0;

        long total;
        total = 0;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i;
            index = index * sizeof(ulong);
            
            ulong u;
            u = infraInfra.DataIntGet(data, index);
            long oa;
            oa = (long)u;
            
            range.Index = total;
            range.Count = oa;
            
            String a;
            a = textInfra.StringCreate(text);
            
            array.SetAt(i, a);
            
            total = total + oa;
            
            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteStage()
    {
        long count;
        count = this.Code.Count;
        long i;
        i = 0;
        while (i < count)
        {
            this.CodeItem = (Code)this.Code.GetAt(i);

            this.SourceItem = (Source)this.Source.GetAt(i);
            this.SourceText = this.SourceItem.Text;

            Node root;
            root = this.ExecuteRoot();
            this.Result.Root.SetAt(i, root);
            i = i + 1;
        }
        return true;
    }

    protected virtual Node ExecuteCreateOperate()
    {
        Node node;
        node = this.Operate.Execute();
        return node;
    }

    protected virtual Node ExecuteRoot()
    {
        Range range;
        range = this.RangeA;
        long rangeStart;
        rangeStart = 0;
        long rangeEnd;
        rangeEnd = this.CodeItem.Token.Count;
        this.Range(range, rangeStart, rangeEnd);

        this.NodeState.Arg = range;
        this.NodeState.Execute();

        Node node;
        node = (Node)this.NodeState.Result;

        this.NodeState.Result = null;
        this.NodeState.Arg = null;

        if (node == null)
        {
            this.Error(this.ErrorKind.Invalid, rangeStart, rangeEnd);
        }
        Node a;
        a = node;
        return a;
    }

    public virtual Node ExecuteClass(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token classToken;
        classToken = this.Token(this.TokenA, this.Keyword.Class.Text, this.IndexRange(this.RangeA, start));
        if (classToken == null)
        {
            return null;
        }

        Token colon;
        colon = this.TokenForwardNoSkip(this.TokenB, this.Delimit.BaseSign.Text, this.Range(this.RangeA, classToken.Range.End, end));
        if (colon == null)
        {
            return null;
        }

        Token leftBrace;
        leftBrace = this.TokenForwardNoSkip(this.TokenC, this.Delimit.LeftBrace.Text, this.Range(this.RangeA, colon.Range.End, end));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenD, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        int nameStart;
        int nameEnd;
        nameStart = classToken.Range.End;
        nameEnd = colon.Range.Start;
        int baseStart;
        int baseEnd;
        baseStart = colon.Range.End;
        baseEnd = leftBrace.Range.Start;
        int memberStart;
        int memberEnd;
        memberStart = leftBrace.Range.End;
        memberEnd = rightBrace.Range.Start;

        Node name;
        name = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, nameStart, nameEnd));
        if (name == null)
        {
            this.Error(this.ErrorKind.NameInvalid, nameStart, nameEnd);
        }

        Node varBase;
        varBase = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, baseStart, baseEnd));
        if (varBase == null)
        {
            this.Error(this.ErrorKind.BaseInvalid, baseStart, baseEnd);
        }

        Node member;
        member = this.ExecutePart(this.Range(this.RangeA, memberStart, memberEnd));
        if (member == null)
        {
            this.Error(this.ErrorKind.MemberInvalid, memberStart, memberEnd);
        }

        this.OperateArg.Kind = this.NodeKind.Class;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = name;
        this.OperateArg.Field01 = varBase;
        this.OperateArg.Field02 = member;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteField(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token fieldToken;
        fieldToken = this.Token(this.TokenA, this.Keyword.Field.Text, this.IndexRange(this.RangeA, start));
        if (fieldToken == null)
        {
            return null;
        }

        Token leftBrace;
        leftBrace = this.TokenForwardNoSkip(this.TokenB, this.Delimit.LeftBrace.Text, this.Range(this.RangeA, fieldToken.Range.End, end));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenC, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        int countStart;
        int countEnd;
        countStart = fieldToken.Range.End;
        countEnd = countStart + 1;

        int ke;
        ke = leftBrace.Range.Start;

        if (ke < countEnd)
        {
            countEnd = ke;
        }

        int classStart;
        int classEnd;
        classStart = countEnd;
        classEnd = classStart + 1;

        if (ke < classEnd)
        {
            classEnd = ke;
        }

        int nameStart;
        int nameEnd;
        nameStart = classEnd;
        nameEnd = ke;
        
        int oStart;
        int oEnd;
        oStart = leftBrace.Range.End;
        oEnd = rightBrace.Range.Start;

        Node count;
        count = this.ExecuteCount(this.Range(this.RangeA, countStart, countEnd));
        if (count == null)
        {
            this.Error(this.ErrorKind.CountInvalid, countStart, countEnd);
        }

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }

        Node name;
        name = this.ExecuteName(this.NodeKind.FieldName, this.Range(this.RangeA, nameStart, nameEnd));
        if (name == null)
        {
            this.Error(this.ErrorKind.NameInvalid, nameStart, nameEnd);
        }

        bool b;
        b = false;
        if (!b)
        {
            if (oStart == oEnd)
            {
                b = true;
            }
        }
        Token getToken;
        getToken = null;
        if (!b)
        {
            getToken = this.Token(this.TokenD, this.Keyword.ItemGet.Text, this.IndexRange(this.RangeA, oStart));
            if (getToken == null)
            {
                b = true;
            }
        }

        if (!b)
        {
            if (getToken.Range.End == oEnd)
            {
                b = true;
            }
        }
        Token getLeftBrace;
        getLeftBrace = null;
        if (!b)
        {
            getLeftBrace = this.Token(this.TokenE, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, getToken.Range.End));
            if (getLeftBrace == null)
            {
                b = true;
            }
        }

        Token getRightBrace;
        getRightBrace = null;
        if (!b)
        {
            getRightBrace = this.TokenMatchLeftBrace(this.TokenF, this.Range(this.RangeA, getLeftBrace.Range.End, oEnd));
            if (getRightBrace == null)
            {
                b = true;
            }
        }

        if (!b)
        {
            if (getRightBrace.Range.End == oEnd)
            {
                b = true;
            }
        }
        Token setToken;
        setToken = null;
        if (!b)
        {
            setToken = this.Token(this.TokenG, this.Keyword.Set.Text, this.IndexRange(this.RangeA, getRightBrace.Range.End));
            if (setToken == null)
            {
                b = true;
            }
        }

        if (!b)
        {
            if (setToken.Range.End == oEnd)
            {
                b = true;
            }
        }
        Token setLeftBrace;
        setLeftBrace = null;
        if (!b)
        {
            setLeftBrace = this.Token(this.TokenH, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, setToken.Range.End));
            if (setLeftBrace == null)
            {
                b = true;
            }
        }

        Token setRightBrace;
        setRightBrace = null;
        if (!b)
        {
            setRightBrace = this.TokenMatchLeftBrace(this.TokenI, this.Range(this.RangeA, setLeftBrace.Range.End, oEnd));
            if (setRightBrace == null)
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!(setRightBrace.Range.End == oEnd))
            {
                b = true;
            }
        }

        Node varGet;
        varGet = null;

        Node varSet;
        varSet = null;
        if (!b)
        {
            int getStart;
            int getEnd;
            getStart = getLeftBrace.Range.End;
            getEnd = getRightBrace.Range.Start;
            int setStart;
            int setEnd;
            setStart = setLeftBrace.Range.End;
            setEnd = setRightBrace.Range.Start;
            
            varGet = this.ExecuteState(this.Range(this.RangeA, getStart, getEnd));

            varSet = this.ExecuteState(this.Range(this.RangeA, setStart, setEnd));
        }
        
        if (varGet == null)
        {
            this.Error(this.ErrorKind.GetInvalid, oStart, oEnd);
        }

        if (varSet == null)
        {
            this.Error(this.ErrorKind.SetInvalid, oStart, oEnd);
        }

        this.OperateArg.Kind = this.NodeKind.Field;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        this.OperateArg.Field01 = name;
        this.OperateArg.Field02 = count;
        this.OperateArg.Field03 = varGet;
        this.OperateArg.Field04 = varSet;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteMaide(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token maideToken;
        maideToken = this.Token(this.TokenA, this.Keyword.Maide.Text, this.IndexRange(this.RangeA, start));
        if (maideToken == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenForwardNoSkip(this.TokenB, this.Delimit.LeftBracket.Text, this.Range(this.RangeA, maideToken.Range.End, end));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenC, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (rightBracket.Range.End == end)
        {
            return null;
        }
        Token leftBrace;
        leftBrace = this.Token(this.TokenD, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenE, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        int countStart;
        int countEnd;
        countStart = maideToken.Range.End;
        countEnd = countStart + 1;

        int ke;
        ke = leftBracket.Range.Start;

        if (ke < countEnd)
        {
            countEnd = ke;
        }

        int classStart;
        int classEnd;
        classStart = countEnd;
        classEnd = classStart + 1;

        if (ke < classEnd)
        {
            classEnd = ke;
        }

        int nameStart;
        int nameEnd;
        nameStart = classEnd;
        nameEnd = ke;
        
        int paramStart;
        int paramEnd;
        paramStart = leftBracket.Range.End;
        paramEnd = rightBracket.Range.Start;
        int callStart;
        int callEnd;
        callStart = leftBrace.Range.End;
        callEnd = rightBrace.Range.Start;

        Node count;
        count = this.ExecuteCount(this.Range(this.RangeA, countStart, countEnd));
        if (count == null)
        {
            this.Error(this.ErrorKind.CountInvalid, countStart, countEnd);
        }

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }

        Node name;
        name = this.ExecuteName(this.NodeKind.MaideName, this.Range(this.RangeA, nameStart, nameEnd));
        if (name == null)
        {
            this.Error(this.ErrorKind.NameInvalid, nameStart, nameEnd);
        }

        Node param;
        param = this.ExecuteParam(this.Range(this.RangeA, paramStart, paramEnd));
        if (param == null)
        {
            this.Error(this.ErrorKind.ParamInvalid, paramStart, paramEnd);
        }

        Node call;
        call = this.ExecuteState(this.Range(this.RangeA, callStart, callEnd));
        if (call == null)
        {
            this.Error(this.ErrorKind.CallInvalid, callStart, callEnd);
        }

        this.OperateArg.Kind = this.NodeKind.Maide;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        this.OperateArg.Field01 = name;
        this.OperateArg.Field02 = count;
        this.OperateArg.Field03 = param;
        this.OperateArg.Field04 = call;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteVar(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int count;
        count = this.Count(start, end);

        if (count < 1 | 3 < count)
        {
            return null;
        }

        Token varToken;
        varToken = this.Token(this.TokenA, this.Keyword.Var.Text, this.IndexRange(this.RangeA, start));
        if (varToken == null)
        {
            return null;
        }

        int classStart;
        int classEnd;
        classStart = varToken.Range.End;
        classEnd = classStart + 1;

        if (end < classEnd)
        {
            classEnd = end;
        }
        
        int nameStart;
        int nameEnd;
        nameStart = classEnd;
        nameEnd = end;

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }

        Node name;
        name = this.ExecuteName(this.NodeKind.VarName, this.Range(this.RangeA, nameStart, nameEnd));
        if (name == null)
        {
            this.Error(this.ErrorKind.NameInvalid, nameStart, nameEnd);
        }

        this.OperateArg.Kind = this.NodeKind.Var;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        this.OperateArg.Field01 = name;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteClassName(Range range)
    {
        return this.ExecuteName(this.NodeKind.ClassName, range);
    }

    public virtual Node ExecuteFieldName(Range range)
    {
        return this.ExecuteName(this.NodeKind.FieldName, range);
    }

    public virtual Node ExecuteMaideName(Range range)
    {
        return this.ExecuteName(this.NodeKind.MaideName, range);
    }

    public virtual Node ExecuteVarName(Range range)
    {
        return this.ExecuteName(this.NodeKind.VarName, range);
    }

    public virtual Node ExecutePart(Range range)
    {
        return this.ExecuteList(this.NodeKind.Part, this.PartItemRangeState, this.PartItemNodeState, range);
    }

    public virtual Node ExecuteState(Range range)
    {
        return this.ExecuteList(this.NodeKind.State, this.StateItemRangeState, this.StateItemNodeState, range);
    }

    public virtual Node ExecuteParam(Range range)
    {
        return this.ExecuteListComma(this.NodeKind.Param, this.ParamItemRangeState, this.ParamItemNodeState, range);
    }

    public virtual Node ExecuteArgue(Range range)
    {
        return this.ExecuteListComma(this.NodeKind.Argue, this.ArgueItemRangeState, this.ArgueItemNodeState, range);
    }

    public virtual Node ExecuteComp(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteField(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteMaide(this.Range(this.RangeA, start, end));
        }
       return a;
    }

    public virtual Node ExecuteTarget(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteVarTarget(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteSetTarget(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecuteVarTarget(Range range)
    {
        return this.ExecuteVarNameResult(this.NodeKind.VarTarget, range);
    }

    public virtual Node ExecuteSetTarget(Range range)
    {
        return this.ExecuteDotField(this.NodeKind.SetTarget, range);
    }

    public virtual Node ExecuteValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteBoolValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteIntHexSignValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteIntHexValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteIntSignValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteIntValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteStringValue(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecuteBoolValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TextInfra textInfra;
        textInfra = this.TextInfra;

        TextLess less;
        less = this.TextLess;
        TokenToken aa;
        aa = this.TokenToken(start);
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);
        Text textB;
        textB = this.TextB;

        bool value;
        value = false;

        bool b;
        b = false;
        if (!b)
        {
            this.TextStringGet(textB, this.Keyword.True.Text);
            if (textInfra.Equal(text, textB, less))
            {
                value = true;
                b = true;
            }
        }
        if (!b)
        {
            this.TextStringGet(textB, this.Keyword.False.Text);
            if (textInfra.Equal(text, textB, less))
            {
                value = false;
                b = true;
            }
        }

        if (!b)
        {
            return null;
        }

        this.OperateArg.Kind = this.NodeKind.BoolValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldBool = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);

        if (!this.IsIntValue(aa))
        {
            return null;
        }

        Text text;
        text = this.TextA;
        this.TextGet(text, aa);
        
        long value;
        value = this.TextIntParse.Execute(text, 10, false);
        if (value == -1)
        {
            return null;
        }

        this.OperateArg.Kind = this.NodeKind.IntValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntHexValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);

        if (!this.IsIntHexValue(aa))
        {
            return null;
        }

        Text line;
        line = (Text)this.SourceText.GetAt(aa.Row);
        Text text;
        text = this.TextA;
        text.Data = line.Data;
        text.Range.Index = line.Range.Index + aa.Range.Index + 2;
        text.Range.Count = aa.Range.Count - 2;

        long value;
        value = this.TextIntParse.Execute(text, 16, false);
        if (value == -1)
        {
            return null;
        }

        this.OperateArg.Kind = this.NodeKind.IntHexValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntSignValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        if (!this.IsIntSignValue(aa))
        {
            return null;
        }

        bool signNegative;
        signNegative = this.IsTokenSignNegative(aa, 2);

        Text line;
        line = (Text)this.SourceText.GetAt(aa.Row);
        Text text;
        text = this.TextA;
        text.Data = line.Data;
        text.Range.Index = line.Range.Index + aa.Range.Index + 3;
        text.Range.Count = aa.Range.Count - 3;

        long o;
        o = this.TextIntParse.Execute(text, 10, false);

        if (o == -1)
        {
            return null;
        }

        long max;
        max = 0;
        if (!signNegative)
        {
            max = this.ClassInfra.IntSignValuePositiveMax;
        }
        if (signNegative)
        {
            max = this.ClassInfra.IntSignValueNegativeMax;
        }

        if (max < o)
        {
            return null;
        }

        long value;
        value = 0;
        if (!signNegative)
        {
            value = o;
        }
        if (signNegative)
        {
            value = -o;
        }

        this.OperateArg.Kind = this.NodeKind.IntSignValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntHexSignValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        if (!this.IsIntHexSignValue(aa))
        {
            return null;
        }

        bool signNegative;
        signNegative = this.IsTokenSignNegative(aa, 3);

        Text line;
        line = (Text)this.SourceText.GetAt(aa.Row);
        Text text;
        text = this.TextA;
        text.Data = line.Data;
        text.Range.Index = line.Range.Index + aa.Range.Index + 4;
        text.Range.Count = aa.Range.Count - 4;

        long o;
        o = this.TextIntParse.Execute(text, 16, false);
        if (o == -1)
        {
            return null;
        }

        long max;
        max = 0;
        if (!signNegative)
        {
            max = this.ClassInfra.IntSignValuePositiveMax;
        }
        if (signNegative)
        {
            max = this.ClassInfra.IntSignValueNegativeMax;
        }

        if (max < o)
        {
            return null;
        }

        long value;
        value = 0;
        if (!signNegative)
        {
            value = o;
        }
        if (signNegative)
        {
            value = -o;
        }

        this.OperateArg.Kind = this.NodeKind.IntHexSignValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteStringValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);

        bool b;
        b = this.StringValueWrite.CheckValueString(text);
        if (!b)
        {
            return null;
        }

        string value;
        value = this.Operate.ExecuteStringValue(text);

        this.OperateArg.Kind = this.NodeKind.StringValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteCount(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecutePrusateCount(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecutePrecateCount(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteProbateCount(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecutePrivateCount(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecutePrusateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PrusateCount, this.Keyword.Prusate, range);
    }

    public virtual Node ExecutePrecateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PrecateCount, this.Keyword.Precate, range);
    }

    public virtual Node ExecuteProbateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.ProbateCount, this.Keyword.Probate, range);
    }

    public virtual Node ExecutePrivateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PrivateCount, this.Keyword.Private, range);
    }

    public virtual Node ExecuteExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteReturnExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteInfExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteWhileExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteReferExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAreExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteOperateExecute(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecuteInfExecute(Range range)
    {
        return this.ExecuteWordBracketBody(this.NodeKind.InfExecute, this.Keyword.Inf, range);
    }

    public virtual Node ExecuteWhileExecute(Range range)
    {
        return this.ExecuteWordBracketBody(this.NodeKind.WhileExecute, this.Keyword.While, range);
    }

    public virtual Node ExecuteReturnExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token returnToken;
        returnToken = this.Token(this.TokenA, this.Keyword.Return.Text, this.IndexRange(this.RangeA, start));
        if (returnToken == null)
        {
            return null;
        }

        if (returnToken.Range.End == end)
        {
            return null;
        }
        int lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenB, this.Delimit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        int resultStart;
        int resultEnd;
        resultStart = returnToken.Range.End;
        resultEnd = semicolon.Range.Start;

        Node result;
        result = this.ExecuteOperate(this.Range(this.RangeA, resultStart, resultEnd));
        if (result == null)
        {
            this.Error(this.ErrorKind.ResultInvalid, resultStart, resultEnd);
        }

        this.OperateArg.Kind = this.NodeKind.ReturnExecute;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = result;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteReferExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token varToken;
        varToken = this.Token(this.TokenA, this.Keyword.Var.Text, this.IndexRange(this.RangeA, start));
        if (varToken == null)
        {
            return null;
        }

        if (varToken.Range.End == end)
        {
            return null;
        }

        int lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenB, this.Delimit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        int varStart;
        int varEnd;
        varStart = start;
        varEnd = semicolon.Range.Start;

        Node varVar;
        varVar = this.ExecuteVar(this.Range(this.RangeA, varStart, varEnd));
        if (varVar == null)
        {
            this.Error(this.ErrorKind.VarInvalid, varStart, varEnd);
        }

        this.OperateArg.Kind = this.NodeKind.ReferExecute;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varVar;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteAreExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        int lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenA, this.Delimit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        Token colon;
        colon = this.TokenForward(this.TokenB, this.Delimit.BaseSign.Text, this.Range(this.RangeA, start, semicolon.Range.Start));
        if (colon == null)
        {
            return null;
        }

        int targetStart;
        int targetEnd;
        targetStart = start;
        targetEnd = colon.Range.Start;
        int valueStart;
        int valueEnd;
        valueStart = colon.Range.End;
        valueEnd = semicolon.Range.Start;

        Node target;
        target = this.ExecuteTarget(this.Range(this.RangeA, targetStart, targetEnd));
        if (target == null)
        {
            this.Error(this.ErrorKind.TargetInvalid, targetStart, targetEnd);
        }

        Node value;
        value = this.ExecuteOperate(this.Range(this.RangeA, valueStart, valueEnd));
        if (value == null)
        {
            this.Error(this.ErrorKind.ValueInvalid, valueStart, valueEnd);
        }

        this.OperateArg.Kind = this.NodeKind.AreExecute;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = target;
        this.OperateArg.Field01 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteOperateExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        int lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenA, this.Delimit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        int anyStart;
        int anyEnd;
        anyStart = start;
        anyEnd = semicolon.Range.Start;

        Node any;
        any = this.ExecuteOperate(this.Range(this.RangeA, anyStart, anyEnd));
        if (any == null)
        {
            this.Error(this.ErrorKind.AnyInvalid, anyStart, anyEnd);
        }

        this.OperateArg.Kind = this.NodeKind.OperateExecute;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = any;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteThisOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteBaseOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteNullOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteNewOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteShareOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteCastOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            if (!(start == end))
            {
                Token wordTokenA;
                wordTokenA = this.Token(this.TokenA, this.Keyword.Sign.Text, this.IndexRange(this.RangeA, start));
                if (!(wordTokenA == null))
                {
                    if (a == null)
                    {
                        a = this.ExecuteSignLessOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteSignMulOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteSignDivOperate(this.Range(this.RangeA, start, end));
                    }
                }
            }
        }
        if (a == null)
        {
            if (!(start == end))
            {
                Token wordTokenB;
                wordTokenB = this.Token(this.TokenA, this.Keyword.Bit.Text, this.IndexRange(this.RangeA, start));
                if (!(wordTokenB == null))
                {
                    if (a == null)
                    {
                        a = this.ExecuteBitAndOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitOrnOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitNotOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitLeftOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitRightOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitSignRightOperate(this.Range(this.RangeA, start, end));
                    }
                }
            }
        }
        if (a == null)
        {
            a = this.ExecuteBracketOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteVarOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteValueOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAndOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteOrnOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteNotOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteEqualOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteLessOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAddOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteSubOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteMulOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteDivOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteCallOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteGetOperate(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecuteGetOperate(Range range)
    {
        return this.ExecuteDotField(this.NodeKind.GetOperate, range);
    }

    public virtual Node ExecuteCallOperate(Range range)
    {
        return this.ExecuteDotMaideCall(this.NodeKind.CallOperate, range);
    }

    public virtual Node ExecuteThisOperate(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.ThisOperate, this.Keyword.ItemThis, range);
    }

    public virtual Node ExecuteBaseOperate(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.BaseOperate, this.Keyword.Base, range);
    }

    public virtual Node ExecuteNullOperate(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.NullOperate, this.Keyword.Null, range);
    }

    public virtual Node ExecuteNewOperate(Range range)
    {
        return this.ExecuteWordClass(this.NodeKind.NewOperate, this.Keyword.New, range);
    }

    public virtual Node ExecuteShareOperate(Range range)
    {
        return this.ExecuteWordClass(this.NodeKind.ShareOperate, this.Keyword.Share, range);
    }

    public virtual Node ExecuteCastOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token castToken;
        castToken = this.Token(this.TokenA, this.Keyword.Cast.Text, this.IndexRange(this.RangeA, start));
        if (castToken == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenForwardNoSkip(this.TokenB, this.Delimit.LeftBracket.Text, this.Range(this.RangeA, castToken.Range.End, end));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenC, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int classStart;
        int classEnd;
        classStart = castToken.Range.End;
        classEnd = leftBracket.Range.Start;
        int anyStart;
        int anyEnd;
        anyStart = leftBracket.Range.End;
        anyEnd = rightBracket.Range.Start;

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }

        Node any;
        any = this.ExecuteOperate(this.Range(this.RangeA, anyStart, anyEnd));
        if (any == null)
        {
            this.Error(this.ErrorKind.AnyInvalid, anyStart, anyEnd);
        }

        this.OperateArg.Kind = this.NodeKind.CastOperate;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        this.OperateArg.Field01 = any;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteVarOperate(Range range)
    {
        return this.ExecuteVarNameResult(this.NodeKind.VarOperate, range);
    }

    public virtual Node ExecuteValueOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node value;
        value = this.ExecuteValue(this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.OperateArg.Kind = this.NodeKind.ValueOperate;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteBracketOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenA, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, start));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenB, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int anyStart;
        int anyEnd;
        anyStart = leftBracket.Range.End;
        anyEnd = rightBracket.Range.Start;

        Node any;
        any = this.ExecuteOperate(this.Range(this.RangeA, anyStart, anyEnd));
        if (any == null)
        {
            this.Error(this.ErrorKind.AnyInvalid, anyStart, anyEnd);
        }

        this.OperateArg.Kind = this.NodeKind.BracketOperate;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = any;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteEqualOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.EqualOperate, this.Delimit.EqualSign, range);
    }

    public virtual Node ExecuteAndOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.AndOperate, this.Delimit.AndSign, range);
    }

    public virtual Node ExecuteOrnOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.OrnOperate, this.Delimit.OrnSign, range);
    }

    public virtual Node ExecuteNotOperate(Range range)
    {
        return this.ExecuteDelimitOneOperand(this.NodeKind.NotOperate, this.Delimit.NotSign, range);
    }

    public virtual Node ExecuteAddOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.AddOperate, this.Delimit.AddSign, range);
    }

    public virtual Node ExecuteSubOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.SubOperate, this.Delimit.SubSign, range);
    }

    public virtual Node ExecuteMulOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.MulOperate, this.Delimit.MulSign, range);
    }

    public virtual Node ExecuteDivOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.DivOperate, this.Delimit.DivSign, range);
    }

    public virtual Node ExecuteLessOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.LessOperate, this.Delimit.LessSign, range);
    }

    public virtual Node ExecuteSignMulOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.SignMulOperate, this.Keyword.Sign, this.Delimit.MulSign, range);
    }

    public virtual Node ExecuteSignDivOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.SignDivOperate, this.Keyword.Sign, this.Delimit.DivSign, range);
    }

    public virtual Node ExecuteSignLessOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.SignLessOperate, this.Keyword.Sign, this.Delimit.LessSign, range);
    }

    public virtual Node ExecuteBitAndOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.BitAndOperate, this.Keyword.Bit, this.Delimit.AndSign, range);
    }

    public virtual Node ExecuteBitOrnOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.BitOrnOperate, this.Keyword.Bit, this.Delimit.OrnSign, range);
    }

    public virtual Node ExecuteBitNotOperate(Range range)
    {
        return this.ExecuteWordDelimitOneOperand(this.NodeKind.BitNotOperate, this.Keyword.Bit, this.Delimit.NotSign, range);
    }

    public virtual Node ExecuteBitLeftOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.BitLeftOperate, this.Keyword.Bit, this.Delimit.LessSign, range);
    }

    public virtual Node ExecuteBitRightOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.BitRightOperate, this.Keyword.Bit, this.Delimit.MoreSign, range);
    }

    public virtual Node ExecuteBitSignRightOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, this.Keyword.Bit.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenB, this.Delimit.MoreSign.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (op == null)
        {
            return null;
        }

        if (op.Range.End == end)
        {
            return null;
        }
        Token opA;
        opA = this.Token(this.TokenC, this.Delimit.MoreSign.Text, this.IndexRange(this.RangeA, op.Range.End));
        if (opA == null)
        {
            return null;
        }

        if (opA.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenA, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, opA.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenB, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        Token comma;
        comma = this.TokenForward(this.TokenC, this.Delimit.PauseSign.Text, this.Range(this.RangeA, leftBracket.Range.End, rightBracket.Range.Start));
        if (comma == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int leftStart;
        int leftEnd;
        leftStart = leftBracket.Range.End;
        leftEnd = comma.Range.Start;
        int rightStart;
        int rightEnd;
        rightStart = comma.Range.End;
        rightEnd = rightBracket.Range.Start;

        Node left;
        left = this.ExecuteOperate(this.Range(this.RangeA, leftStart, leftEnd));
        if (left == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, leftStart, leftEnd);
        }

        Node right;
        right = this.ExecuteOperate(this.Range(this.RangeA, rightStart, rightEnd));
        if (right == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, rightStart, rightEnd);
        }

        this.OperateArg.Kind = this.NodeKind.BitSignRightOperate;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = left;
        this.OperateArg.Field01 = right;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordBracketBody(NodeKind kind, Keyword word, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenB, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenC, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (rightBracket.Range.End == end)
        {
            return null;
        }
        Token leftBrace;
        leftBrace = this.Token(this.TokenD, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenA, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        int condStart;
        int condEnd;
        condStart = leftBracket.Range.End;
        condEnd = rightBracket.Range.Start;
        int bodyStart;
        int bodyEnd;
        bodyStart = leftBrace.Range.End;
        bodyEnd = rightBrace.Range.Start;

        Node cond;
        cond = this.ExecuteOperate(this.Range(this.RangeA, condStart, condEnd));
        if (cond == null)
        {
            this.Error(this.ErrorKind.CondInvalid, condStart, condEnd);
        }

        Node body;
        body = this.ExecuteState(this.Range(this.RangeA, bodyStart, bodyEnd));
        if (body == null)
        {
            this.Error(this.ErrorKind.BodyInvalid, bodyStart, bodyEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = cond;
        this.OperateArg.Field01 = body;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteOneWord(NodeKind kind, Keyword word, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.Range(this.RangeA, start, end));
        if (wordToken == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordClass(NodeKind kind, Keyword keyword, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int count;
        count = this.Count(start, end);

        if (count < 1 | 2 < count)
        {
            return null;
        }

        Token wordToken;
        wordToken = this.Token(this.TokenA, keyword.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        int classStart;
        int classEnd;
        classStart = wordToken.Range.End;
        classEnd = end;

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }
        
        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDotField(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token dot;
        dot = this.TokenBackwardNoSkip(this.TokenA, this.Delimit.StopSign.Text, this.Range(this.RangeA, start, end));
        if (dot == null)
        {
            return null;
        }

        int thisStart;
        int thisEnd;
        thisStart = start;
        thisEnd = dot.Range.Start;
        int fieldStart;
        int fieldEnd;
        fieldStart = dot.Range.End;
        fieldEnd = end;

        Node varThis;
        varThis = this.ExecuteOperate(this.Range(this.RangeA, thisStart, thisEnd));
        if (varThis == null)
        {
            this.Error(this.ErrorKind.ThisInvalid, thisStart, thisEnd);
        }

        Node field;
        field = this.ExecuteName(this.NodeKind.FieldName, this.Range(this.RangeA, fieldStart, fieldEnd));
        if (field == null)
        {
            this.Error(this.ErrorKind.FieldInvalid, fieldStart, fieldEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varThis;
        this.OperateArg.Field01 = field;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDotMaideCall(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        int lastIndex;
        lastIndex = end - 1;
        Token rightBracket;
        rightBracket = this.Token(this.TokenA, this.Delimit.RightBracket.Text, this.IndexRange(this.RangeA, lastIndex));
        if (rightBracket == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenMatchRightBracket(this.TokenB, this.Range(this.RangeA, start, rightBracket.Range.Start));
        if (leftBracket == null)
        {
            return null;
        }

        Token dot;
        dot = this.TokenBackwardNoSkip(this.TokenC, this.Delimit.StopSign.Text, this.Range(this.RangeA, start, leftBracket.Range.Start));
        if (dot == null)
        {
            return null;
        }

        int thisStart;
        int thisEnd;
        thisStart = start;
        thisEnd = dot.Range.Start;

        int maideStart;
        int maideEnd;
        maideStart = dot.Range.End;
        maideEnd = leftBracket.Range.Start;

        int argueStart;
        int argueEnd;
        argueStart = leftBracket.Range.End;
        argueEnd = rightBracket.Range.Start;

        Node varThis;
        varThis = this.ExecuteOperate(this.Range(this.RangeA, thisStart, thisEnd));
        if (varThis == null)
        {
            this.Error(this.ErrorKind.ThisInvalid, thisStart, thisEnd);
        }

        Node maide;
        maide = this.ExecuteName(this.NodeKind.MaideName, this.Range(this.RangeA, maideStart, maideEnd));
        if (maide == null)
        {
            this.Error(this.ErrorKind.MaideInvalid, maideStart, maideEnd);
        }

        Node argue;
        argue = this.ExecuteArgue(this.Range(this.RangeA, argueStart, argueEnd));
        if (argue == null)
        {
            this.Error(this.ErrorKind.ArgueInvalid, argueStart, argueEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varThis;
        this.OperateArg.Field01 = maide;
        this.OperateArg.Field02 = argue;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteVarNameResult(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node varVar;
        varVar = this.ExecuteName(this.NodeKind.VarName, this.Range(this.RangeA, start, end));
        if (varVar == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varVar;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteName(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node node;
        node = null;
        bool b;
        b = false;
        Range aRange;
        aRange = this.ExecuteNameRange(this.RangeB, this.Range(this.RangeA, start, end));
        if (aRange == null)
        {
            b = true;
        }
        if (!b)
        {
            if (!(aRange.End == end))
            {
                b = true;
            }
        }
        if (!b)
        {
            node = this.ExecuteNameNode(kind, this.Range(this.RangeA, start, end));
        }

        return node;
    }

    protected virtual Node ExecuteNameNode(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        string value;
        value = this.ExecuteNameValue(this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDelimitTwoOperand(NodeKind kind, Delimit delimit, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token op;
        op = this.TokenForward(this.TokenA, delimit.Text, this.Range(this.RangeA, start, end));
        if (op == null)
        {
            return null;
        }

        int leftStart;
        int leftEnd;
        leftStart = start;
        leftEnd = op.Range.Start;
        int rightStart;
        int rightEnd;
        rightStart = op.Range.End;
        rightEnd = end;

        Node left;
        left = this.ExecuteOperate(this.Range(this.RangeA, leftStart, leftEnd));
        if (left == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, leftStart, leftEnd);
        }

        Node right;
        right = this.ExecuteOperate(this.Range(this.RangeA, rightStart, rightEnd));
        if (right == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, rightStart, rightEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = left;
        this.OperateArg.Field01 = right;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDelimitOneOperand(NodeKind kind, Delimit delimit, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenA, delimit.Text, this.IndexRange(this.RangeA, start));
        if (op == null)
        {
            return null;
        }

        int valueStart;
        int valueEnd;
        valueStart = op.Range.End;
        valueEnd = end;

        Node value;
        value = this.ExecuteOperate(this.Range(this.RangeA, valueStart, valueEnd));
        if (value == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, valueStart, valueEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordDelimitTwoOperand(NodeKind kind, Keyword word, Delimit delimit, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenB, delimit.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (op == null)
        {
            return null;
        }

        if (op.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenC, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, op.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenD, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        Token comma;
        comma = this.TokenForward(this.TokenA, this.Delimit.PauseSign.Text, this.Range(this.RangeA, leftBracket.Range.End, rightBracket.Range.Start));
        if (comma == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int leftStart;
        int leftEnd;
        leftStart = leftBracket.Range.End;
        leftEnd = comma.Range.Start;
        int rightStart;
        int rightEnd;
        rightStart = comma.Range.End;
        rightEnd = rightBracket.Range.Start;

        Node left;
        left = this.ExecuteOperate(this.Range(this.RangeA, leftStart, leftEnd));
        if (left == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, leftStart, leftEnd);
        }

        Node right;
        right = this.ExecuteOperate(this.Range(this.RangeA, rightStart, rightEnd));
        if (right == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, rightStart, rightEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = left;
        this.OperateArg.Field01 = right;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordDelimitOneOperand(NodeKind kind, Keyword word, Delimit delimit, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenB, delimit.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (op == null)
        {
            return null;
        }

        if (op.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenC, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, op.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenD, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int valueStart;
        int valueEnd;
        valueStart = leftBracket.Range.End;
        valueEnd = rightBracket.Range.Start;

        Node value;
        value = this.ExecuteOperate(this.Range(this.RangeA, valueStart, valueEnd));
        if (value == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, valueStart, valueEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteList(NodeKind kind, RangeState rangeState, NodeState nodeState, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Array value;
        value = this.ExecuteListValue(rangeState, nodeState, this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteListComma(NodeKind kind, RangeState rangeState, NodeState nodeState, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Array value;
        value = this.ExecuteListValueComma(rangeState, nodeState, this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Array ExecuteListValue(RangeState rangeState, NodeState nodeState, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int listIndex;
        listIndex = this.Operate.ExecuteListNew();

        int count;
        count = 0;
        int index;
        index = start;
        while (index < end)
        {
            RangeStateArg arg;
            arg = (RangeStateArg)rangeState.Arg;

            arg.Result = this.RangeB;
            arg.Range = this.Range(this.RangeA, index, end);
            rangeState.Execute();

            Range itemRange;
            itemRange = (Range)rangeState.Result;
            
            rangeState.Result = null;
            arg.Result = null;
            arg.Range = null;

            bool b;
            b = (itemRange == null);
            if (b)
            {
                int aStart;
                int aEnd;
                aStart = index;
                aEnd = end;
                this.Error(this.ErrorKind.ItemInvalid, aStart, aEnd);

                this.Operate.ExecuteListSetItem(listIndex, count, null);
                count = count + 1;

                index = end;
            }

            if (!b)
            {
                int itemStart;
                int itemEnd;
                itemStart = itemRange.Start;
                itemEnd = itemRange.End;

                index = itemEnd;

                nodeState.Arg = this.Range(this.RangeA, itemStart, itemEnd);
                nodeState.Execute();

                Node item;
                item = (Node)nodeState.Result;

                nodeState.Arg = null;
                nodeState.Result = null;

                bool ba;
                ba = (item == null);
                if (ba)
                {
                    this.Error(this.ErrorKind.ItemInvalid, itemStart, itemEnd);
                }

                this.Operate.ExecuteListSetItem(listIndex, count, item);

                count = count + 1;
            }
        }

        this.Operate.ExecuteListCount(listIndex, count);

        Array array;
        array = this.Operate.ExecuteListGet(listIndex);
        return array;
    }

    protected virtual Array ExecuteListValueComma(RangeState rangeState, NodeState nodeState, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int listIndex;
        listIndex = this.Operate.ExecuteListNew();

        int count;
        count = 0;

        bool hasNextItem;
        hasNextItem = false;

        int index;
        index = start;
        while (index < end)
        {
            RangeStateArg arg;
            arg = (RangeStateArg)rangeState.Arg;

            arg.Result = this.RangeB;
            arg.Range = this.Range(this.RangeA, index, end);

            rangeState.Execute();

            Range itemRange;
            itemRange = (Range)rangeState.Result;

            rangeState.Result = null;
            arg.Result = null;
            arg.Range = null;

            int aStart;
            int aEnd;
            aStart = 0;
            aEnd = 0;

            bool b;
            b = (itemRange == null);
            if (b)
            {
                aStart = index;
                aEnd = end;

                index = aEnd;

                hasNextItem = false;
            }

            if (!b)
            {
                aStart = itemRange.Start;
                aEnd = itemRange.End;

                index = aEnd + 1;

                hasNextItem = true;
            }

            nodeState.Arg = this.Range(this.RangeA, aStart, aEnd);

            nodeState.Execute();

            Node item;
            item = (Node)nodeState.Result;

            nodeState.Arg = null;
            nodeState.Result = null;

            bool ba;
            ba = (item == null);

            if (ba)
            {
                this.Error(this.ErrorKind.ItemInvalid, aStart, aEnd);
            }

            this.Operate.ExecuteListSetItem(listIndex, count, item);


            count = count + 1;
        }

        if (hasNextItem)
        {
            this.Error(this.ErrorKind.ItemInvalid, index, index);

            this.Operate.ExecuteListSetItem(listIndex, count, null);

            count = count + 1;
        }

        this.Operate.ExecuteListCount(listIndex, count);

        Array array;
        array = this.Operate.ExecuteListGet(listIndex);
        return array;
    }

    protected virtual Range ExecuteNameRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        if (!this.IsName(this.TokenToken(start)))
        {
            return null;
        }
        return this.IndexRange(result, start);
    }

    public virtual Range ExecuteExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteReturnExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteInfExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteWhileExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteReferExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAreExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteOperateExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        return a;
    }

    protected virtual Range ExecuteReturnExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token returnToken;
        returnToken = this.Token(this.TokenA, this.Keyword.Return.Text, this.IndexRange(this.RangeA, start));
        if (returnToken == null)
        {
            return null;
        }

        Token semicolon;
        semicolon = this.TokenForward(this.TokenB, this.Delimit.ExecuteSign.Text, this.Range(this.RangeA, returnToken.Range.End, end));
        if (semicolon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteInfExecuteRange(Range result, Range range)
    {
        return this.ExecuteWordBracketRange(result, this.Keyword.Inf, range);
    }

    protected virtual Range ExecuteWhileExecuteRange(Range result, Range range)
    {
        return this.ExecuteWordBracketRange(result, this.Keyword.While, range);
    }

    protected virtual Range ExecuteWordBracketRange(Range result, Keyword word, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenB, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenC, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (rightBracket.Range.End == end)
        {
            return null;
        }
        Token leftBrace;
        leftBrace = this.Token(this.TokenD, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenA, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        this.Range(result, start, rightBrace.Range.End);
        return result;
    }

    protected virtual Range ExecuteReferExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token varToken;
        varToken = this.Token(this.TokenA, this.Keyword.Var.Text, this.IndexRange(this.RangeA, start));
        if (varToken == null)
        {
            return null;
        }

        Token semicolon;
        semicolon = this.TokenForward(this.TokenB, this.Delimit.ExecuteSign.Text, this.Range(this.RangeA, varToken.Range.End, end));
        if (semicolon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteAreExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token semicolon;
        semicolon = this.TokenForward(this.TokenA, this.Delimit.ExecuteSign.Text, this.Range(this.RangeA, start, end));
        if (semicolon == null)
        {
            return null;
        }

        Token colon;
        colon = this.TokenForward(this.TokenB, this.Delimit.BaseSign.Text, this.Range(this.RangeA, start, semicolon.Range.Start));
        if (colon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteOperateExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token semicolon;
        semicolon = this.TokenForward(this.TokenA, this.Delimit.ExecuteSign.Text, this.Range(this.RangeA, start, end));
        if (semicolon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    public virtual Range ExecuteParamItemRange(Range result, Range range)
    {
        return this.ExecuteEndAtCommaRange(result, range);
    }

    public virtual Range ExecuteArgueItemRange(Range result, Range range)
    {
        return this.ExecuteEndAtCommaRange(result, range);
    }

    protected virtual Range ExecuteEndAtCommaRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token comma;
        comma = this.TokenForward(this.TokenA, this.Delimit.PauseSign.Text, this.Range(this.RangeA, start, end));
        if (comma == null)
        {
            return null;
        }
        this.Range(result, start, comma.Range.Start);
        return result;
    }

    public virtual Range ExecuteCompRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteFieldRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteMaideRange(result, this.Range(this.RangeA, start, end));
        }
        return a;
    }

    protected virtual Range ExecuteFieldRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token fieldToken;
        fieldToken = this.Token(this.TokenA, this.Keyword.Field.Text, this.IndexRange(this.RangeA, start));
        if (fieldToken == null)
        {
            return null;
        }

        Token leftBrace;
        leftBrace = this.TokenForwardNoSkip(this.TokenB, this.Delimit.LeftBrace.Text, this.Range(this.RangeA, fieldToken.Range.End, end));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenC, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        this.Range(result, start, rightBrace.Range.End);
        return result;
    }

    protected virtual Range ExecuteMaideRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token maideToken;
        maideToken = this.Token(this.TokenA, this.Keyword.Maide.Text, this.IndexRange(this.RangeA, start));
        if (maideToken == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenForwardNoSkip(this.TokenB, this.Delimit.LeftBracket.Text, this.Range(this.RangeA, maideToken.Range.End, end));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenC, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (rightBracket.Range.End == end)
        {
            return null;
        }
        Token leftBrace;
        leftBrace = this.Token(this.TokenD, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenE, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        this.Range(result, start, rightBrace.Range.End);
        return result;
    }

    protected virtual string ExecuteNameValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!((start + 1) == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);

        string a;
        a = this.Operate.ExecuteNameValue(text);
        return a;
    }

    protected virtual bool IsIntValue(TokenToken aa)
    {
        this.TextGet(this.TextA, aa);

        if (!this.IsIntChar(this.TextA))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntHexValue(TokenToken aa)
    {
        int count;
        count = aa.Range.Count;

        if (count < 3)
        {
            return false;
        }

        Text line;
        line = (Text)this.SourceText.GetAt(aa.Row);

        Data data;
        data = line.Data;
        int start;
        start = line.Range.Index + aa.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, start) == '0'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 1) == 'h'))
        {
            return false;
        }

        int startA;
        startA = start + 2;
        int countA;
        countA = count - 2;
        this.TextA.Data = data;
        this.TextA.Range.Index = startA;
        this.TextA.Range.Count = countA;
        if (!this.IsIntHexChar(this.TextA))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntSignValue(TokenToken aa)
    {
        int count;
        count = aa.Range.Count;

        if (count < 4)
        {
            return false;
        }

        Text line;
        line = (Text)this.SourceText.GetAt(aa.Row);

        Data data;
        data = line.Data;
        int start;
        start = line.Range.Index + aa.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, start) == '0'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 1) == 's'))
        {
            return false;
        }

        char oa;
        oa = this.TextInfra.DataCharGet(data, start + 2);
        if (!this.IsIntSignChar(oa))
        {
            return false;
        }

        int startA;
        startA = start + 3;
        int countA;
        countA = count - 3;
        this.TextA.Data = data;
        this.TextA.Range.Index = startA;
        this.TextA.Range.Count = countA;
        if (!this.IsIntChar(this.TextA))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntHexSignValue(TokenToken aa)
    {
        int count;
        count = aa.Range.Count;

        if (count < 5)
        {
            return false;
        }

        Text line;
        line = (Text)this.SourceText.GetAt(aa.Row);

        Data data;
        data = line.Data;
        int start;
        start = line.Range.Index + aa.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, start) == '0'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 1) == 'h'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 2) == 's'))
        {
            return false;
        }

        char oa;
        oa = this.TextInfra.DataCharGet(data, start + 3);
        if (!this.IsIntSignChar(oa))
        {
            return false;
        }

        int startA;
        startA = start + 4;
        int countA;
        countA = count - 4;
        this.TextA.Data = data;
        this.TextA.Range.Index = startA;
        this.TextA.Range.Count = countA;
        if (!this.IsIntHexChar(this.TextA))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntChar(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Data data;
        data = text.Data;
        int start;
        start = text.Range.Index;
        int count;
        count = text.Range.Count;
        int index;
        char oc;
        int i;
        i = 0;
        while (i < count)
        {
            index = start + i;

            oc = textInfra.DataCharGet(data, index);

            if (!(textInfra.IsDigit(oc)))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool IsIntHexChar(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Data data;
        data = text.Data;
        int start;
        start = text.Range.Index;
        int count;
        count = text.Range.Count;
        int index;
        char oc;
        int i;
        i = 0;
        while (i < count)
        {
            index = start + i;

            oc = textInfra.DataCharGet(data, index);

            if (!(textInfra.IsDigit(oc) | textInfra.IsHexLetter(oc, false)))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool IsIntSignChar(char oc)
    {
        return (oc == 'p') | (oc == 'n');
    }

    protected virtual bool IsTokenSignNegative(TokenToken o, int index)
    {
        Text line;
        line = (Text)this.SourceText.GetAt(o.Row);

        Data data;
        data = line.Data;
        int start;
        start = line.Range.Index + o.Range.Index;

        char oa;
        oa = this.TextInfra.DataCharGet(data, start + index);
        bool a;
        a = (oa == 'n');
        return a;
    }

    protected virtual TokenToken TokenToken(long index)
    {
        TokenToken token;
        token = (TokenToken)this.CodeItem.Token.GetAt(index);
        return token;
    }

    protected virtual long Count(long start, long end)
    {
        return this.ClassInfra.Count(start, end);
    }

    protected virtual bool TextGet(Text text, TokenToken token)
    {
        Text line;
        line = (Text)this.SourceText.GetAt(token.Row);
        InfraRange range;
        range = token.Range;
        text.Data = line.Data;
        text.Range.Index = line.Range.Index + range.Index;
        text.Range.Count = range.Count;
        return true;
    }

    protected virtual bool TextStringGet(Text text, String o)
    {
        StringData d;
        d = this.StringData;
        d.ValueString = o;

        text.Data = d;
        text.Range.Index = 0;
        text.Range.Count = o.Length;
        return true;
    }

    protected virtual bool IsName(TokenToken token)
    {
        this.TextGet(this.TextA, token);

        return this.NameCheck.IsName(this.TextA);
    }

    public virtual bool NodeInfo(Node node, long start, long end)
    {
        this.Range(node.Range, start, end);
        return true;
    }

    protected virtual bool IsText(String value, long index)
    {
        TokenToken aa;
        aa = this.TokenToken(index);
        
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);

        Text textB;
        textB = this.TextB;
        this.TextStringGet(textB, value);

        bool b;
        b = this.TextInfra.Equal(text, textB, this.TextLess);
        bool a;
        a = b;
        return a;
    }

    protected virtual Range Range(Range range, long start, long end)
    {
        range.Start = start;
        range.End = end;
        return range;
    }

    protected virtual Range IndexRange(Range range, long index)
    {
        this.ClassInfra.IndexRange(range, index);
        return range;
    }

    protected virtual bool Error(ErrorKind kind, long start, long end)
    {
        this.Operate.ExecuteError(kind, start, end);
        return true;
    }

    protected virtual Token Token(Token result, String value, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        if (!this.IsText(value, start))
        {
            return null;
        }

        this.Range(result.Range, start, end);
        return result;
    }

    protected virtual Token TokenForwardNoSkip(Token result, string value, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;
        string leftBracket;
        string rightBracket;
        leftBracket = this.Delimit.LeftBracket.Text;
        rightBracket = this.Delimit.RightBracket.Text;
        string leftBrace;
        string rightBrace;
        leftBrace = this.Delimit.LeftBrace.Text;
        rightBrace = this.Delimit.RightBrace.Text;
        int i;
        i = start;
        int index;
        index = -1;
        bool varContinue;
        varContinue = (i < end);
        while (varContinue)
        {
            bool b;
            b = this.IsText(value, i);
            if (b)
            {
                index = i;
                varContinue = false;
            }
            if (!b)
            {
                bool ba;
                ba = (this.IsText(leftBracket, i) | this.IsText(rightBracket, i) | this.IsText(leftBrace, i) | this.IsText(rightBrace, i));
                if (ba)
                {
                    varContinue = false;
                }
                if (!ba)
                {
                    i = i + 1;
                }
            }
            if (!(i < end))
            {
                varContinue = false;
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual Token TokenBackwardNoSkip(Token result, string value, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;
        string leftBracket;
        string rightBracket;
        leftBracket = this.Delimit.LeftBracket.Text;
        rightBracket = this.Delimit.RightBracket.Text;
        string leftBrace;
        string rightBrace;
        leftBrace = this.Delimit.LeftBrace.Text;
        rightBrace = this.Delimit.RightBrace.Text;
        int i;
        i = end;
        int index;
        index = -1;
        bool varContinue;
        varContinue = (start < i);
        while (varContinue)
        {
            int j;
            j = i - 1;
            bool b;
            b = this.IsText(value, j);
            if (b)
            {
                index = j;
                varContinue = false;
            }
            if (!b)
            {
                bool ba;
                ba = (this.IsText(leftBracket, j) | this.IsText(rightBracket, j) | this.IsText(leftBrace, j) | this.IsText(rightBrace, j));
                if (ba)
                {
                    varContinue = false;
                }
                if (!ba)
                {
                    i = i - 1;
                }
            }
            if (!(start < i))
            {
                varContinue = false;
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual Token TokenForward(Token result, string value, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int i;
        i = start;
        int index;
        index = -1;
        bool varContinue;
        varContinue = (i < end);
        while (varContinue)
        {
            bool b;
            b = this.IsText(value, i);
            if (b)
            {
                index = i;
                varContinue = false;
            }
            if (!b)
            {
                int skipBracketIndex;
                skipBracketIndex = this.ForwardSkipBracket(i, end);
                bool ba;
                ba = (skipBracketIndex == -1);
                if (!ba)
                {
                    i = skipBracketIndex;
                }
                if (ba)
                {
                    i = i + 1;
                }
            }
            if (!(i < end))
            {
                varContinue = false;
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual Token TokenBackward(Token result, string value, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int i;
        i = end;
        int index;
        index = -1;
        bool varContinue;
        varContinue = (start < i);
        while (varContinue)
        {
            int j;
            j = i - 1;
            bool b;
            b = this.IsText(value, j);
            if (b)
            {
                index = j;
                varContinue = false;
            }
            if (!b)
            {
                int skipBracketIndex;
                skipBracketIndex = this.BackwardSkipBracket(i, start);
                bool ba;
                ba = (skipBracketIndex == -1);
                if (!ba)
                {
                    i = skipBracketIndex;
                }
                if (ba)
                {
                    i = i - 1;
                }
            }
            if (!(start < i))
            {
                varContinue = false;
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual int ForwardSkipBracket(int index, int end)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        DelimitList delimit;
        delimit = this.Delimit;
        int ret;
        ret = -1;
        TokenToken aa;
        aa = this.TokenToken(index);
        
        TextLess less;
        less = this.TextLess;
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);
        Text textB;
        textB = this.TextB;

        this.TextStringGet(textB, delimit.LeftBracket.Text);
        if (textInfra.Equal(text, textB, less))
        {
            Token rightBracket;
            rightBracket = this.TokenMatchLeftBracket(this.TokenA, this.Range(this.RangeA, index + 1, end));
            if (!(rightBracket == null))
            {
                ret = rightBracket.Range.End;
            }
        }

        this.TextStringGet(textB, delimit.LeftBrace.Text);
        if (textInfra.Equal(text, textB, less))
        {
            Token rightBrace;
            rightBrace = this.TokenMatchLeftBrace(this.TokenA, this.Range(this.RangeA, index + 1, end));
            if (!(rightBrace == null))
            {
                ret = rightBrace.Range.End;
            }
        }
        return ret;
    }

    protected virtual int BackwardSkipBracket(int index, int start)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        DelimitList delimit;
        delimit = this.Delimit;
        int ret;
        ret = -1;
        int t;
        t = index - 1;
        TokenToken aa;
        aa = this.TokenToken(t);

        TextLess less;
        less = this.TextLess;
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);
        Text textB;
        textB = this.TextB;

        this.TextStringGet(textB, delimit.RightBracket.Text);
        if (textInfra.Equal(text, textB, less))
        {
            Token leftBracket;
            leftBracket = this.TokenMatchRightBracket(this.TokenA, this.Range(this.RangeA, start, t));
            if (!(leftBracket == null))
            {
                ret = leftBracket.Range.Start;
            }
        }

        this.TextStringGet(textB, delimit.RightBrace.Text);
        if (textInfra.Equal(text, textB, less))
        {
            Token leftBrace;
            leftBrace = this.TokenMatchRightBrace(this.TokenA, this.Range(this.RangeA, start, t));
            if (!(leftBrace == null))
            {
                ret = leftBrace.Range.Start;
            }
        }
        return ret;
    }

    protected virtual Token TokenMatchLeftBrace(Token result, Range range)
    {
        return this.TokenMatchLeftToken(result, this.Delimit.LeftBrace.Text, this.Delimit.RightBrace.Text, range);
    }

    protected virtual Token TokenMatchRightBrace(Token result, Range range)
    {
        return this.TokenMatchRightToken(result, this.Delimit.LeftBrace.Text, this.Delimit.RightBrace.Text, range);
    }

    protected virtual Token TokenMatchLeftBracket(Token result, Range range)
    {
        return this.TokenMatchLeftToken(result, this.Delimit.LeftBracket.Text, this.Delimit.RightBracket.Text, range);
    }

    protected virtual Token TokenMatchRightBracket(Token result, Range range)
    {
        return this.TokenMatchRightToken(result, this.Delimit.LeftBracket.Text, this.Delimit.RightBracket.Text, range);
    }

    protected virtual Token TokenMatchLeftToken(Token result, string leftToken, string rightToken, Range range)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        int start;
        int end;
        start = range.Start;
        end = range.End;

        TextLess less;
        less = this.TextLess;
        Text text;
        text = this.TextA;
        Text textB;
        textB = this.TextB;

        int openCount;
        openCount = 1;
        int index;
        index = -1;
        int i;
        i = start;
        bool varContinue;
        varContinue = (i < end);
        while (varContinue)
        {
            TokenToken aa;
            aa = this.TokenToken(i);
            this.TextGet(text, aa);
            
            this.TextStringGet(textB, rightToken);
            if (textInfra.Equal(text, textB, less))
            {
                openCount = openCount - 1;
                if (openCount == 0)
                {
                    index = i;
                    varContinue = false;
                }
            }

            this.TextStringGet(textB, leftToken);
            if (textInfra.Equal(text, textB, less))
            {
                openCount = openCount + 1;
            }

            if (index == -1)
            {
                i = i + 1;
                if (!(i < end))
                {
                    varContinue = false;
                }
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual Token TokenMatchRightToken(Token result, string leftToken, string rightToken, Range range)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        int start;
        int end;
        start = range.Start;
        end = range.End;

        TextLess less;
        less = this.TextLess;
        Text text;
        text = this.TextA;
        Text textB;
        textB = this.TextB;

        int openCount;
        openCount = 1;
        int index;
        index = -1;
        int i;
        i = end;
        bool varContinue;
        varContinue = (i > start);
        while (varContinue)
        {
            int t;
            t = i - 1;
            TokenToken aa;
            aa = this.TokenToken(t);
            this.TextGet(text, aa);

            this.TextStringGet(textB, leftToken);
            if (textInfra.Equal(text, textB, less))
            {
                openCount = openCount - 1;
                if (openCount == 0)
                {
                    index = t;
                    varContinue = false;
                }
            }

            this.TextStringGet(textB, rightToken);
            if (textInfra.Equal(text, textB, less))
            {
                openCount = openCount + 1;
            }
            
            if (index == -1)
            {
                i = i - 1;
                if (!(i > start))
                {
                    varContinue = false;
                }
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }
}