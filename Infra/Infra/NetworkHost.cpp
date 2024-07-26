#include "NetworkHost.hpp"

CppClassNew(NetworkServer)

Int NetworkServer_Init(Int o)
{
    return true;
}

Int NetworkServer_Final(Int o)
{
    return true;
}

CppField(NetworkServer, Port)

Int NetworkServer_Listen(Int o)
{
    NetworkServer* m;
    m = CP(o);

    m->Intern = new NetworkServerIntern;
    m->Intern->NetworkServer = o;
    m->Intern->Init();

    m->Intern->Open();

    Int uu;
    uu = NetworkPort_InternAddress(m->Port);
    QHostAddress* ua;
    ua = (QHostAddress*)uu;

    quint16 ub;
    ub = NetworkPort_ServerGet(m->Port);

    bool bu;
    bu = m->Intern->listen(*ua, ub);

    Bool a;
    a = bu;
    return a;
}

Int NetworkServer_Close(Int o)
{
    NetworkServer* m;
    m = CP(o);
    m->Intern->close();

    m->Intern->Close();

    delete m->Intern;
    m->Intern = null;
    return true;
}

CppField(NetworkServer, NewPeerState)

Int NetworkServer_NextPendingPeer(Int o)
{
    NetworkServer* m;
    m = CP(o);
    QTcpSocket* socket;
    socket = m->Intern->nextPendingConnection();

    Int stream;
    stream = Stream_New();
    Stream_Init(stream);
    Int network;
    network = Network_New();
    Network_Init(network);
    Network_StreamSet(network, stream);

    Int uu;
    uu = CastInt(socket);
    Network_ServerOpen(network, uu);
    return network;
}

Int NetworkServer_ClosePeer(Int o, Int network)
{
    Int stream;
    stream = Network_StreamGet(network);

    Network_ServerClose(network);

    Network_Final(network);
    Network_Delete(network);

    Stream_Final(stream);
    Stream_Delete(stream);
    return true;
}

Int NetworkServer_NewPeer(Int o)
{
    NetworkServer* m;
    m = CP(o);
    Int state;
    state = m->NewPeerState;
    if (state == null)
    {
        return true;
    }
    
    Int aa;
    aa = State_MaideGet(state);
    Int arg;
    arg = State_ArgGet(state);

    NetworkServer_NewPeer_Maide maide;
    maide = (NetworkServer_NewPeer_Maide)aa;
    if (!(maide == null))
    {
        maide(o, arg);
    }
    return true;
}