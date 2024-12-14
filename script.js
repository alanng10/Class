document.addEventListener("DOMContentLoaded", function (event) {

    InitHeader();

    InitNavi();
});

function InitHeader()
{
    var a;
    a = document.querySelector(".Main .Header > .Name > a");

    var link;
    link = PageRootPath;
    link = AddLinkFileName(link);

    a.href = link;
}

function InitNavi()
{
    var ba;
    ba = (typeof ArticlePath === 'undefined');

    if (ba)
    {
        var navi;
        navi = document.querySelector(".Main .Navi");

        var e;
        e = NodeCreateSingle("Article", "article");

        var nodeIcon;
        nodeIcon = e.firstElementChild;

        nodeIcon.setAttribute('data-before', '\uef42');

        navi.appendChild(e);
    }

    if (!ba)
    {
        NaviArticleCreate();

        NaviArticleSet();
    }
}

function NaviArticleSet()
{
    var node;
    node = NaviTree;

    var h;
    h = ArticlePath.substring(2);

    var index;
    index = 0;
    var u;
    u = h.indexOf("/", 0);
    while (!(u < 0))
    {
        var k;
        k = h.substring(index, u);

        node = node.Child[k];

        var e;
        e = node.Element;
        NodeSet(e, true);

        index = u + 1;

        u = h.indexOf("/", index);
    }

    u = h.length;

    var k;
    k = h.substring(index, u);

    node = node.Child[k];

    var e;
    e = node.Element;
    e.classList.add("Current");
}

function NaviArticleCreate()
{
    var navi;
    navi = document.querySelector(".Main .NaviArticle");

    var e;
    e = NodeCreate(NaviTree, ".");

    NodeSet(e, true);

    navi.appendChild(e);
}

function NodeCreateSingle(name, path)
{
    var e;
    e = CreateElement();
    e.className = "Node";

    var ea;
    ea = CreateElement();
    ea.className = "Icon";

    var eb;
    eb = CreateElement();
    eb.className = "Name";

    var link;
    link = PageRootPath + "/" + path;

    link = AddLinkFileName(link);

    var eba;
    eba = document.createElement("a");
    eba.innerText = name;
    eba.href = link;

    eb.appendChild(eba);

    e.appendChild(ea);
    e.appendChild(eb);

    return e;
}

function NodeCreate(a, path)
{
    var e;
    e = CreateElement();
    e.className = "Node";

    var ea;
    ea = CreateElement();
    ea.className = "Icon";

    var eb;
    eb = CreateElement();
    eb.className = "Name";

    var link;
    link = PageRootPath + "/" + "article" + "/" + path;

    link = AddLinkFileName(link);

    var eba;
    eba = document.createElement("a");
    eba.innerText = a.Name;
    eba.href = link;

    eb.appendChild(eba);

    var ec;
    ec = CreateElement();
    ec.className = "Child";

    e.appendChild(ea);
    e.appendChild(eb);
    e.appendChild(ec);

    a.Element = e;

    var i;
    i = 0;
    for (var index in a.Child)
    {
        var aa;
        aa = a.Child[index];

        var ka;
        ka = path + "/" + aa.Name.toLowerCase();

        var ee;
        ee = NodeCreate(aa, ka);

        ec.appendChild(ee);

        i = i + 1;
    }

    var b;
    b = (i == 0);
    if (b)
    {
        e.classList.add("Leaf");

        var ooa;
        ooa = '\ue57b';
        ea.setAttribute('data-before', ooa);
    }
    if (!b)
    {
        NodeSet(e, false);

        ea.addEventListener("click", function (event) {
            event.stopPropagation();

            var a;
            a = this.parentElement;

            ToggleNode(a);
        });
    }
    return e;
}

function AddLinkFileName(link)
{
    if (LinkFileName)
    {
        link = link + "/index.html";
    }
    return link
}

function CreateElement()
{
    return document.createElement("div");
}

function ToggleNode(node)
{
    var b;
    b = node.Expanded;

    b = !b;

    NodeSet(node, b);
}

function NodeSet(node, expanded)
{
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