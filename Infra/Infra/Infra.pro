include(../module.pri)


DEFINES += Infra_Module



HEADERS += \
    AString.hpp \
    Array.h \
    AudioEffect.hpp \
    AudioOut.hpp \
    Brush.hpp \
    Console.hpp \
    Data.h \
    Draw.hpp \
    Entry.h \
    Font.hpp \
    Format.h \
    FormatArg.h \
    Frame.hpp \
    FrameIntern.hpp \
    Gradient.hpp \
    GradientLinear.hpp \
    GradientRadial.hpp \
    GradientStop.hpp \
    Image.hpp \
    ImageRead.hpp \
    ImageWrite.hpp \
    Main.hpp \
    Math.hpp \
    Memory.hpp \
    Method.hpp \
    Network.hpp \
    NetworkHandle.hpp \
    NetworkPort.hpp \
    NetworkServer.hpp \
    NetworkServerIntern.hpp \
    Pen.hpp \
    Phore.hpp \
    Play.hpp \
    PointData.hpp \
    Pos.h \
    Post.hpp \
    PostIntern.hpp \
    Probate.h \
    Probate.hpp \
    Process.hpp \
    ProcessIntern.hpp \
    Prudate.h \
    Random.hpp \
    Range.h \
    Rect.h \
    Return.hpp \
    Share.hpp \
    Size.h \
    Stat.hpp \
    State.h \
    Storage.hpp \
    StorageArrange.hpp \
    Stream.hpp \
    TextEncode.hpp \
    Thread.hpp \
    ThreadIntern.hpp \
    Time.hpp \
    TimeEvent.hpp \
    TimeEventIntern.hpp \
    Transform.hpp \
    TransformIntern.hpp \
    VideoFrame.hpp \
    VideoOut.hpp \
    VideoOutIntern.hpp

SOURCES += \
    AString.cpp \
    Array.c \
    AudioEffect.cpp \
    AudioOut.cpp \
    Brush.cpp \
    Console.cpp \
    Data.c \
    Draw.cpp \
    Entry.c \
    Font.cpp \
    Format.c \
    FormatArg.c \
    Frame.cpp \
    FrameIntern.cpp \
    Gradient.cpp \
    GradientLinear.cpp \
    GradientRadial.cpp \
    GradientStop.cpp \
    Image.cpp \
    ImageRead.cpp \
    ImageWrite.cpp \
    Main.cpp \
    Math.cpp \
    Memory.cpp \
    Method.cpp \
    Network.cpp \
    NetworkHandle.cpp \
    NetworkPort.cpp \
    NetworkServer.cpp \
    NetworkServerIntern.cpp \
    Pen.cpp \
    Phore.cpp \
    Play.cpp \
    PointData.cpp \
    Pos.c \
    Post.cpp \
    PostIntern.cpp \
    Process.cpp \
    ProcessIntern.cpp \
    Random.cpp \
    Range.c \
    Rect.c \
    Return.cpp \
    Share.cpp \
    Size.c \
    Stat.cpp \
    Stat_BrushKind.cpp \
    Stat_Comp.cpp \
    Stat_GradientKind.cpp \
    Stat_GradientSpread.cpp \
    Stat_ImageFormat.cpp \
    Stat_NetworkCase.cpp \
    Stat_NetworkPortKind.cpp \
    Stat_NetworkStatus.cpp \
    Stat_PenCap.cpp \
    Stat_PenJoin.cpp \
    Stat_PenKind.cpp \
    Stat_PointData.cpp \
    Stat_StorageMode.cpp \
    Stat_StorageStatus.cpp \
    Stat_StreamKind.cpp \
    Stat_TextAlign.cpp \
    Stat_TextEncodeKind.cpp \
    Stat_TextWrap.cpp \
    Stat_ThreadCase.cpp \
    State.c \
    Storage.cpp \
    StorageArrange.cpp \
    Stream.cpp \
    TextEncode.cpp \
    Thread.cpp \
    ThreadIntern.cpp \
    Time.cpp \
    TimeEvent.cpp \
    TimeEventIntern.cpp \
    Transform.cpp \
    VideoFrame.cpp \
    VideoOut.cpp \
    VideoOutIntern.cpp



win32 {

HEADERS += \
    Thread_Windows.h \
    Console_Windows.h

SOURCES += \
    Thread_Windows.c \
    Console_Windows.c

}
