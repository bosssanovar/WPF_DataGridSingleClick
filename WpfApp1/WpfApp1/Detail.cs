using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Detail
    {
        public List<ReactivePropertySlim<bool>> V { get; } = new List<ReactivePropertySlim<bool>>();

        public Detail()
        {
            for(int i = 0; i < 5; i++)
            {
                V.Add(new ReactivePropertySlim<bool>(false));
            }

            V[2].Value = true;
        }
    }
}
