namespace Demo;

class NetworkNewPeerState : State
{
    public Demo Demo { get; set; }
    public ThreadNetworkServerState ServerState { get; set; }
    
    public override bool Execute()
    {
        if (!(this.Demo.Peer == null))
        {
            Console.This.Err.Write("Network Peer is more one\n");
            return false;
        }

        Network network;
        network = this.Demo.Server.NextPendingPeer();
        
        this.Demo.Peer = network;

        NetworkPeerReadyState state;
        state = new NetworkPeerReadyState();
        state.Demo = this.Demo;
        state.ServerState = this.ServerState;
        state.Init();

        NetworkPeerStatusState stateA;
        stateA = new NetworkPeerStatusState();
        stateA.ServerState = this.ServerState;
        stateA.Init();

        NetworkPeerCaseState stateB;
        stateB = new NetworkPeerCaseState();
        stateB.ServerState = this.ServerState;
        stateB.Init();

        network.StatusChangeState = stateA;

        network.CaseChangeState = stateB;

        network.ReadyReadState = state;
        return true;
    }
}