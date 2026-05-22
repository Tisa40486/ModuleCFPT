class Node {
    Name;
    Children = [];

    constructor(name) {
        this.Name = name;
    }
    
    get Name() {
        return this.Name;
    }
    get Children() {
        return this.Children;
    }
    addChild(node) {
        this.Children.push(node);
    }
}

   function DFS(node) {
        console.log(node.Name);
        node.Children.forEach(x => {
            DFS(x);
        });
    }

let root = new Node("Root");
let a = new Node("A");
let b = new Node("B");
let c = new Node("C");
let d = new Node("D");
let e = new Node("E");
let f = new Node("F");
let g = new Node("G");
let h = new Node("H");
let i = new Node("I");
let j = new Node("J");
let k = new Node("K");
let l = new Node("L");
let m = new Node("M");
let n = new Node("N");

root.addChild(a);
root.addChild(b);
root.addChild(c);
root.addChild(d);

a.addChild(e);
a.addChild(f);
a.addChild(g);

b.addChild(h);
b.addChild(i);

c.addChild(j);
c.addChild(k);

d.addChild(l);
d.addChild(m);
d.addChild(n);

DFS(root);

function BFS()
{

}