namespace BenchmarkBox
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using BenchmarkDotNet.Attributes;

    public class RaisePropertyChangedBenchmarks : INotifyPropertyChanged
    {
        private int expressionValue;
        private int callerMemberNameValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ExpressionValue
        {
            get { return expressionValue; }
            set
            {
                expressionValue = value;
                OnPropertyChanged(() => ExpressionValue);
            }
        }

        public int CallerMemberNameValue
        {
            get { return callerMemberNameValue; }
            set
            {
                callerMemberNameValue = value;
                OnPropertyChanged();
            }
        }

        [Benchmark]
        public void SetWithExpression()
        {
            ExpressionValue++;
        }

        [Benchmark(Baseline = true)]
        public void SetWithCallerMemberName()
        {
            CallerMemberNameValue++;
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var property = (MemberExpression)expression.Body;
            this.OnPropertyChanged(property.Member.Name);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}