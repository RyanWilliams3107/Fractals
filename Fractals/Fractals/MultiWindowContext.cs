using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Fractals
{
    class MultiWindowContext : ApplicationContext
    {
        private int AmountForms;
        public MultiWindowContext(params Form[] forms)
        {
            this.AmountForms = forms.Length;
            foreach (Form form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    if (Interlocked.Decrement(ref AmountForms) == 0)
                    {
                        ExitThread();
                    }
                };
                form.Show();
            }
        }

    }
}
