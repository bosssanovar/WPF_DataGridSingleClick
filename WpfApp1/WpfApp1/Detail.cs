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
        public ReactivePropertySlim<bool> V1 { get; } = new ReactivePropertySlim<bool>(false);
        public ReactivePropertySlim<bool> V2 { get; } = new ReactivePropertySlim<bool>(false);
        public ReactivePropertySlim<bool> V3 { get; } = new ReactivePropertySlim<bool>(true);
        public ReactivePropertySlim<bool> V4 { get; } = new ReactivePropertySlim<bool>(false);
        public ReactivePropertySlim<bool> V5 { get; } = new ReactivePropertySlim<bool>(false);
    }
}
