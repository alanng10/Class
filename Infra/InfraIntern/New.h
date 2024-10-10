#pragma once

#include "Pronate.h"

typedef struct
{
    Int AllocCap;
    Int TotalAllocCount;
    Int Phore;
    Int ThisThreadIdent;
    Int FirstNode;
    Int LastNode;
    Int QueueFirstNode;
    Int QueueLastNode;
    Int ModuleArray;
    Int Thread[1024 * 2];
}
InternNewData;

#define NodeField(n, index) (((Int*)(n))[index])

#define NodeFieldNext(n) NodeField(n, 0)

#define NodeFieldPrevious(n) NodeField(n, 1)

#define NodeFieldSize(n) NodeField(n, 2)

#define NodeFieldFlag(n) NodeField(n, 3)

#define NodeFieldQueueNext(n) NodeField(n, 4)

#define NodeFieldQueuePrevious(n) NodeField(n, 5)

#define QueueFlag (0x10000)

#define QueueNodeVar \
Int refKindU;\
refKindU = 0;\
Int puu;\
puu = 0;\
Int nodeU;\
nodeU = 0;\
Int flagU;\
flagU = 0;\
\


#define QueueNode \
{\
        refKindU = ka >> 60;\
\
        if (refKindU == RefKindAny | refKindU == RefKindString | refKindU == RefKindData | refKindU == RefKindArray)\
        {\
            puu = ka & RefMaskMemoryClear;\
\
            puu = puu - 6 * Constant_IntByteCount();\
\
            nodeU = puu;\
\
            flagU = NodeFieldFlag(nodeU);\
\
            if ((flagU & QueueFlag) == 0)\
            {\
                flagU = flagU | QueueFlag;\
\
                NodeFieldFlag(nodeU) = flagU;\
\
                if (!(m->QueueLastNode == null))\
                {\
                    NodeFieldQueuePrevious(nodeU) = m->QueueLastNode;\
\
                    NodeFieldQueueNext(m->QueueLastNode) = nodeU;\
                }\
\
                if (m->QueueFirstNode == null)\
                {\
                    m->QueueFirstNode = nodeU;\
                }\
\
                m->QueueLastNode = nodeU;\
            }\
        }\
}\



Bool Intern_New_PauseOtherThread();

Bool Intern_New_ResumeOtherThread();

Bool Intern_New_QueueAllRoot();

Bool Intern_New_QueueAllThreadEvalStack();

Bool Intern_New_QueueEvalStack(Eval* eval);

Bool Intern_New_QueueClassShare();

Bool Intern_New_QueueClassShareModule(Module* module);

Bool Intern_New_Traverse();
