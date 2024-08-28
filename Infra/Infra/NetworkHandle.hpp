#pragma once

#include <QAbstractSocket>
#include <QTcpSocket>

#include "Pronate.hpp"

class NetworkHandle : public QObject
{
    Q_OBJECT

public:
    Bool Init();
    
    Bool Open();
    Bool Close();
    
    Int Network;

public slots:

    void StatusChangeHandle(QAbstractSocket::SocketError socketError);
    void CaseChangeHandle(QAbstractSocket::SocketState socketState);
    void ReadyReadHandle();
};
