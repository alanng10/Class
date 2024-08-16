namespace Demo;

class NetworkPeerReadyState : State
{
    public override bool Init()
    {
        this.Data = new Data();
        this.Data.Count = 10;
        this.Data.Init();

        this.Range = new Range();
        this.Range.Init();
        return true;
    }

    public Demo Demo { get; set; }
    public ThreadNetworkHostState HostState { get; set; }

    private Data Data { get; set; }
    private Range Range { get; set; }
    private long Case { get; set; }
    private long Status { get; set; }

    public override bool Execute()
    {
        bool b;
        b = this.ExecuteAll();
        if (!b)
        {
            this.HostState.ExitNetwork(this.Status);
        }
        return true;
    }

    private bool ExecuteAll()
    {
        Network peer;
        peer = this.Demo.Peer;

        long a;
        a = peer.ReadyCount;

        long count;
        count = 0;

        long cc;
        cc = this.Case;
        if (cc == 0)
        {
            count = 1;
        }
        if (cc == 1)
        {
            count = 4;
        }
        if (cc == 2)
        {
            count = 10;
        }

        if (a < count)
        {
            return true;
        }

        Data data;
        data = this.Data;

        Range range;
        range = this.Range;
        range.Index = 0;
        range.Count = count;

        peer.Stream.Read(data, range);

        range.Count = 1;

        if (cc == 0)
        {
            long kk;
            kk = data.Get(0);

            bool b;
            b = (kk == 58);
            if (b)
            {
                Console.This.Out.Write(this.S("Network Host Case 0 Success\n"));

                this.Case = 1;

                data.Set(0, this.Case);

                peer.Stream.Write(data, range);
            }
            if (!b)
            {
                Console.This.Err.Write(this.S("Network Host Case 0 Read Data Invalid\n"));
                this.Status = 22;
                return false;
            }
        }

        if (cc == 1)
        {
            long a0;
            long a1;
            long a2;
            long a3;
            a0 = data.Get(0);
            a1 = data.Get(1);
            a2 = data.Get(2);
            a3 = data.Get(3);

            bool ba;
            ba = (a0 == 11 & a1 == 57 & a2 == 98 & a3 == 149);
            if (ba)
            {
                Console.This.Out.Write(this.S("Network Host Case 1 Success\n"));

                this.Case = 2;

                data.Set(0, this.Case);

                peer.Stream.Write(data, range);

                return true;
            }
            if (!ba)
            {
                Console.This.Err.Write(this.S("Network Host Case 1 Read Data Invalid\n"));
                this.Status = 24;
                return false;
            }
        }

        if (cc == 2)
        {
            String ka;
            ka = this.Demo.StringComp.CreateData(data, null);

            String kaa;
            kaa = this.AddClear().AddS("Network Host Case 2 Read Text: ").Add(ka).AddS("\n").AddResult();

            Console.This.Out.Write(kaa);

            this.HostState.ExitNetwork(0);
            return true;
        }
        return true;
    }

    public virtual NetworkPeerReadyState Add(String a)
    {
        this.Demo.Add(a);
        return this;
    }

    public virtual NetworkPeerReadyState AddS(string o)
    {
        this.Demo.AddS(o);
        return this;
    }

    public virtual NetworkPeerReadyState AddClear()
    {
        this.Demo.AddClear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.Demo.AddResult();
    }

    public virtual String S(string o)
    {
        return this.Demo.S(o);
    }
}