using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAdmissionV1
{
    public enum EnumStatus
    {
        Undefined,
        FullTime,
        PartTime
    }

    public class Student
    {
        private int id;
        private String fn;
        private String ln;
        
        private EnumStatus status;
         
        public void  SetId(int value)
        {            
                this.id = value;            
        }
        public int GetId()
        {
           return  this.id;
        }
        public void SetFn(string value)
        {
            this.fn = value;
        }
        public string GetFn()
        {
            return fn;
        }
        public void SetLn(string value)
        {
            this.ln = value;
        }
        public string GetLn()
        {
            return ln;
        }
       
        public void SetStatus(EnumStatus status)
        {
            this.status = status;
        }
        public EnumStatus GetStatus()
        {
            return this.status;
        }
        public Student()
        {
            this.id = 0000;
            this.fn = "unknown";
            this.ln = "unknown";
            this.status = EnumStatus.Undefined;
        }
        public Student(int id, String fn, String ln)
        {
            this.id = id;
            this.fn = fn;
            this.ln = ln;
            this.status = EnumStatus.Undefined;
        }
        public Student(int id, String fn, String ln,   EnumStatus status )
        {
            this.id = id;
            this.fn = fn;
            this.ln = ln;
            this.status = status;
        }


        public override String ToString()
        {
            String state;
            state = this.id + "\t" + this.fn + "\t" + this.ln + "\t" + this.status;
            return state;
        }
    }
}
