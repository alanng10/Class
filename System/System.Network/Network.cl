class Network : Any
{
    maide private Bool PrivateStatusEvent()
    {
        this.StatusEvent();
        return true;
    }

    maide private Bool PrivateCaseEvent()
    {
        inf (this.Case = this.NetworkCaseList.Connected)
        {
            this.Stream : this.DataStream;
            this.LoadOpen : false;
        }

        this.CaseEvent();
        return true;
    }

    maide private Bool PrivateDataEvent()
    {
        this.DataEvent();
        return true;
    }
    
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        this.NetworkStatusList : share StatusList;
        this.NetworkCaseList : share CaseList;
        
        var Int ka;
        var Int kb;
        var Int kc;
        ka : this.InternIntern.StateNetworkStatusEvent();
        kb : this.InternIntern.StateNetworkCaseEvent();
        kc : this.InternIntern.StateNetworkDataEvent();
        var Int arg;
        arg : this.InternIntern.Memory(this);
        this.InternStatusEventState : this.InternInfra.StateCreate(ka, arg);
        this.InternCaseEventState : this.InternInfra.StateCreate(kb, arg);
        this.InternDataEventState : this.InternInfra.StateCreate(kc, arg);

        var Extern extern;
        extern : this.Extern;

        var Bool b;
        b : (this.HostPeer = 0);
        inf (b)
        {
            this.Intern : extern.Network_New();
            extern.Network_Init(this.Intern);
        }
        inf (~b)
        {
            this.Intern : this.HostPeer;

            var Int ident;
            ident : extern.Network_StreamGet(this.Intern);

            this.DataStream : this.StreamCreateSet(ident);
            this.Stream : this.DataStream;
        }

        extern.Network_StatusEventStateSet(this.Intern, this.InternStatusEventState);
        extern.Network_CaseEventStateSet(this.Intern, this.InternCaseEventState);
        extern.Network_DataEventStateSet(this.Intern, this.InternDataEventState);
        return true;        
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Network_DataEventStateSet(this.Intern, 0);
        extern.Network_CaseEventStateSet(this.Intern, 0);
        extern.Network_StatusEventStateSet(this.Intern, 0);

        var Bool b;
        b : (this.HostPeer = 0);
        inf (b)
        {
            extern.Network_Final(this.Intern);
            extern.Network_Delete(this.Intern);
        }
        inf (~b)
        {
            this.DataStream.Final();
            this.Stream : null;
        }

        this.InternInfra.StateDelete(this.InternDataEventState);
        this.InternInfra.StateDelete(this.InternCaseEventState);
        this.InternInfra.StateDelete(this.InternStatusEventState);
        return true;
    }

    field prusate Int HostPeer { get { return data; } set { data : value; } }
    field prusate String HostName { get { return data; } set { data : value; } }
    field prusate Int HostPort { get { return data; } set { data : value; } }
    field prusate StreamStream Stream { get { return data; } set { data : value; } }
    field precate StreamStream DataStream { get { return data; } set { data : value; } }
    field prusate Bool LoadOpen { get { return data; } set { data : value; } }
    
    field prusate Status Status
    {
        get
        {
            var Int k;
            k : this.Extern.Network_StatusGet(this.Intern);
            var Status a;
            a : this.NetworkStatusList.Get(k);
            return a;
        }
        set
        {
        }
    }

    field prusate Case Case
    {
        get
        {
            var Int k;
            k : this.Extern.Network_CaseGet(this.Intern);
            inf (k = 0)
            {
                return null;
            }
            k : k - 1;
            var Case a;
            a : this.NetworkCaseList.Get(k);
            return a;
        }
        set
        {
        }
    }    
}