namespace Avalon.List;

class Tree : Any
{
    public override bool Init()
    {
        base.Init();
        this.NodeResult = new TreeNodeResult();
        this.NodeResult.Init();

        this.DirectionValue = 1;
        return true;
    }

    public virtual Less Less { get; set; }
    private TreeNode Root { get; set; }
    private TreeNodeResult NodeResult { get; set; }
    private long DirectionValue { get; set; }

    public virtual bool Ins(object index, object value)
    {
        if (index == null)
        {
            return false;
        }

        TreeNode node;
        node = this.TreeInsert(index, value);
        if (node == null)
        {
            return false;
        }

        this.InsertRetrace(node);
        return true;
    }

    public virtual bool Rem(object index)
    {
        if (index == null)
        {
            return false;
        }

        TreeNodeResult t;
        t = this.Node(index);
        if (!t.HasNode)
        {
            return false;
        }

        TreeNode node;
        node = t.Node;

        this.TreeRemove(node);

        this.RemoveRetrace(node);
        return true;
    }

    public virtual bool Clear()
    {
        this.Root = null;
        return true;
    }

    private bool InsertRetrace(TreeNode Z)
    {
        TreeNode X;
        TreeNode G;
        TreeNode N;
        long direction;

        for (X = Z.Parent; X != null; X = Z.Parent)
        {
            // Loop (possibly up to the root)
            // BF(X) has to be updated:
            if (Z == X.ChildRite)
            {
                // The right subtree increases
                direction = -DirectionValue;
            }
            else
            {
                direction = +DirectionValue;
            }

            if (this.Sign(X.BalanceFactor) == - direction)
            {
                // X is right-heavy
                // ==> the temporary BF(X) == +2
                // ==> rebalancing is required.
                G = X.Parent; // Save parent of X around rotations

                if (this.Sign(Z.BalanceFactor) == direction)    // Right Left Case  (see figure 3)
                {
                    N = this.RotateDouble(X, Z, direction);     // Double rotation: Right(Z) then Left(X)
                }
                else
                {                                               // Right Right Case (see figure 2)
                    N = this.RotateSingle(X, Z, direction);     // Single rotation Left(X)
                }
                // After rotation adapt parent link
            }
            else
            {
                if (this.Sign(X.BalanceFactor) == direction)
                {
                    X.BalanceFactor = 0; // Z’s height increase is absorbed at X.

                    break; // Leave the loop
                }

                X.BalanceFactor = - direction;

                Z = X; // Height(Z) increases by 1
                continue;
            }

            // After a rotation adapt parent link:
            // N is the new root of the rotated subtree
            // Height does not change: Height(N) == old Height(X)

            N.Parent = G;

            if (G != null)
            {
                if (X == G.ChildLite)
                {
                    G.ChildLite = N;
                }
                else
                {
                    G.ChildRite = N;
                }
            }
            else
            {
                this.Root = N; // N is the new root of the total tree
            }

            break;
            // There is no fall thru, only break; or continue;
        }

        // Unless loop is left via break, the height of the total tree increases by 1.
        return true;
    }

    private bool RemoveRetrace(TreeNode N)
    {
        TreeNode X;
        TreeNode G;
        TreeNode Z;
        long direction;
        long b;

        for (X = N.Parent; X != null; X = G)
        { 
            // Loop (possibly up to the root)
            G = X.Parent; // Save parent of X around rotations
                           // BF(X) has not yet been updated!
            if (N == X.ChildLite)
            {
                direction = - DirectionValue;
            }
            else
            {
                direction = + DirectionValue;
            }

            // the left subtree decreases

            if (this.Sign(X.BalanceFactor) == -direction)
            {
                // X is right-heavy
                // ==> the temporary BF(X) == +2
                // ==> rebalancing is required.

                if (direction == -DirectionValue)
                {

                    Z = X.ChildRite; // Sibling of N (higher by 2)
                }
                else
                {
                    Z = X.ChildLite; // Sibling of N (higher by 2)
                }

                b = Z.BalanceFactor;

                if (this.Sign(b) == direction)                  // Right Left Case  (see figure 3)
                {
                    N = this.RotateDouble(X, Z, direction);     // Double rotation: Right(Z) then Left(X)
                }
                else
                {
                    // Right Right Case (see figure 2)

                    N = this.RotateSingle(X, Z, direction);     // Single rotation Left(X)
                }

                // After rotation adapt parent link
            }
            else
            {
                if (X.BalanceFactor == 0)
                {
                    X.BalanceFactor = - direction; // N’s height decrease is absorbed at X.
                    break; // Leave the loop
                }

                N = X;

                N.BalanceFactor = 0; // Height(N) decreases by 1
                continue;
            }

            // After a rotation adapt parent link:
            // N is the new root of the rotated subtree
            
            N.Parent = G;

            if (G != null)
            {
                if (X == G.ChildLite)
                {
                    G.ChildLite = N;
                }
                else
                {
                    G.ChildRite = N;
                }
            }
            else
            {
                this.Root = N; // N is the new root of the total tree
            }

            if (b == 0)
            {
                break; // Height does not change: Leave the loop
            }

            // Height(N) decreases by 1 (== old Height(X)-1)
        }

        // If (b != 0) the height of the total tree decreases by 1.
        return true;
    }

    private TreeNode TreeInsert(object index, object value)
    {
        TreeNodeResult t;
        t = this.Node(index);
        if (t.HasNode)
        {
            return null;
        }

        TreeNode node;
        node = new TreeNode();
        node.Init();
        node.Index = index;
        node.Value = value;
        node.BalanceFactor = 0;

        if (t.ParentNode == null)
        {
            this.Root = node;
        }
        
        if (!(t.ParentNode == null))
        {
            if (t.ParentLite)
            {
                t.ParentNode.ChildLite = node;
            }

            if (! t.ParentLite)
            {
                t.ParentNode.ChildRite = node;
            }

            node.Parent = t.ParentNode;
        }

        TreeNode ret;
        ret = node;
        return ret;
    }

    private TreeNode RotateSingle(TreeNode X, TreeNode Z, long direction)
    {
        this.RotateTreeSingle(X, Z, direction);

        // 1st case, BF(Z) == 0,
        //   only happens with deletion, not insertion:
        if (Z.BalanceFactor == 0)
        { 
            // t23 has been of same height as t4
            
            X.BalanceFactor = - direction;   // t23 now higher

            Z.BalanceFactor = direction;   // t4 now lower than X
        }
        else
        { 
            // 2nd case happens with insertion or deletion:
            
            X.BalanceFactor = 0;

            Z.BalanceFactor = 0;
        }

        return Z; // return new root of rotated subtree
    }

    private TreeNode RotateDouble(TreeNode X, TreeNode Z, long direction)
    {
        TreeNode Y;
        Y = this.RotateTreeDouble(X, Z, direction);

        // 1st case, BF(Y) == 0,
        //   only happens with deletion, not insertion:
        if (Y.BalanceFactor == 0)
        {
            X.BalanceFactor = 0;
            Z.BalanceFactor = 0;
        }
        else
        {
            // other cases happen with insertion or deletion:
            if (this.Sign(Y.BalanceFactor) == -direction)
            { // t3 was higher
                X.BalanceFactor = direction;  // t1 now higher
                Z.BalanceFactor = 0;
            }
            else
            {
                // t2 was higher
                X.BalanceFactor = 0;
                Z.BalanceFactor = - direction;  // t4 now higher
            }
        }

        Y.BalanceFactor = 0;
        return Y; // return new root of rotated subtree
    }

    private long Sign(long u)
    {
        if (u < 0)
        {
            return -this.DirectionValue;
        }

        if (0 < u)
        {
            return this.DirectionValue;
        }

        return 0;
    }

    private TreeNode RotateTreeDouble(TreeNode X, TreeNode Z, long direction)
    {
        TreeNode Y;
        Y = null;

        // Z is by 2 higher than its sibling

        bool b;
        b = (direction == - DirectionValue);

        if (b)
        {
            Y = Z.ChildLite; // Inner child of Z
        }

        if (! b)
        {
            Y = Z.ChildRite;
        }
        
        // Y is by 1 higher than sibling

        this.RotateTreeSingle(Z, Y, - direction);

        this.RotateTreeSingle(X, Y, direction);

        TreeNode ret;
        ret = Y;

        return ret;
    }

    private bool RotateTreeSingle(TreeNode X, TreeNode Z, long direction)
    {
        bool b;
        b = (direction ==  - DirectionValue);

        if (b)
        {
            this.RotateTreeLeft(X, Z);
        }

        if (! b)
        {
            this.RotateTreeRight(X, Z);
        }



        return true;
    }

    private bool RotateTreeLeft(TreeNode x, TreeNode z)
    {
        TreeNode t23;

        t23 = z.ChildLite;

        x.ChildRite = t23;

        if (!(t23 == null))
        {
            t23.Parent = x;
        }
        
        z.ChildLite = x;

        x.Parent = z;
        return true;
    }

    private bool RotateTreeRight(TreeNode X, TreeNode Z)
    {
        TreeNode t23;

        // Z is by 2 higher than its sibling

        t23 = Z.ChildRite; // Inner child of Z

        X.ChildLite = t23;

        if (t23 != null)
        {
            t23.Parent = X;
        }
        
        Z.ChildRite = X;

        X.Parent = Z;
        return true;
    }

    private bool TreeRemove(TreeNode z)
    {
        if (z.ChildLite == null)
        {
            this.SubtreeShift(z, z.ChildRite);
        }
        else if (z.ChildRite == null)
        {
            this.SubtreeShift(z, z.ChildLite);
        }
        else
        {
            TreeNode y;

            y = this.Successor(z);

            if (y.Parent != z)
            {
                this.SubtreeShift(y, y.ChildRite);

                y.ChildRite = z.ChildRite;

                y.ChildRite.Parent = y;
            }

            this.SubtreeShift(z, y);

            y.ChildLite = z.ChildLite;

            y.ChildLite.Parent = y;
        }

        return true;
    }

    private bool SubtreeShift(TreeNode u, TreeNode v)
    {
        bool b;
        b = false;
        
        if (!b)
        {
            if (u.Parent == null)
            {
                this.Root = v;

                b = true;
            }
        }
        if (!b)
        {
            if (u == u.Parent.ChildLite)
            {
                u.Parent.ChildLite = v;
            
                b = true;
            }
        }
        if (!b)
        {
            u.Parent.ChildRite = v;
        }

        if (!(v == null))
        {
            v.Parent = u.Parent;
        }

        return true;
    }

    private TreeNode Successor(TreeNode x)
    {
        if (!(x.ChildRite == null))
        {
            return this.Minimum(x.ChildRite);
        }

        TreeNode y;

        y = x.Parent;

        while ((!(y == null)) && x == y.ChildRite)
        {
            x = y;

            y = y.Parent;
        }

        return y;
    }

    private TreeNode Minimum(TreeNode x)
    {
        TreeNode t;

        t = x;

        while (!(t.ChildLite == null))
        {
            t = t.ChildLite;
        }

        return t;
    }

    public virtual TreeNodeResult Node(object index)
    {
        Less less;
        less = this.Less;

        TreeNode node;
        node = null;

        TreeNode parentNode;
        parentNode = null;

        bool parentLite;
        parentLite = false;

        bool b;
        b = false;

        long t;

        object o;

        TreeNode currentNode;

        currentNode = this.Root;

        while (!b & !(currentNode == null))
        {
            o = currentNode.Index;

            t = less.Execute(index, o);

            if (t == 0)
            {
                node = currentNode;

                b = true;
            }

            if (t < 0)
            {
                parentNode = currentNode;

                parentLite = true;

                currentNode = currentNode.ChildLite;
            }

            if (0 < t)
            {
                parentNode = currentNode;

                parentLite = false;

                currentNode = currentNode.ChildRite;
            }
        }

        TreeNodeResult u;

        u = this.NodeResult;

        u.HasNode = b;

        u.Node = node;

        u.ParentNode = parentNode;

        u.ParentLite = parentLite;

        TreeNodeResult a;
        a = u;
        return a;
    }
}
