class Program
{
    static void Main(string[] args)
    {
        Complex val1 =new Complex(112,31);
        Complex val2 =new Complex(3,3);
        OperationComplex op1 = new OperationComplex(val1,val2,new multiply());
        op1.implement();
        val1 =new Complex(3,3);
        val2 =new Complex(3,3);
        op1=new OperationComplex(val1,val2,new equal());
        op1.implement();
    }
}

class Complex{
    public int r;
    public int im;
    public Complex(int val1, int val2){
        r=val1;
        im=val2;
    }
    public override string ToString()
    {
        string result = "r: " + r.ToString() + " im: " + im.ToString();
        return result;
    }
}

interface ILogical
{
    public bool implement(Complex val1, Complex val2);
}

interface IAriphmetic
{
    public Complex implement(Complex val1, Complex val2);
}

class add:IAriphmetic{
    public Complex implement(Complex val1, Complex val2){
        return new Complex(val1.r+val2.r,val1.im+val2.im);
    }
}

class substract:IAriphmetic{
    public Complex implement(Complex val1, Complex val2){
        return new Complex(val1.r-val2.r,val1.im-val2.im);
    }
}

class multiply:IAriphmetic{
    public Complex implement(Complex val1, Complex val2){
        return new Complex(val1.r*val2.r - val1.im*val2.im ,val1.r*val2.im + val1.im*val2.r);
    }
}

class divide:IAriphmetic{
    public Complex implement(Complex val1, Complex val2){

        int r = (val1.r*val2.r + val1.im*val2.im)/(int)(Math.Pow(val2.r,2)+Math.Pow(val2.im,2));
        int im = (val1.im*val2.r - val1.r*val2.im)/(int)(Math.Pow(val2.r,2)+Math.Pow(val2.im,2));
        return new Complex(r,im);
    }
}

class equal:ILogical{
    public bool implement(Complex val1, Complex val2){
        if(val1.r==val2.r && val1.im == val2.im){
            return true;
        }else{
            return false;
        }

    }
}
class bigger:ILogical{
    public bool implement(Complex val1, Complex val2){
        if(val1.r==val2.r && val1.im == val2.im){
            return true;
        }else{
            return false;
        }

    }
}


class OperationComplex{
    Complex val1;
    Complex val2;
    IAriphmetic ariphmetic;
    ILogical logical;

    bool operationType;

    public OperationComplex(Complex val1, Complex val2, IAriphmetic operation){
        this.val1=val1;
        this.val2=val2;
        ariphmetic=operation;
        operationType=true;
    }
    public OperationComplex(Complex val1, Complex val2, ILogical operation){
        this.val1=val1;
        this.val2=val2;
        logical=operation;
        operationType=false;
    }
    public void implement(){
        if(operationType==true){
            Console.WriteLine(ariphmetic.implement(val1,val2));
        }else{
            Console.WriteLine(logical.implement(val1,val2));
        }
    }
}
