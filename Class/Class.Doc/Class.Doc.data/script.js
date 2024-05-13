document.addEventListener("DOMContentLoaded", function (event) {

    CreateNavi();
});

function CreateNavi() {
    var navi;
    navi = document.querySelector(".Navi");

    var e;
    e = CreateNode(NaviTree);

    NodeSet(e, true);

    navi.appendChild(e);
}

function CreateNode(a) {
    var e;
    e = CreateElement();
    e.className = "Node";

    var ea;
    ea = CreateElement();
    ea.className = "NodeIcon";

    var eb;
    eb = CreateElement();
    eb.className = "NodeName";
    eb.innerText = a.Name;

    var ec;
    ec = CreateElement();
    ec.className = "NodeChild";

    e.appendChild(ea);
    e.appendChild(eb);
    e.appendChild(ec);

    NodeSet(e, false);

    ea.addEventListener("click", function (event) {
        event.stopPropagation();

        var a;
        a = this.parentElement;

        ToggleNode(a);
    });


    var array;
    array = a.Child;
    var count;
    count = array.length;
    var i;
    i = 0;
    while (i < count) {
        var aa;
        aa = array[i];

        var ee;
        ee = CreateNode(aa);

        ec.appendChild(ee);

        i = i + 1;
    }

    return e;
}

function CreateElement() {
    return document.createElement("div");
}

function ToggleNode(node) {
    var b;
    b = node.Expanded;

    b = !b;

    NodeSet(node, b);
}

function NodeSet(node, expanded) {
    var b;
    b = expanded;

    var oa;
    var o;
    if (b) {
        oa = '\ue5c5'
        o = "block";
    }
    if (!b) {
        oa = '\ue5df';
        o = "none";
    }

    var nodeIcon;
    nodeIcon = node.firstElementChild;

    nodeIcon.setAttribute('data-before', oa);

    var nodeChild;
    nodeChild = nodeIcon.nextElementSibling.nextElementSibling;

    nodeChild.style.display = o;

    node.Expanded = b;
}